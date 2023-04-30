using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer.Model
{
    public sealed record ProduceResult(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        Error Error,
        string RecordError
    );
}
