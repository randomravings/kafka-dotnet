using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Pooling
{
    internal sealed class ObjectPool<TType>(
        int capacity
    ) : IObjectPool<TType>
    {
        private readonly int _capacity = capacity;
        private int _count;
        private int _pooledCount;
        private SpinLock _lock;
        private readonly Queue<TType> _pool = new();

        int IObjectPool<TType>.PoolSize
        {
            get
            {
                var lockTaken = false;
                _lock.Enter(ref lockTaken);
                try
                {
                    return _pooledCount;
                }
                finally
                {
                    if (lockTaken)
                        _lock.Exit();
                }
            }
        }

        bool IObjectPool<TType>.TryAllocate(Func<TType> initializer, [MaybeNullWhen(false)] out TType item)
        {
            var lockTaken = false;
            _lock.Enter(ref lockTaken);
            try
            {
                item = default;
                if (_count >= _capacity)
                    return false;
                _count++;
                if (_pool.TryDequeue(out item))
                {
                    _pooledCount--;
                }
                else
                {
                    item = initializer();
                }
                return true;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit();
            }
        }

        void IObjectPool<TType>.Deallocate(in TType item)
        {
            var lockTaken = false;
            _lock.Enter(ref lockTaken);
            try
            {
                if (_count <= 0)
                    return;
                _pool.Enqueue(item);
                _pooledCount++;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit();
            }
        }

        void IObjectPool<TType>.Clear()
        {
            var lockTaken = false;
            _lock.Enter(ref lockTaken);
            try
            {
                _count = 0;
                _pooledCount = 0;
                _pool.Clear();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit();
            }
        }
    }
}