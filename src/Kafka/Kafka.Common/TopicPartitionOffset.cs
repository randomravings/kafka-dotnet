namespace Kafka.Common
{
    public sealed record TopicPartitionOffset(
        string Topic,
        PartitionOffset PartitionOffset
    );
}
