namespace Kafka.Common
{
    public sealed record TopicPartition(
        string Topic,
        Partition Partition
    );
}
