using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuration
{
    public class VisitQueueConfiguration
    {
        private ConnectionFactory GetConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            return connectionFactory;
        }

        public IConnection CreateConnection()
        {
            return this.GetConnectionFactory().CreateConnection();
        }

        public QueueDeclareOk CreateQueue(string queueName, IConnection connection)
        {
            QueueDeclareOk queue;
            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(queueName, false, false, false, null);
            }
            return queue;
        }
    }
}
