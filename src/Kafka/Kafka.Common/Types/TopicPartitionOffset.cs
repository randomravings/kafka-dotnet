namespace Kafka.Common.Types
{
    public readonly record struct TopicPartitionOffset(
        TopicName Topic,
        PartitionOffset PartitionOffset
    );
}
