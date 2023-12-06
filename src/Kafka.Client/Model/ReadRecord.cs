using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record ReadRecord(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        IReadOnlyList<RecordHeader> Headers,
        ApiError Error
    );

    public sealed record ReadRecord<TKey, TValue>(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        TKey Key,
        TValue Value,
        IReadOnlyList<RecordHeader> Headers
    );
}
