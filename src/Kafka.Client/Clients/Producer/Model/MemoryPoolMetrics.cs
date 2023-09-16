namespace Kafka.Client.Clients.Producer.Model
{
    public readonly record struct MemoryPoolMetrics(
        long UsedMemory,
        long AvailableMemory,
        long AvailablePooledMemory
    );
}
