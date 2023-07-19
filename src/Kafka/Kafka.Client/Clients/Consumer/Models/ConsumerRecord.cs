using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    public sealed record ConsumerRecord<TKey, TValue>(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        TKey Key,
        TValue Value,
        IReadOnlyList<RecordHeader> Headers
    );
}
