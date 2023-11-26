using Kafka.Client.Model;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Kafka.Client.IO.Stream
{
    internal sealed class BufferPool :
        IBufferPool
    {
        private static readonly byte[] EMPTY = Array.Empty<byte>();

        private readonly long _memory;          // Maximum memory that can be allocated.
        private readonly int _poolableMemory;   // Size of poolable buffers.
        private readonly Queue<byte[]> _pool;   // allocated unused pooled buffers.
        private readonly ILogger _logger;

        private long _allocatedMemory;  // Total allocated memory pooled and unpooled.

        public int _pendingAllocations;

        private readonly AutoResetEvent _semaphore;

        private readonly Stopwatch _clock = Stopwatch.StartNew();

        private SpinLock _spinLock;

        public static IBufferPool Create(
            long memory,
            int poolableSize,
            ILogger logger
        )
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(memory, nameof(memory));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(poolableSize, nameof(memory));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(poolableSize, memory, nameof(poolableSize));
            var maxPoolCount = (int)Math.Ceiling((double)memory / poolableSize);
            return new BufferPool(memory, poolableSize, maxPoolCount, logger);
        }

        private BufferPool(
            long memory,
            int poolableSize,
            int maxPoolCount,
            ILogger logger
        )
        {
            _memory = memory;
            _poolableMemory = poolableSize;
            _logger = logger;
            _pool = new(maxPoolCount);
            _semaphore = new(false);
        }

        long IBufferPool.Memory => _memory;

        int IBufferPool.PoolSize => _poolableMemory;

        bool IBufferPool.TryAllocateBuffer(int size, int timeoutMs, out byte[] buffer)
        {
            buffer = EMPTY;
            if (size > _memory)
                return false;

            var start = _clock.Elapsed;
            var timeout = TimeSpan.FromMilliseconds(timeoutMs);

            while (true)
            {
                bool lockTaken = false;
                try
                {
                    _spinLock.Enter(ref lockTaken);
                    if (_allocatedMemory + size <= _memory)
                    {
                        buffer = (size == _poolableMemory) switch
                        {
                            true => GetPooledMemory(),
                            _ => GetNonPooledMemory(size)
                        };
                        _allocatedMemory += buffer.LongLength;
                        return true;
                    }
                }
                finally
                {
                    if (lockTaken)
                        _spinLock.Exit(false);
                }

                var remainingTimeout = timeout - (_clock.Elapsed - start);
                if (remainingTimeout <= TimeSpan.Zero || !_semaphore.WaitOne(remainingTimeout))
                    return false;
            }
        }

        void IBufferPool.DeallocateBuffer(byte[] buffer)
        {
            bool lockTaken = false;
            try
            {
                _spinLock.Enter(ref lockTaken);
                if (buffer.Length == _poolableMemory)
                    _pool.Enqueue(buffer);
                _allocatedMemory -= buffer.LongLength;
            }
            finally
            {
                if (lockTaken)
                    _spinLock.Exit(false);
            }
            // We've just freed up some memory, so release the semaphore
            _semaphore.Set();
        }

        MemoryPoolMetrics IBufferPool.Metrics()
        {
            bool lockTaken = false;
            try
            {
                _spinLock.Enter(ref lockTaken);
                return new(
                    UsedMemory: _allocatedMemory,
                    AvailableMemory: _memory - _allocatedMemory,
                    AvailablePooledMemory: _poolableMemory * _pool.Count
                );
            }
            finally
            {
                if (lockTaken) _spinLock.Exit(false);
            }
        }

        private byte[] GetPooledMemory() =>
            _pool switch
            {
                { Count: 0 } => new byte[_poolableMemory],
                _ => _pool.Dequeue()
            }
        ;

        private byte[] GetNonPooledMemory(int size)
        {
            while (UnreservedSpace() < size)
                _pool.Dequeue();
            return new byte[size];
        }

        public long UnreservedSpace() =>
            _memory - (_allocatedMemory + (_poolableMemory * _pool.Count))
        ;


        void IDisposable.Dispose()
        {
            _semaphore.Dispose();
        }
    }
}