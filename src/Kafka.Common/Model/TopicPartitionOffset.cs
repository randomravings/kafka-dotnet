namespace Kafka.Common.Model
{
    public readonly record struct TopicPartitionOffset(
        TopicPartition TopicPartition,
        Offset Offset
    )
    {
        public static TopicPartitionOffset Empty { get; } =
            new(
                TopicPartition.Empty,
                Offset.Unset
            )
        ;
    }
}
