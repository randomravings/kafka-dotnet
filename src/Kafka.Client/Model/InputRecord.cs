using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record InputRecord(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        IReadOnlyList<RecordHeader> Headers,
        Error Error
    );
}
