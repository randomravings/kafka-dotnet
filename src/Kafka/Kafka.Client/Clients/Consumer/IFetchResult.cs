using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer
{
    public interface IFetchResult<TKey, TValue> :
        IEnumerable<ConsumerRecord<TKey, TValue>>
    {
        Error Error { get; }
    }
}
