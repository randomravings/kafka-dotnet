using Kafka.Client.Clients.Consumer.Models;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumerInstance<TKey, TValue>
    {
        Task<ConsumerRecord<TKey, TValue>> Fetch(CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
    }
}
