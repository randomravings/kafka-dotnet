namespace Kafka.Common.Model
{
    public readonly record struct PartitionOffset(
        Partition Partition,
        Offset Offset
    );
}
