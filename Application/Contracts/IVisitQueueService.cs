using RabbitMQ.Client;
using System.Threading.Tasks;
using ViajaNet.Domain.Models;

namespace ViajaNet.Application.Contracts
{
    public interface IVisitQueueService
    {
        void AppendToQueue(Visit visitToSave);
        Visit RetrieveFromQueue();
        IConnection CreateConnection();
        Task<Visit> Salvar(Visit visitToSave);
        QueueDeclareOk CreateQueue(IModel channel);
    }
}
