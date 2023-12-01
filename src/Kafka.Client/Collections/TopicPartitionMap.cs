using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal sealed class TopicPartitionMap<TValue>(
        int initialTopicCapacity,
        int initialPartitionCapacity
    ) :
        IReadOnlyDictionary<TopicPartition, TValue>
    {
        private readonly int _initialPartitionCapacity = initialPartitionCapacity;

        private SpinLock _lock;
        private KeyValuePair<TopicId, int>[] _ids = new KeyValuePair<TopicId, int>[initialTopicCapacity];
        private KeyValuePair<TopicName, int>[] _names = new KeyValuePair<TopicName, int>[initialTopicCapacity];
        private PartitionValues[] _values = new PartitionValues[initialTopicCapacity];
        private int _topicCount;
        private int _count;

        private sealed class PartitionValues
        {
            public static PartitionValues Empty { get; } = new();
            public int Length;
            public KeyValuePair<TopicPartition, TValue>[] Items = [];
        };

        internal TopicPartitionMap()
            : this(8, 16) { }

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
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var ((topicId, topicName), partition) = key;
                var valuesIndex = -1;
                var values = PartitionValues.Empty;
                if (!topicId.IsEmpty && GetTopic(topicId, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var partitionIndex, out _))
                    {
                        value = values.Items[partitionIndex].Value;
                        return true;
                    }
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var partitionIndex, out _))
                    {
                        value = values.Items[partitionIndex].Value;
                        return true;
                    }
                }
                return false;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public bool Set(
            in TopicPartition key,
            TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var ((topicId, topicName), partition) = key;
                var valuesIndex = -1;
                var values = PartitionValues.Empty;
                if (!topicId.IsEmpty && GetTopic(topicId, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var partitionIndex, out _))
                    {
                        var (tp, _) = values.Items[partitionIndex];
                        values.Items[partitionIndex] = new(tp, value);
                        return true;
                    }
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var partitionIndex, out _))
                    {
                        var (tp, _) = values.Items[partitionIndex];
                        values.Items[partitionIndex] = new(tp, value);
                        return true;
                    }
                }
                return false;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
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
            var lockTaken = false;
            try
            {
                var ((topicId, topicName), partition) = key;
                var valuesIndex = -1;
                var values = PartitionValues.Empty;
                if (!topicId.IsEmpty && GetTopic(topicId, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var _, out _))
                        return true;
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out var _, out _))
                        return true;
                }
                return false;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
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
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var ((topicId, topicName), partition) = key;
                var values = PartitionValues.Empty;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;
                var partitionIndex = -1;
                if (GetTopic(topicName, out nameIndex, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out partitionIndex, out _))
                        return false;
                    values.Length++;
                    Insert(ref values.Items, new(key, value), ~partitionIndex, values.Length);
                }
                else
                {
                    valuesIndex = _topicCount;
                    values = new PartitionValues
                    {
                        Length = 1,
                        Items = new KeyValuePair<TopicPartition, TValue>[_initialPartitionCapacity]
                    };
                    values.Items[0] = new(key, value);
                    if (topicId.IsEmpty)
                    {
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    else
                    {
                        _ = GetTopic(topicId, out idIndex, out _);
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                        var idEntry = new KeyValuePair<TopicId, int>(topicId, valuesIndex);
                        Insert(ref _ids, idEntry, ~idIndex, _topicCount);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    Insert(ref _values, values, valuesIndex, _topicCount);
                }
                _count++;
                return true;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
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
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var ((topicId, topicName), partition) = key;
                var values = PartitionValues.Empty;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;
                var partitionIndex = -1;
                if (GetTopic(topicName, out nameIndex, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (GetPartition(values, partition, out partitionIndex, out _))
                    {
                        var (tp, _) = _values[valuesIndex].Items[partitionIndex];
                        _values[valuesIndex].Items[partitionIndex] = new(tp, value);
                    }
                    else
                    {
                        values.Length++;
                        Insert(ref values.Items, new(key, value), ~partitionIndex, values.Length);
                    }
                }
                else
                {
                    valuesIndex = _topicCount;
                    values = new PartitionValues
                    {
                        Length = 1,
                        Items = new KeyValuePair<TopicPartition, TValue>[_initialPartitionCapacity]
                    };
                    values.Items[0] = new(key, value);
                    if (topicId.IsEmpty)
                    {
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    else
                    {
                        _ = GetTopic(topicId, out idIndex, out _);
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                        var idEntry = new KeyValuePair<TopicId, int>(topicId, valuesIndex);
                        Insert(ref _ids, idEntry, ~idIndex, _topicCount);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    Insert(ref _values, values, valuesIndex, _topicCount);
                }
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
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
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var ((topicId, topicName), partition) = key;
                var values = PartitionValues.Empty;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;
                var partitionIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (!GetPartition(values, partition, out partitionIndex, out value))
                        return false;
                    if (values.Length > 1)
                    {
                        Remove(in values.Items, valuesIndex, values.Length);
                        values.Length--;
                        return true;
                    }
                    else
                    {
                        Remove(in _values, valuesIndex, _count);
                        Remove(in _ids, idIndex, _topicCount);
                        if (GetTopic(topicName, out nameIndex, out _))
                            Remove(in _names, nameIndex, _topicCount);
                        _topicCount--;
                        _count--;
                    }
                }
                if (!topicName.IsEmpty || GetTopic(topicName, out nameIndex, out valuesIndex))
                {
                    values = _values[valuesIndex];
                    if (!GetPartition(values, partition, out partitionIndex, out value))
                        return false;
                    if (values.Length > 1)
                    {
                        Remove(in values.Items, valuesIndex, values.Length);
                        values.Length--;
                        return true;
                    }
                    else
                    {
                        Remove(in _values, valuesIndex, _count);
                        Remove(in _names, nameIndex, _topicCount);
                        if (GetTopic(topicId, out idIndex, out _))
                            Remove(in _ids, idIndex, _topicCount);
                        _topicCount--;
                        _count--;
                    }
                }
                return false;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                Array.Clear(_ids);
                Array.Clear(_names);
                Array.Clear(_values);
                _topicCount = 0;
                _count = 0;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public ImmutableArray<TopicPartition> CopyKeys(
            in bool sortById = false
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<TopicPartition>(_count);
                if (sortById)
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_ids[i].Value].Length; j++)
                            builder.Add(_values[_ids[i].Value].Items[j].Key);
                else
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_names[i].Value].Length; j++)
                            builder.Add(_values[_names[i].Value].Items[j].Key);
                return builder.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public ImmutableArray<TValue> CopyValues(
            in bool sortById = false
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<TValue>(_count);
                if (sortById)
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_ids[i].Value].Length; j++)
                            builder.Add(_values[_ids[i].Value].Items[j].Value);
                else
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_names[i].Value].Length; j++)
                            builder.Add(_values[_names[i].Value].Items[j].Value);
                return builder.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }
        public ImmutableArray<KeyValuePair<TopicPartition, TValue>> CopyItems(
            in bool sortById = false
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<KeyValuePair<TopicPartition, TValue>>(_count);
                if (sortById)
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_ids[i].Value].Length; j++)
                            builder.Add(_values[_ids[i].Value].Items[j]);
                else
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _values[_names[i].Value].Length; j++)
                            builder.Add(_values[_names[i].Value].Items[j]);
                return builder.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        private bool GetTopic(
            in TopicId topicId,
            out int index,
            out int valuesIndex
        )
        {
            index = Compare.IndexOf(
                _ids,
                topicId,
                _topicCount,
                CompareTopicId
            );
            if (index >= 0)
            {
                var entry = _ids[index];
                valuesIndex = entry.Value;
                return true;
            }
            else
            {
                valuesIndex = -1;
                return false;
            }
        }

        private bool GetTopic(
            in TopicName topicName,
            out int index,
            out int valuesIndex
        )
        {
            index = Compare.IndexOf(
                _names,
                topicName,
                _topicCount,
                CompareTopicName
            );
            if (index >= 0)
            {
                var entry = _names[index];
                valuesIndex = entry.Value;
                return true;
            }
            else
            {
                valuesIndex = -1;
                return false;
            }
        }

        private static bool GetPartition(
            in PartitionValues values,
            in Partition key,
            out int index,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            index = Compare.IndexOf(
                values.Items,
                key,
                values.Length,
                ComparePartitionValue
            );
            if (index >= 0)
            {
                value = values.Items[index].Value;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        private static void Insert<TItem>(
            ref TItem[] array,
            in TItem topicPartition,
            in int index,
            in int size
        )
        {
            if (size >= array.Length)
                Array.Resize(ref array, array.Length * 2);
            Array.Copy(array, index, array, index + 1, size - index);
            array[index] = topicPartition;
        }

        private static TItem Remove<TItem>(
            in TItem[] array,
            in int index,
            in int size
        )
        {
            var item = array[index];
            Array.Copy(array, index + 1, array, index, size - index);
            return item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CompareTopicId(in KeyValuePair<TopicId, int> item, in TopicId key) =>
            item.Key.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CompareTopicName(in KeyValuePair<TopicName, int> item, in TopicName key) =>
            Math.Sign(string.CompareOrdinal(item.Key.Value, key.Value))
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ComparePartitionValue(in KeyValuePair<TopicPartition, TValue> item, in Partition key) =>
            item.Key.Partition.Value.CompareTo(key.Value)
        ;
    }
}
