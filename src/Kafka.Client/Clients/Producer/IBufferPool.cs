using Kafka.Client.Clients.Producer.Model;

namespace Kafka.Client.Clients.Producer
{
    public interface IBufferPool :
        IDisposable
    {
        long Memory { get; }
        int PoolSize { get; }
        bool TryAllocateBuffer(int size, int timeoutMs, out byte[] buffer);
        void DeallocateBuffer(byte[] buffer);
        MemoryPoolMetrics Metrics();
    }
}
