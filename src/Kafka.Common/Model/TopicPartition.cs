namespace Kafka.Common.Model
{
    public readonly record struct TopicPartition(
        Topic Topic,
        Partition Partition
    )
    {
        public static TopicPartition Empty { get; } =
            new(
                Topic.Empty,
                Partition.Unassigned
            )
        ;

        public static implicit operator TopicPartition((Guid Id, TopicName Name, Partition Partition) v) => new((v.Id, v.Name), v.Partition);
    }
}
