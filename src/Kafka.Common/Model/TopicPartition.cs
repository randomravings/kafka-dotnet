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

        public static implicit operator TopicPartition((
            Guid Id,
            TopicName Name,
            Partition Partition
        ) value) => new(
            new(
                value.Id,
                value.Name
            ),
            value.Partition
        );

        public static TopicPartition FromValueTuple((
            TopicName Name,
            Partition Partition
        ) value) => new(
            new(
                TopicId.Empty,
                value.Name
            ),
            value.Partition
        );

        public static TopicPartition FromValueTuple((
            Guid Id,
            Partition Partition
        ) value) => new(
            new(
                value.Id,
                TopicName.Empty
            ),
            value.Partition
        );

        public static TopicPartition FromValueTuple((
            Guid Id,
            TopicName Name,
            Partition Partition
        ) value) => new(
            new(
                value.Id,
                value.Name
            ),
            value.Partition
        );
    }
}
