namespace Kafka.Common.Types
{
    public readonly record struct TopicPartitionOffset(
        TopicPartition TopicPartition,
        Offset Offset
    );
}
