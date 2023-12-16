using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record WriteResult(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        ApiError Error,
        string RecordError
    );
}
