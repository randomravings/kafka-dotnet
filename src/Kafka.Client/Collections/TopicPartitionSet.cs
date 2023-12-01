using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal sealed class TopicPartitionSet(
        int initialTopicCapacity,
        int initialPartitionCapacity
    ) :
        IReadOnlyCollection<TopicPartition>
    {
        private readonly int _initialPartitionCapacity = initialPartitionCapacity;

        private SpinLock _lock;
        private KeyValuePair<TopicId, int>[] _ids = new KeyValuePair<TopicId, int>[initialTopicCapacity];
        private KeyValuePair<TopicName, int>[] _names = new KeyValuePair<TopicName, int>[initialTopicCapacity];
        private PartitionValues[] _topicPartitions = new PartitionValues[initialTopicCapacity];
        private int _topicCount;
        private int _count;

        private sealed class PartitionValues
        {
            public static PartitionValues Empty { get; } = new();
            public int Length;
            public TopicPartition[] Items = [];
        };

        int IReadOnlyCollection<TopicPartition>.Count => _count;

        public int Count => _count;

        IEnumerator<TopicPartition> IEnumerable<TopicPartition>.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        internal TopicPartitionSet()
            : this(8, 16) { }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(
            in TopicPartition key,
            [MaybeNullWhen(false)] out TopicPartition value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var ((topicId, topicName), partition) = key;
                var topicIndex = -1;
                var values = PartitionValues.Empty;
                if (topicId.IsEmpty && GetTopic(topicName, out _, out topicIndex) || GetTopic(topicId, out _, out topicIndex))
                {
                    values = _topicPartitions[topicIndex];
                    return GetPartition(values, partition, out _, out value);
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
                var topicIndex = -1;
                var values = PartitionValues.Empty;
                if (topicId.IsEmpty && GetTopic(topicName, out _, out topicIndex) || GetTopic(topicId, out _, out topicIndex))
                {
                    values = _topicPartitions[topicIndex];
                    return GetPartition(values, partition, out _, out _);
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
            in TopicPartition key
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
                var topicIndex = -1;
                var partitionIndex = -1;
                if (GetTopic(topicName, out nameIndex, out topicIndex))
                {
                    values = _topicPartitions[topicIndex];
                    if (GetPartition(values, partition, out partitionIndex, out _))
                        return false;
                    values.Length++;
                    Insert(ref values.Items, key, ~partitionIndex, values.Length);
                }
                else
                {
                    topicIndex = _topicCount;
                    values = new PartitionValues
                    {
                        Length = 1,
                        Items = new TopicPartition[_initialPartitionCapacity]
                    };
                    values.Items[0] = key;
                    if (topicId.IsEmpty)
                    {
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, topicIndex);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    else
                    {
                        _ = GetTopic(topicId, out idIndex, out _);
                        _topicCount++;
                        var nameEntry = new KeyValuePair<TopicName, int>(topicName, topicIndex);
                        var idEntry = new KeyValuePair<TopicId, int>(topicId, topicIndex);
                        Insert(ref _ids, idEntry, ~idIndex, _topicCount);
                        Insert(ref _names, nameEntry, ~nameIndex, _topicCount);
                    }
                    Insert(ref _topicPartitions, values, topicIndex, _topicCount);
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
        /// Removes a keyed item from the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(
            in TopicPartition key,
            [MaybeNullWhen(false)] out TopicPartition value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = TopicPartition.Empty;
                var ((topicId, topicName), partition) = key;
                var values = PartitionValues.Empty;
                var idIndex = -1;
                var nameIndex = -1;
                var topicIndex = -1;
                var partitionIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex, out topicIndex))
                {
                    values = _topicPartitions[topicIndex];
                    if (!GetPartition(values, partition, out partitionIndex, out value))
                        return false;
                    if (values.Length > 1)
                    {
                        Remove(in values.Items, topicIndex, values.Length);
                        values.Length--;
                        return true;
                    }
                    else
                    {
                        Remove(in _topicPartitions, topicIndex, _count);
                        Remove(in _ids, idIndex, _topicCount);
                        if (GetTopic(topicName, out nameIndex, out _))
                            Remove(in _names, nameIndex, _topicCount);
                        _topicCount--;
                        _count--;
                    }
                }
                if (!topicName.IsEmpty || GetTopic(topicName, out nameIndex, out topicIndex))
                {
                    values = _topicPartitions[topicIndex];
                    if (!GetPartition(values, partition, out partitionIndex, out value))
                        return false;
                    if (values.Length > 1)
                    {
                        Remove(in values.Items, topicIndex, values.Length);
                        values.Length--;
                        return true;
                    }
                    else
                    {
                        Remove(in _topicPartitions, topicIndex, _count);
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
                _count = 0;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public ImmutableArray<TopicPartition> CopyItems(
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
                        for (int j = 0; j < _topicPartitions[_ids[i].Value].Length; j++)
                            builder.Add(_topicPartitions[_ids[i].Value].Items[j]);
                else
                    for (int i = 0; i < _topicCount; i++)
                        for (int j = 0; j < _topicPartitions[_names[i].Value].Length; j++)
                            builder.Add(_topicPartitions[_names[i].Value].Items[j]);
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
            out int topicIndex
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
                topicIndex = entry.Value;
                return true;
            }
            else
            {
                topicIndex = -1;
                return false;
            }
        }

        private bool GetTopic(
            in TopicName topicName,
            out int index,
            out int topicIndex
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
                topicIndex = entry.Value;
                return true;
            }
            else
            {
                topicIndex = -1;
                return false;
            }
        }

        private static bool GetPartition(
            in PartitionValues values,
            in Partition key,
            out int index,
            [MaybeNullWhen(false)] out TopicPartition value
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
                value = values.Items[index];
                return true;
            }
            else
            {
                value = TopicPartition.Empty;
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
        private static int ComparePartitionValue(in TopicPartition item, in Partition key) =>
            item.Partition.Value.CompareTo(key.Value)
        ;
    }
}
