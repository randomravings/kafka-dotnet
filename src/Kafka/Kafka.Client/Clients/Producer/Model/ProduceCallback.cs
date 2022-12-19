using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer.Model
{
    public record ProduceCallback<TKey, TValue>(
        ProduceRecord<TKey, TValue> Record,
        Timestamp Timestamp,
        Partition Partition,
        byte[]? KeyBytes,
        byte[]? ValueBytes,
        TaskCompletionSource<ProduceResult<TKey, TValue>> TaskCompletionSource
    );
}
