using Application.Configuration;
using InfraStructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text.RegularExpressions;
using ViajaNet.Application.Contracts;
using ViajaNet.Domain.Models;
using Common.Helpers;
using System.Threading;

namespace RobotQueueConsumer
{
    class Program
    {
        private static IConfiguration Configuration;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static IModel Channel;
        private static IConnection Connection;

        static void Main(string[] args)
        {
            Console.WriteLine("Executando o serviço...");

            var serviceProvider = GetServiceProvider();

            var scope = serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetService<IVisitQueueService>();
            Connection = service.CreateConnection();
            Channel = Connection.CreateModel();
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (ch, ea) =>
            {
                var visit = ea.Body.ByteArrayToObject<Visit>();
                service.Salvar(visit);
                Console.WriteLine($"Visita foi salva com sucesso.");
                Channel.BasicAck(ea.DeliveryTag, false);
            };
            var x = service.CreateQueue(Channel);
            var consumerTag = Channel.BasicConsume(x.QueueName, false, consumer);

            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Saindo...");
                Connection.Close();
                Connection.Dispose();
                Channel.Dispose();
                scope.Dispose();
                waitHandle.Set();
            };

            if (waitHandle.WaitOne(100))
                Environment.Exit(0);
        }

        public static IServiceProvider GetServiceProvider()
        {
            Console.WriteLine("Carregando configurações...");
            Program.BuildConfiguration();
            var services = new ServiceCollection();
            services.ConfigureViajaNetServices(Configuration);
            return services.BuildServiceProvider();
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetWebApiPath())
                .AddJsonFile($"appsettings.json");
            Program.Configuration = builder.Build();
        }

        public static string GetWebApiPath()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return Directory.GetParent(appRoot) + @"\ViajaNet\";
        }
    }
}
