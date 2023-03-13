namespace Kafka.Common.Model
{
    public readonly record struct TopicPartitionOffset(
        TopicPartition TopicPartition,
        Offset Offset
    );
}
