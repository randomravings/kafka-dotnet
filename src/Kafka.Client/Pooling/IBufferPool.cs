using Kafka.Client.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Pooling
{
    public interface IBufferPool
    {
        long Memory { get; }
        int PoolSize { get; }
        bool TryAllocateBuffer(int size, int timeoutMs, [MaybeNullWhen(false)] out byte[] buffer);
        void DeallocateBuffer(byte[] buffer);
        MemoryPoolMetrics Metrics();
    }
}
