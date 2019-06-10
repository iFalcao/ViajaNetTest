using Common.Helpers;
using InfraStructure.Repository;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using ViajaNet.Application.Contracts;
using ViajaNet.Domain.Models;

namespace ViajaNet.Application.Services
{
    public class VisitQueueService : IVisitQueueService
    {
        private readonly string _queueName = "VisitQueue";
        private readonly IVisitRepository _repo;

        public VisitQueueService(IVisitRepository repo)
        {
            _repo = repo;
        }

        public Visit RetrieveFromQueue()
        {
            BasicGetResult data;
            using (var connection = this.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    data = channel.BasicGet(_queueName, true);
                }
            }
            return data == null ? null : data.Body.ByteArrayToObject<Visit>();
        }

        public void AppendToQueue(Visit visitToSave)
        {
            using (var connection = this.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    this.CreateQueue(channel);
                    channel.BasicPublish(string.Empty, _queueName, null, visitToSave.ObjectToByteArray());
                }
            }
        }

        public async Task<Visit> Salvar(Visit visitToSave, string csvDbPath)
        {
            return await this._repo.Save(visitToSave, csvDbPath);
        }

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

        public QueueDeclareOk CreateQueue(IModel channel)
            => channel.QueueDeclare(_queueName, false, false, false, null);
    }
}

