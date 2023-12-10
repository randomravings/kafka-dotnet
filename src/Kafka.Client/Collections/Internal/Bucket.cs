using Kafka.Client.Pooling;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections.Internal
{
    internal sealed class Bucket<Tkey, TValue>(
        IObjectPool<BucketEntry<Tkey, TValue>> objectPool,
        IKeyCompare<Tkey> keyCompare
    ) : IEnumerable<KeyValuePair<Tkey, TValue>>
    {
        private readonly object _lock = new();
        private readonly IObjectPool<BucketEntry<Tkey, TValue>> _objectPool = objectPool;
        private readonly IKeyCompare<Tkey> _keyCompare = keyCompare;
        private readonly BucketEntry<Tkey, TValue> _head = new();

        private static BucketEntry<Tkey, TValue> NewBucketItem() =>
            new()
        ;

        public bool Add(in Tkey key, in TValue value, [MaybeNullWhen(false)] out BucketEntry<Tkey, TValue> entry)
        {
            Monitor.Enter(_lock);
            try
            {
                if (GetEntry(key, out var predecessor, out entry))
                    return false;
                if (_objectPool.TryAllocate(NewBucketItem, out var newEntry))
                {
                    newEntry.Bucket = this;
                    newEntry.KeyValue = new(key, value);
                    newEntry.Next = entry;
                    predecessor.Next = newEntry;
                    entry = newEntry;
                    return true;
                }
                return false;
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        public bool AddOrSet(in Tkey key, in TValue value)
        {
            Monitor.Enter(_lock);
            try
            {
                if (GetEntry(key, out var predecessor, out var entry))
                {
                    entry.KeyValue = new(entry.KeyValue.Key, value);
                    return true;
                }
                else
                {
                    if (_objectPool.TryAllocate(NewBucketItem, out var newEntry))
                    {
                        newEntry.Bucket = this;
                        newEntry.KeyValue = new(key, value);
                        newEntry.Next = entry;
                        predecessor.Next = newEntry;
                        return true;
                    }
                }
                return false;
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        public bool Get(in Tkey key, [MaybeNullWhen(false)] out TValue value)
        {
            Monitor.Enter(_lock);
            try
            {
                if (GetEntry(key, out _, out var entry))
                {
                    value = entry.KeyValue.Value;
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        public bool Set(in Tkey key, TValue value)
        {
            Monitor.Enter(_lock);
            try
            {
                if (GetEntry(key, out _, out var entry))
                {
                    entry.KeyValue = new(entry.KeyValue.Key, value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        public bool Remove(Tkey key, [MaybeNullWhen(false)] out BucketEntry<Tkey, TValue> value)
        {
            Monitor.Enter(_lock);
            try
            {
                if (GetEntry(key, out var predecessor, out var entry))
                {
                    value = entry;
                    var successor = entry.Next;
                    predecessor.Next = successor;
                    _objectPool.Deallocate(entry);
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        private bool GetEntry(
            in Tkey key,
            out BucketEntry<Tkey, TValue> predecessor,
            [MaybeNullWhen(false)] out BucketEntry<Tkey, TValue> entry
        )
        {
            predecessor = _head;
            entry = _head.Next;
            while (true)
            {
                if (entry == null)
                    return false;
                var direction = _keyCompare.Compare(entry.KeyValue.Key, key);
                switch (direction)
                {
                    case 0:
                        return true;
                    case 1:
                        return false;
                    default:
                        predecessor = entry;
                        entry = entry.Next;
                        break;
                }
            }
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            Monitor.Enter(_lock);
            try
            {
                var entry = _head.Next;
                while (entry != null)
                {
                    yield return entry.KeyValue;
                    entry = entry.Next;
                }
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Monitor.Enter(_lock);
            try
            {
                var entry = _head.Next;
                while (entry != null)
                {
                    yield return entry.KeyValue;
                    entry = entry.Next;
                }
            }
            finally
            {
                if (Monitor.IsEntered(_lock))
                    Monitor.Exit(_lock);
            }
        }
    }
}
