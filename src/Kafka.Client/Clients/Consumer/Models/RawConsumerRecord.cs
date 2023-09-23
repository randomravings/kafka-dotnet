using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    public sealed record RawConsumerRecord(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        IReadOnlyList<RecordHeader> Headers,
        Error Error
    );
}
