namespace Kafka.Client.Model
{
    public readonly record struct MemoryPoolMetrics(
        long UsedMemory,
        long AvailableMemory,
        long AvailablePooledMemory
    );
}
