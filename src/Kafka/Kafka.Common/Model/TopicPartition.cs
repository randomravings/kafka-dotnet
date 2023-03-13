namespace Kafka.Common.Model
{
    public readonly record struct TopicPartition(
        TopicName Topic,
        Partition Partition
    )
    {
        public static TopicPartition Empty { get; } =
            new(
                TopicName.Empty,
                Partition.Unassigned
            )
        ;
    }
}
