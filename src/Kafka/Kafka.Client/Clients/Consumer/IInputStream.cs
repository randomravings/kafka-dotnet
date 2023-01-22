using Kafka.Client.Clients.Consumer.Models;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStream<TKey, TValue> :
        IAsyncEnumerable<ConsumeResult<TKey, TValue>>
    {
    }
}
