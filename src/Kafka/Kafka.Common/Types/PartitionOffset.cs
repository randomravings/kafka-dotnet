namespace Kafka.Common.Types
{
    public readonly record struct PartitionOffset(
        Partition Partition,
        Offset Offset
    );
}
