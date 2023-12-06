using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record ProduceResult(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        ApiError Error,
        string RecordError
    );
}
