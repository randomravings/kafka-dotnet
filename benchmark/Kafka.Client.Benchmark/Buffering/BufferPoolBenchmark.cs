using BenchmarkDotNet.Attributes;
using Kafka.Client.Clients.Producer;
using Microsoft.Extensions.Logging.Abstractions;
using System.Buffers;

namespace Kafka.Client.Benchmark.Buffering
{
    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    public class BufferPoolBenchmark
    {
        [Params(4)]
        public int ThreadCount { get; set; }
        
        [Params(100)]
        public int PassesPerThread { get; set; }

        [Params(1024, 32767, 1048576)]
        public int BufferSize { get; set; }

        private ArrayPool<byte> _arrayPool = ArrayPool<byte>.Create(1, 1);
        private IBufferPool _bufferPoolOnTarget = BufferPool.Create(1, 1, NullLogger.Instance);
        private IBufferPool _bufferPoolOffTarget = BufferPool.Create(1, 1, NullLogger.Instance);

        [IterationSetup]
        public void Setup()
        {
            _arrayPool = ArrayPool<byte>.Create(BufferSize * (ThreadCount + 1), BufferSize);
            _bufferPoolOnTarget = BufferPool.Create(BufferSize * (ThreadCount + 1), BufferSize, NullLogger.Instance);
            _bufferPoolOffTarget = BufferPool.Create(BufferSize * (ThreadCount + 1), BufferSize + 1, NullLogger.Instance);
        }

        [Benchmark]
        public async Task<long> SystemArrayPool()
        {
            var workers = Enumerable.Range(0, 4).Select(i => CreatePoolTask(_arrayPool, BufferSize, PassesPerThread));
            await Task.WhenAll(workers).ConfigureAwait(false);
            return workers.Sum(r => r.Result);
        }

        [Benchmark]
        public async Task<long> PooledOnTarget()
        {
            var workers = Enumerable.Range(0, 4).Select(i => CreatePoolTask(_bufferPoolOnTarget, BufferSize, PassesPerThread));
            await Task.WhenAll(workers).ConfigureAwait(false);
            return workers.Sum(r => r.Result);
        }

        [Benchmark]
        public async Task<long> PooledOffTarget()
        {
            var workers = Enumerable.Range(0, 4).Select(i => CreatePoolTask(_bufferPoolOffTarget, BufferSize, PassesPerThread));
            await Task.WhenAll(workers).ConfigureAwait(false);
            return workers.Sum(r => r.Result);
        }

        [Benchmark]
        public async Task<long> Default()
        {
            var workers = Enumerable.Range(0, 4).Select(i => CreatePoolTask(BufferSize, PassesPerThread));
            await Task.WhenAll(workers).ConfigureAwait(false);
            return workers.Sum(r => r.Result);
        }

        private static Task<long> CreatePoolTask(ArrayPool<byte> pool, int requestSize, int passes) =>
            Task.Run(() =>
                DoWork(pool, requestSize, passes)
            )
        ;

        private static Task<long> CreatePoolTask(IBufferPool pool, int requestSize, int passes) =>
            Task.Run(() =>
                DoWork(pool, requestSize, passes)
            )
        ;

        private static Task<long> CreatePoolTask(int requestSize, int passes) =>
            Task.Run(() =>
                DoWork(requestSize, passes)
            )
        ;

        private static long DoWork(int requestSize, int passes)
        {
            var v = 0L;
            for (int i = 0; i < passes; i++)
            {
                var buffer = new byte[requestSize];
                v += WorkOnArray(buffer);
            }
            return v;
        }

        private static long DoWork(ArrayPool<byte> pool, int requestSize, int passes)
        {
            var v = 0L;
            for (int i = 0; i < passes; i++)
            {
                var buffer = pool.Rent(requestSize);
                v += WorkOnArray(buffer);
                pool.Return(buffer);
            }
            return v;
        }

        private static long DoWork(IBufferPool pool, int requestSize, int passes)
        {
            var v = 0L;
            for (int i = 0; i < passes; i++)
            {
                pool.TryAllocateBuffer(requestSize, 1000, out var buffer);
                v += WorkOnArray(buffer);
                pool.DeallocateBuffer(buffer);
            }
            return v;
        }

        private static long WorkOnArray(byte[] buffer)
        {
            var v = 0L;
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(i % byte.MaxValue);
                v += buffer[i];
            }
            return v;
        }
    }
}
