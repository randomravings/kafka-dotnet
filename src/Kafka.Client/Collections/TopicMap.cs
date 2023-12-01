using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal sealed class TopicMap<TValue>(
        int initialTopicCapacity
    ) :
        IReadOnlyDictionary<Topic, TValue>
    {
        private SpinLock _lock;
        private KeyValuePair<TopicId, int>[] _ids = new KeyValuePair<TopicId, int>[initialTopicCapacity];
        private KeyValuePair<TopicName, int>[] _names = new KeyValuePair<TopicName, int>[initialTopicCapacity];
        private KeyValuePair<Topic, TValue>[] _values = new KeyValuePair<Topic, TValue>[initialTopicCapacity];
        private int _count;


        internal TopicMap()
            : this(8) { }

        IEnumerable<Topic> IReadOnlyDictionary<Topic, TValue>.Keys
        {
            get
            {
                var keys = CopyKeys();
                return keys.AsEnumerable();
            }
        }

        IEnumerable<TValue> IReadOnlyDictionary<Topic, TValue>.Values
        {
            get
            {
                var values = CopyValues();
                return values.AsEnumerable();
            }
        }

        int IReadOnlyCollection<KeyValuePair<Topic, TValue>>.Count => _count;

        TValue IReadOnlyDictionary<Topic, TValue>.this[Topic key] =>
            this[key]
        ;

        bool IReadOnlyDictionary<Topic, TValue>.ContainsKey(
            Topic key
        ) => Contains(key);

        bool IReadOnlyDictionary<Topic, TValue>.TryGetValue(
            Topic key,
            [MaybeNullWhen(false)] out TValue value
        ) => Get(key, out value);

        IEnumerator<KeyValuePair<Topic, TValue>> IEnumerable<KeyValuePair<Topic, TValue>>.GetEnumerator()
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

        public TValue this[in Topic key]
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
            in Topic key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var (topicId, topicName) = key;
                var valuesIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out _, out valuesIndex))
                {
                    value = _values[valuesIndex].Value;
                    return true;
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    value = _values[valuesIndex].Value;
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

        public bool Set(
            in Topic key,
            TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (topicId, topicName) = key;
                var valuesIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out _, out valuesIndex))
                {
                    var (topic, _) = _values[valuesIndex];
                    _values[valuesIndex] = new(topic, value);
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    var (topic, _) = _values[valuesIndex];
                    _values[valuesIndex] = new(topic, value);
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
            in Topic key
        )
        {
            var lockTaken = false;
            try
            {
                var (topicId, topicName) = key;
                return !topicId.IsEmpty && GetTopic(topicId, out _, out _) ||
                    GetTopic(topicName, out _, out _)
                ;
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
            in Topic key,
            in TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (topicId, topicName) = key;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;

                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex, out valuesIndex))
                    return false;
                if (GetTopic(topicName, out nameIndex, out valuesIndex))
                    return false;
                _count++;
                valuesIndex = _count;
                Insert(ref _values, new(key, value), valuesIndex, _count);
                var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                Insert(ref _names, nameEntry, ~nameIndex, _count);
                var idEntry = new KeyValuePair<TopicId, int>(topicId, valuesIndex);
                Insert(ref _ids, idEntry, ~idIndex, _count);
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
            in Topic key,
            in TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (topicId, topicName) = key;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex, out valuesIndex))
                {
                    var (topic, _) = _values[valuesIndex];
                    _values[valuesIndex] = new(topic, value);
                    return;
                }
                if (GetTopic(topicName, out _, out valuesIndex))
                {
                    var (topic, _) = _values[valuesIndex];
                    _values[valuesIndex] = new(topic, value);
                    return;
                }
                _count++;
                valuesIndex = _count;
                Insert(ref _values, new(key, value), valuesIndex, _count);
                var nameEntry = new KeyValuePair<TopicName, int>(topicName, valuesIndex);
                Insert(ref _names, nameEntry, ~nameIndex, _count);
                if (!topicId.IsEmpty)
                {
                    var idEntry = new KeyValuePair<TopicId, int>(topicId, valuesIndex);
                    Insert(ref _ids, idEntry, ~idIndex, _count);
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
            in Topic key,
            [MaybeNullWhen(false)] out TValue value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var (topicId, topicName) = key;
                var idIndex = -1;
                var nameIndex = -1;
                var valuesIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex, out valuesIndex))
                {
                    (var tp, value) = _values[valuesIndex];
                    Remove(in _values, valuesIndex, _count);
                    Remove(in _ids, idIndex, _count);
                    if (GetTopic(tp.TopicName, out nameIndex, out _))
                        Remove(in _names, nameIndex, _count);
                    _count--;
                    return true;
                }
                if (GetTopic(topicName, out nameIndex, out valuesIndex))
                {
                    (var tp, value) = _values[valuesIndex];
                    Remove(in _values, valuesIndex, _count);
                    Remove(in _names, nameIndex, _count);
                    if (GetTopic(tp.TopicId, out idIndex, out valuesIndex))
                        Remove(in _ids, idIndex, _count);
                    _count--;
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
                _count = 0;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public ImmutableArray<Topic> CopyKeys(
            in bool sortById = false
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<Topic>(_count);
                if (sortById)
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_ids[i].Value].Key);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_names[i].Value].Key);
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
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_ids[i].Value].Value);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_names[i].Value].Value);
                return builder.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }
        public ImmutableArray<KeyValuePair<Topic, TValue>> CopyItems(
            in bool sortById = false
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<KeyValuePair<Topic, TValue>>(_count);
                if (sortById)
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_ids[i].Value]);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_values[_names[i].Value]);
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
                _count,
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
                _count,
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
    }
}
