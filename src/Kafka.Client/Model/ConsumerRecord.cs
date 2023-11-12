using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record ConsumerRecord(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        IReadOnlyList<RecordHeader> Headers,
        Error Error
    );

    public sealed record ConsumerRecord<TKey, TValue>(
        ConsumerRecord Record,
        OptionalValue<TKey> Key,
        OptionalValue<TValue> Value
    );
}
