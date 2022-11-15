namespace Kafka.Common.Types
{
    public readonly record struct TopicPartitionOffset(
        Topic Topic,
        PartitionOffset PartitionOffset
    );
}
