using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer.Model
{
    public sealed record ProduceResult<TKey, TValue>(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        Error Error,
        string RecordError
    );
}
