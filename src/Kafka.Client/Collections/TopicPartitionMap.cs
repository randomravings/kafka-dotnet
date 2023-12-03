using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections
{
    internal sealed class TopicPartitionMap<TValue>(
        int initialTopicCapacity
    ) :
        IReadOnlyDictionary<TopicPartition, TValue>
    {
        private readonly object _guard = new ();
        private KeyValuePair<TopicPartition, MapValue<TopicPartition, TValue>>[] _ids =
            new KeyValuePair<TopicPartition, MapValue<TopicPartition, TValue>>[initialTopicCapacity];
        private MapValue<TopicPartition, TValue>[] _values =
            new MapValue<TopicPartition, TValue>[initialTopicCapacity];
        private int _count;

        internal TopicPartitionMap()
            : this(8) { }

        IEnumerable<TopicPartition> IReadOnlyDictionary<TopicPartition, TValue>.Keys
        {
            get
            {
                var keys = CopyKeys();
                return keys.AsEnumerable();
            }
        }

        IEnumerable<TValue> IReadOnlyDictionary<TopicPartition, TValue>.Values
        {
            get
            {
                var values = CopyValues();
                return values.AsEnumerable();
            }
        }

        int IReadOnlyCollection<KeyValuePair<TopicPartition, TValue>>.Count => _count;

        TValue IReadOnlyDictionary<TopicPartition, TValue>.this[TopicPartition key] =>
            this[key]
        ;

        bool IReadOnlyDictionary<TopicPartition, TValue>.ContainsKey(
            TopicPartition key
        ) => Contains(key);

        bool IReadOnlyDictionary<TopicPartition, TValue>.TryGetValue(
            TopicPartition key,
            [MaybeNullWhen(false)] out TValue value
        ) => Get(key, out value);

        IEnumerator<KeyValuePair<TopicPartition, TValue>> IEnumerable<KeyValuePair<TopicPartition, TValue>>.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        public int Count => _count;

        public TValue this[in TopicPartition key]
        {
            get
            {
                if (Get(key, out var value))
                    return value;
                else
                    throw new KeyNotFoundException(key.ToString());
            }
            set
            {
                if (!Set(key, value))
                    throw new KeyNotFoundException(key.ToString());
            }
        }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(
            in TopicPartition key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            Monitor.Enter(_guard);
            try
            {
                if (LookupId(key, out var idIndex))
                {
                    value = _ids[idIndex].Value.Value;
                    return true;
                }
                else if (LookupName(key, out var valuesIndex))
                {
                    value = _values[valuesIndex].Value;
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
                Monitor.Exit(_guard);
            }
        }

        public bool Set(
            in TopicPartition key,
            TValue value
        )
        {
            Monitor.Enter(_guard);
            try
            {
                if (LookupId(key, out var idIndex))
                {
                    _ids[idIndex].Value.Value = value;
                    return true;
                }
                else if (LookupName(key, out var valuesIndex))
                {
                    _values[valuesIndex].Value = value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(
            in TopicPartition key
        )
        {
            Monitor.Enter(_guard);
            try
            {

                if (LookupId(key, out _))
                    return true;
                else if (LookupName(key, out _))
                    return true;
                else
                    return false;
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        /// <summary>
        /// Adds a new value to the topic partition collection.
        /// Important: If topic ids are used anywhere subsequently then it
        /// important to add values using both topic name and id.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Add(
            in TopicPartition key,
            in TValue value
        )
        {
            Monitor.Enter(_guard);
            try
            {

                if (LookupId(key, out var idIndex))
                    return false;
                if (LookupName(key, out var valuesIndex))
                    return false;
                _count++;
                var entry = new MapValue<TopicPartition, TValue>(key, value);
                ArrayOperations.Insert(ref _values, entry, ~valuesIndex, _count);
                if (!key.Topic.TopicId.IsEmpty)
                    ArrayOperations.Insert(ref _ids, new(key, entry), ~idIndex, _count);
                return true;
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        /// <summary>
        /// Adds or upates a value to the topic partition collection.
        /// Important: If topic ids are used anywhere subsequently then it
        /// important to add values using both topic name and id.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Upsert(
            in TopicPartition key,
            in TValue value
        )
        {
            Monitor.Enter(_guard);
            try
            {

                if (LookupId(key, out var idIndex))
                {
                    _ids[idIndex].Value.Value = value;
                }
                else if (LookupName(key, out var valuesIndex))
                {
                    _values[valuesIndex].Value = value;
                }
                else
                {
                    _count++;
                    var entry = new MapValue<TopicPartition, TValue>(key, value);
                    ArrayOperations.Insert(ref _values, entry, ~valuesIndex, _count);
                    if (!key.Topic.TopicId.IsEmpty)
                        ArrayOperations.Insert(ref _ids, new(key, entry), ~idIndex, _count);
                }
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        /// <summary>
        /// Removes a keyed item from the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(
            in TopicPartition key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            Monitor.Enter(_guard);
            try
            {

                value = default;
                if (LookupId(key, out var idIndex))
                {
                    var entry = _ids[idIndex];
                    value = entry.Value.Value;
                    ArrayOperations.Remove(_ids, idIndex, _count);
                    if(LookupName(entry.Value.Key, out var valuesIndex))
                        ArrayOperations.Remove(_values, idIndex, _count);
                    _count--;
                    return true;
                }
                else if (LookupName(key, out var valuesIndex))
                {
                    var entry = _values[valuesIndex];
                    value = entry.Value;
                    ArrayOperations.Remove(_values, valuesIndex, _count);
                    if (LookupId(entry.Key, out idIndex))
                        ArrayOperations.Remove(_ids, idIndex, _count);
                    _count--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            Monitor.Enter(_guard);
            try
            {
                Array.Clear(_ids);
                Array.Clear(_values);
                Array.Clear(_values);
                _count = 0;
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        public ImmutableArray<TopicPartition> CopyKeys(
            in bool sortById = false
        )
        {
            Monitor.Enter(_guard);
            try
            {
                var builder = ImmutableArray.CreateBuilder<TopicPartition>(_count);
                if (sortById)
                    for (int i = 0; i < _count; i++)
                        builder.Add(_ids[i].Value.Key);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[i].Key);
                return builder.ToImmutable();
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        public ImmutableArray<TValue> CopyValues(
            in bool sortById = false
        )
        {
            Monitor.Enter(_guard);
            try
            {
                var builder = ImmutableArray.CreateBuilder<TValue>(_count);
                if (sortById)
                    for (int i = 0; i < _count; i++)
                        builder.Add(_ids[i].Value.Value);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[i].Value);
                return builder.ToImmutable();
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }
        public ImmutableArray<KeyValuePair<TopicPartition, TValue>> CopyItems(
            in bool sortById = false
        )
        {
            Monitor.Enter(_guard);
            try
            {
                var builder = ImmutableArray.CreateBuilder<KeyValuePair<TopicPartition, TValue>>(_count);
                if (sortById)
                    for (int i = 0; i < _count; i++)
                        builder.Add(new(_ids[i].Value.Key, _ids[i].Value.Value));
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(new(_values[i].Key, _values[i].Value));
                return builder.ToImmutable();
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        private bool LookupId(
            in TopicPartition key,
            out int idIndex
        )
        {
            idIndex = -1;
            if (key.Topic.TopicId.IsEmpty)
                return false;
            idIndex = ArrayOperations.BinaryIndexOf(
                _ids,
                key,
                _count,
                Compare.CompareTopicId
            );
            return idIndex >= 0;
        }

        private bool LookupName(
            in TopicPartition topicName,
            out int valuesIndex
        )
        {
            valuesIndex = ArrayOperations.BinaryIndexOf(
                _values,
                topicName,
                _count,
                Compare.CompareTopicName
            );
            return valuesIndex >= 0;
        }
    }
}
