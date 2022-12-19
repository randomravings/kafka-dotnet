namespace Kafka.Common.Types
{
    public readonly record struct TopicPartition(
        TopicName Topic,
        Partition Partition
    );
}
