using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducer<TKey, TValue> :
        IClient
    {
        ValueTask<ProduceResult<TKey, TValue>> Send(
            ProduceRecord<TKey, TValue> produceRecrod,
            CancellationToken cancellationToken = default
        );
    }
}
