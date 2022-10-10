namespace Kafka.Common
{
    public sealed record TopicPartitionOffsets(
        string Topic,
        IEnumerable<PartitionOffset> PartitionOffsets
    );
}
