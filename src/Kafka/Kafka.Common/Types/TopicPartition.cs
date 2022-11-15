namespace Kafka.Common.Types
{
    public readonly record struct TopicPartition(
        Topic Topic,
        Partition Partition
    );
}
