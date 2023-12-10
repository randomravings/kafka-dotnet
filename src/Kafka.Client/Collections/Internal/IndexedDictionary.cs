using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Kafka.Client.Pooling;

namespace Kafka.Client.Collections.Internal
{
    public sealed class IndexedDictionary<TKey, TValue> :
        IReadOnlyDictionary<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly IKeyCompare<TKey> _entryCompare;
        private readonly IKeyCompare<TKey> _indexCompare;
        private readonly Bucket<TKey, TValue>[] _entryBuckets;
        private readonly Bucket<TKey, BucketEntry<TKey, TValue>>[] _indexBuckets;
        private int _count;

        private readonly IObjectPool<BucketEntry<TKey, TValue>> _entryPool = new ObjectPool<BucketEntry<TKey, TValue>>(int.MaxValue);
        private readonly IObjectPool<BucketEntry<TKey, BucketEntry<TKey, TValue>>> _indexPool = new ObjectPool<BucketEntry<TKey, BucketEntry<TKey, TValue>>>(int.MaxValue);

        public IndexedDictionary(
            int capacity,
            IKeyCompare<TKey> entryCompare,
            IKeyCompare<TKey> indexCompare
        )
        {
            _capacity = capacity;
            _entryCompare = entryCompare;
            _indexCompare = indexCompare;
            _entryBuckets = new Bucket<TKey, TValue>[capacity];
            _indexBuckets = new Bucket<TKey, BucketEntry<TKey, TValue>>[capacity];
            Clear();
        }

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
        {
            get
            {
                foreach (var bucket in _entryBuckets)
                    foreach (var entry in bucket)
                        yield return entry.Key;
            }
        }

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
        {
            get
            {
                foreach (var bucket in _entryBuckets)
                    foreach (var entry in bucket)
                        yield return entry.Value;
            }
        }

        int IReadOnlyCollection<KeyValuePair<TKey, TValue>>.Count => _count;

        TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] =>
            this[key]
        ;

        bool IReadOnlyDictionary<TKey, TValue>.ContainsKey(
            TKey key
        ) => Contains(key);

        bool IReadOnlyDictionary<TKey, TValue>.TryGetValue(
            TKey key,
            [MaybeNullWhen(false)] out TValue value
        ) => Get(key, out value);

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            foreach (var bucket in _entryBuckets)
                foreach (var entry in bucket)
                    yield return entry;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var bucket in _entryBuckets)
                foreach (var entry in bucket)
                    yield return entry;
        }

        public int Count => _count;

        public TValue this[in TKey key]
        {
            get
            {
                if (Get(key, out var value))
                    return value;
                else
                    throw new KeyNotFoundException();
            }
            set
            {
                if (!Set(key, value))
                    throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Adds a new value to the topic partition collection.
        /// Important: If topic ids are used anywhere subsequently then it
        /// important to add values using both topic name and id.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If topic name is null or empty.</exception>
        public bool Add(
            in TKey key,
            in TValue value
        )
        {
            if (!_entryCompare.IsValid(key))
                throw new ArgumentException("Entry key not valid", nameof(key));
            var valueBucket = GetValuesBucket(key);
            if (!valueBucket.Add(key, value, out var entry))
                return false;
            if (_indexCompare.IsValid(key))
            {
                var indexBucket = GetIndexBucket(key);
                indexBucket.AddOrSet(key, entry);
            }
            Interlocked.Increment(ref _count);
            return true;
        }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(
            in TKey key
        )
        {
            if (_indexCompare.IsValid(key))
            {
                var indexBucket = GetIndexBucket(key);
                return indexBucket.Get(key, out _);
            }
            else
            {
                var valueBucket = GetValuesBucket(key);
                return valueBucket.Get(key, out _);
            }
        }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(
            in TKey key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            if (_indexCompare.IsValid(key))
            {
                var indexBucket = GetIndexBucket(key);
                if (indexBucket.Get(key, out var entryBucket))
                    return entryBucket.Bucket.Get(entryBucket.KeyValue.Key, out value);
            }
            var valueBucket = GetValuesBucket(key);
            return valueBucket.Get(key, out value);
        }

        public bool Set(
            in TKey key,
            in TValue value
        )
        {
            if (_indexCompare.IsValid(key))
            {
                var indexBucket = GetIndexBucket(key);
                if (indexBucket.Get(key, out var entryBucket))
                    return entryBucket.Bucket.Set(entryBucket.KeyValue.Key, value);
            }
            var valueBucket = GetValuesBucket(key);
            return valueBucket.Set(key, value);
        }

        /// <summary>
        /// Adds or upates a value to the topic partition collection.
        /// Important: If topic ids are used anywhere subsequently then it
        /// important to add values using both topic name and id.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If topic name is null or empty if adding.</exception>
        public bool AddOrSet(
            in TKey key,
            in TValue value
        )
        {
            var validIndex = _indexCompare.IsValid(key);
            var indexBucket = GetIndexBucket(key);
            if (validIndex)
            {
                indexBucket = GetIndexBucket(key);
                if (indexBucket.Get(key, out var entryBucket))
                    return entryBucket.Bucket.Set(entryBucket.KeyValue.Key, value);
            }

            var validEntry = _entryCompare.IsValid(key);
            var valueBucket = GetValuesBucket(key);

            if (validEntry)
            {
                if (valueBucket.Set(key, value))
                    return true;
            }
            else
            {
                throw new ArgumentException("Entry key not valid", nameof(key));
            }

            if (!valueBucket.Add(key, value, out var entry))
                return false;

            if (validIndex)
                indexBucket.AddOrSet(key, entry);
            Interlocked.Increment(ref _count);
            return true;
        }

        /// <summary>
        /// Removes a keyed item from the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(
            in TKey key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            if (_indexCompare.IsValid(key))
            {
                var indexBucket = GetIndexBucket(key);
                if (indexBucket.Remove(key, out var entry))
                {
                    value = entry.KeyValue.Value.KeyValue.Value;
                    Interlocked.Decrement(ref _count);
                    return entry.Bucket.Remove(entry.KeyValue.Key, out _);
                }
            }
            if(_entryCompare.IsValid(key))
            {
                var valueBucket = GetValuesBucket(key);
                if (valueBucket.Remove(key, out var entry))
                {
                    value = entry.KeyValue.Value;
                    Interlocked.Decrement(ref _count);
                    var indexBucket = GetIndexBucket(key);
                    return indexBucket.Remove(entry.KeyValue.Key, out _);
                }
            }
            value = default;
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < _capacity; i++)
            {
                _entryBuckets[i] = new Bucket<TKey, TValue>(_entryPool, _entryCompare);
                _indexBuckets[i] = new Bucket<TKey, BucketEntry<TKey, TValue>>(_indexPool, _indexCompare);
            }
        }

        private Bucket<TKey, BucketEntry<TKey, TValue>> GetIndexBucket(
            in TKey key
        )
        {
            var hash = _indexCompare.GetHashCode(key) & 0x7FFFFFFF;
            var mod = hash % _capacity;
            return _indexBuckets[mod];
        }

        private Bucket<TKey, TValue> GetValuesBucket(
            in TKey key
        )
        {
            var hash = _entryCompare.GetHashCode(key) & 0x7FFFFFFF;
            var mod = hash % _capacity;
            return _entryBuckets[mod];
        }
    }
}
