using Kafka.Client.Model;

namespace Kafka.Client.IO
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
