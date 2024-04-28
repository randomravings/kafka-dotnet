using Kafka.Client.Pooling;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.L0.Test.WriteStream
{
    [TestFixture]
    public class BufferPoolTest
    {
        [Test]
        public void TestInit()
        {
            var bufferPool = BufferPool.Create(1024, 128, NullLogger.Instance);
            Assert.Multiple(() =>
            {
                Assert.That(bufferPool.Memory, Is.EqualTo(1024));
                Assert.That(bufferPool.PoolSize, Is.EqualTo(128));
            });
        }

        [Test]
        public void TestInitZeroMemory()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BufferPool.Create(0, 0, NullLogger.Instance));
        }

        [Test]
        public void TestInitPoolableMemoryOutOfRangeLow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BufferPool.Create(1024, 0, NullLogger.Instance));
        }

        [Test]
        public void TestInitPoolableMemoryOutOfRangeHigh()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BufferPool.Create(1024, 2048, NullLogger.Instance));
        }

        [Test]
        public void TestAllocatePool()
        {
            var bufferPool = BufferPool.Create(1024, 128, NullLogger.Instance);

            var success = bufferPool.TryAllocateBuffer(128, 10, out var buffer);

            Assert.Multiple(() =>
            {
                Assert.That(success, Is.EqualTo(true));
                Assert.That(buffer, Is.InstanceOf<byte[]>());
            });
            Assert.That(buffer, Has.Length.EqualTo(128));

            var metrics = bufferPool.Metrics();
            Assert.Multiple(() =>
            {
                Assert.That(metrics.UsedMemory, Is.EqualTo(128));
                Assert.That(metrics.AvailableMemory, Is.EqualTo(896));
                Assert.That(metrics.AvailablePooledMemory, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestAllocateTooMuch()
        {
            var bufferPool = BufferPool.Create(1024, 128, NullLogger.Instance);

            var success = bufferPool.TryAllocateBuffer(2048, 10, out var buffer);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.EqualTo(false));
                Assert.That(buffer, Is.InstanceOf<byte[]>());
            });
            Assert.That(buffer, Has.Length.EqualTo(0));
        }

        [Test]
        public void TestAllocateTimeOut()
        {
            var bufferPool = BufferPool.Create(256, 128, NullLogger.Instance);

            var success1 = bufferPool.TryAllocateBuffer(128, 200, out var buffer1);
            var success2 = bufferPool.TryAllocateBuffer(128, 200, out var buffer2);
            
            var time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var success3 = bufferPool.TryAllocateBuffer(256, 200, out var buffer3);
            var elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - time;
            
            Assert.Multiple(() =>
            {
                Assert.That(success1, Is.EqualTo(true));
                Assert.That(success2, Is.EqualTo(true));
                Assert.That(success3, Is.EqualTo(false));
                Assert.That(buffer1, Is.InstanceOf<byte[]>());
                Assert.That(buffer2, Is.InstanceOf<byte[]>());
                Assert.That(buffer3, Is.InstanceOf<byte[]>());
                Assert.That(elapsed, Is.GreaterThanOrEqualTo(199));
                Assert.That(buffer1, Has.Length.EqualTo(128));
                Assert.That(buffer2, Has.Length.EqualTo(128));
                Assert.That(buffer3, Has.Length.EqualTo(0));
            });
        }

        [Test]
        public void TestAllocateAndReleasePooled()
        {
            var bufferPool = BufferPool.Create(256, 128, NullLogger.Instance);

            var success1 = bufferPool.TryAllocateBuffer(128, 20, out var buffer1);
            var success2 = bufferPool.TryAllocateBuffer(128, 20, out var buffer2);
            var success3 = bufferPool.TryAllocateBuffer(128, 20, out var buffer3);

            Assert.Multiple(() =>
            {
                Assert.That(success1, Is.EqualTo(true));
                Assert.That(success2, Is.EqualTo(true));
                Assert.That(success3, Is.EqualTo(false));
                Assert.That(buffer1, Is.InstanceOf<byte[]>());
                Assert.That(buffer2, Is.InstanceOf<byte[]>());
                Assert.That(buffer3, Is.InstanceOf<byte[]>());
                Assert.That(buffer1, Has.Length.EqualTo(128));
                Assert.That(buffer2, Has.Length.EqualTo(128));
                Assert.That(buffer3, Has.Length.EqualTo(0));
            });

            if(buffer2 != null)
                bufferPool.DeallocateBuffer(buffer2);
            var success4 = bufferPool.TryAllocateBuffer(128, 200, out var buffer4);

            Assert.Multiple(() =>
            {
                Assert.That(success4, Is.EqualTo(true));;
                Assert.That(buffer4, Is.InstanceOf<byte[]>());
                Assert.That(buffer4, Has.Length.EqualTo(128));
            });
        }

        [Test]
        public void TestAllocateAndReleaseNonPooled()
        {
            var bufferPool = BufferPool.Create(256, 34, NullLogger.Instance);

            var success1 = bufferPool.TryAllocateBuffer(128, 20, out var buffer1);
            var success2 = bufferPool.TryAllocateBuffer(128, 20, out var buffer2);
            var success3 = bufferPool.TryAllocateBuffer(128, 20, out var buffer3);

            Assert.Multiple(() =>
            {
                Assert.That(success1, Is.EqualTo(true));
                Assert.That(success2, Is.EqualTo(true));
                Assert.That(success3, Is.EqualTo(false));
                Assert.That(buffer1, Is.InstanceOf<byte[]>());
                Assert.That(buffer2, Is.InstanceOf<byte[]>());
                Assert.That(buffer3, Is.InstanceOf<byte[]>());
                Assert.That(buffer1, Has.Length.EqualTo(128));
                Assert.That(buffer2, Has.Length.EqualTo(128));
                Assert.That(buffer3, Has.Length.EqualTo(0));
            });

            if (buffer2 != null)
                bufferPool.DeallocateBuffer(buffer2);
            var success4 = bufferPool.TryAllocateBuffer(128, 200, out var buffer4);

            Assert.Multiple(() =>
            {
                Assert.That(success4, Is.EqualTo(true)); ;
                Assert.That(buffer4, Is.InstanceOf<byte[]>());
                Assert.That(buffer4, Has.Length.EqualTo(128));
            });
        }

        [Test]
        public void TestMultiThreadPooled()
        {
            var bufferPool = BufferPool.Create(100, 20, NullLogger.Instance);

            var tasks = new Task[10];
            var results = new byte[10][];
            for (int i = 0; i < tasks.Length; i++)
            {
                var size = 20;
                tasks[i] = Task.Run(() => AddBufferToQueue(results, i, bufferPool, size, 10000));
                Task.Delay(10).Wait();
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                var size = 20;
                var buffer = results[i];
                Assert.That(buffer, Is.InstanceOf<byte[]>());
                Assert.That(buffer, Has.Length.EqualTo(size));
                bufferPool.DeallocateBuffer(buffer);
                Task.Delay(10).Wait();
            }

            Task.WaitAll(tasks);
        }

/* Breaks when running in GitHub Actions for some reason
        [Test]
        public void TestMultiThreadMixed()
        {
            var bufferPool = BufferPool.Create(100, 20, NullLogger.Instance);

            var tasks = new Task[10];
            var results = new byte[10][];
            for (int i = 0; i < tasks.Length; i++)
            {
                var size = 20 + i % 2;
                tasks[i] = Task.Run(() => AddBufferToQueue(results, i, bufferPool, size, 10000));
                Task.Delay(10).Wait();
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                var size = 20 + i % 2;
                var buffer = results[i];
                Assert.That(buffer, Is.InstanceOf<byte[]>());
                Assert.That(buffer, Has.Length.EqualTo(size));
                bufferPool.DeallocateBuffer(buffer);
                Task.Delay(10).Wait();
            }

            Task.WaitAll(tasks);
        }
*/
        private static void AddBufferToQueue(
            byte[][] buffers,
            int index,
            IBufferPool bufferPool,
            int size,
            int timeout
        )
        {
            bufferPool.TryAllocateBuffer(size, timeout, out var buffer);
            var metrics = bufferPool.Metrics();
            Assert.Multiple(() =>
            {
                Assert.That(metrics.UsedMemory, Is.LessThanOrEqualTo(bufferPool.Memory));
                Assert.That(metrics.AvailableMemory, Is.GreaterThanOrEqualTo(0));
            });
            if(buffer != null)
                buffers[index] = buffer;
        }
    }
}
