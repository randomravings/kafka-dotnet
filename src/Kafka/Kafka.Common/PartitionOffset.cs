namespace Kafka.Common
{
    public readonly struct PartitionOffset
    {
        public PartitionOffset(
            Partition partition,
            Offset offset
        )
        {
            Partition = partition;
            Offset = offset;
        }
        public readonly Partition Partition { get; }
        public readonly Offset Offset { get; }
    }
}
