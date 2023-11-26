using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections
{
    internal sealed class TopicDictionary<TValue>(
        int initialCapacity
    ) :
        IReadOnlyDictionary<Topic, TValue>
    {
        private SpinLock _lock;
        private KeyValuePair<Topic, int>[] _ids = new KeyValuePair<Topic, int>[initialCapacity];
        private KeyValuePair<Topic, int>[] _names = new KeyValuePair<Topic, int>[initialCapacity];
        private KeyValuePair<Topic, TValue>[] _items = new KeyValuePair<Topic, TValue>[initialCapacity];
        private int _count;

        public TopicDictionary()
            : this(16) { }

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

        bool IReadOnlyDictionary<Topic, TValue>.ContainsKey(Topic key) =>
            Contains(key)
        ;

        bool IReadOnlyDictionary<Topic, TValue>.TryGetValue(Topic key, [MaybeNullWhen(false)] out TValue value) =>
            Get(key, out value)
        ;

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
                    throw new KeyNotFoundException();
            }
            set
            {
                Upsert(key, value);
            }
        }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(in Topic key)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, _, _) = IndexOf(
                    key
                );
                return index >= 0;
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
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(in Topic key, in TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, idIndex, nameIndex) = IndexOf(
                    key
                );
                if (index < 0)
                {
                    Insert(ref _items, key, _count, _count, value);
                    Insert(ref _ids, key, ~idIndex, _count, _count);
                    Insert(ref _names, key, ~nameIndex, _count, _count);
                    _count++;
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

        public bool Get(in Topic key, [MaybeNullWhen(false)] out TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, _, _) = IndexOf(
                    key
                );
                if (index >= 0)
                {
                    value = _items[index].Value;
                    return true;
                }

                value = default;
                return false;

            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public bool Set(in Topic key, in TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, _, _) = IndexOf(
                    key
                );
                if (index >= 0)
                {
                    var (topicPartition, _) = _items[index];
                    _items[index] = new(topicPartition, value);
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
        /// Adds or upates a value to the topic partition collection.
        /// Important: If topic ids are used anywhere subsequently then it
        /// important to add values using both topic name and id.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Upsert(in Topic key, in TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, idIndex, nameIndex) = IndexOf(
                    key
                );
                if (index >= 0)
                {
                    var (topicPartition, _) = _items[index];
                    _items[index] = new(topicPartition, value);
                }
                else
                {
                    Insert(ref _items, key, _count, _count, value);
                    Insert(ref _ids, key, ~idIndex, _count, _count);
                    Insert(ref _names, key, ~nameIndex, _count, _count);
                    _count++;
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
        public bool Remove(in Topic key)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, idIndex, nameIndex) = IndexOf(
                    key
                );
                if (index >= 0)
                {
                    var (topicPartition, _) = _items[index];
                    _ = Remove(_items, index, _count).Value;
                    _ = Remove(_ids, idIndex, _count);
                    _ = Remove(_names, nameIndex, _count);
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

        public bool Remove(in Topic key, [MaybeNullWhen(false)] out TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (index, idIndex, nameIndex) = IndexOf(
                    key
                );
                if (index >= 0)
                {
                    var (topicPartition, _) = _items[index];
                    value = Remove(_items, index, _count).Value;
                    _ = Remove(_ids, idIndex, _count);
                    _ = Remove(_names, nameIndex, _count);
                    _count--;
                    return true;
                }

                value = default;
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

        /// <summary>
        /// Returns keys in sorted order.
        /// </summary>
        /// <returns></returns>
        public ImmutableArray<Topic> CopyKeys(bool sortById = false)
        {
            var keys = sortById ? _ids : _names;
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var values = ImmutableArray.CreateBuilder<Topic>(_count);
                for (int i = 0; i < _count; i++)
                    values.Add(keys[i].Key);
                return values.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        /// <summary>
        /// Returns values in sorted order.
        /// </summary>
        /// <returns></returns>
        public ImmutableArray<TValue> CopyValues(bool sortById = false)
        {
            var keys = sortById ? _ids : _names;
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var values = ImmutableArray.CreateBuilder<TValue>(_count);
                for (int i = 0; i < _count; i++)
                    values.Add(_items[keys[i].Value].Value);
                return values.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        /// <summary>
        /// Returns items in sorted order.
        /// </summary>
        /// <returns></returns>
        public ImmutableArray<KeyValuePair<Topic, TValue>> CopyItems(bool sortById = false)
        {
            var keys = sortById ? _ids : _names;
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var values = ImmutableArray.CreateBuilder<KeyValuePair<Topic, TValue>>(_count);
                for (int i = 0; i < _count; i++)
                    values.Add(_items[keys[i].Value]);
                return values.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        private Indices IndexOf(
            in Topic key
        )
        {
            var idIndex = 0;
            var idLeftOffset = 0;
            var idRightOffset = _count;
            var nameIndex = 0;
            var nameLeftOffset = 0;
            var nameRightOffset = _count;
            while (idLeftOffset < idRightOffset)
            {
                idIndex = idLeftOffset + ((idRightOffset - idLeftOffset) / 2);
                nameIndex = nameLeftOffset + ((nameRightOffset - nameLeftOffset) / 2);
                var idValue = _ids[idIndex];
                var idCompare = Compare.TopicById(key, idValue.Key);
                var nameValue = _names[nameIndex];
                var nameCompare = Compare.TopicByName(key, nameValue.Key);
                switch ((idCompare, nameCompare))
                {
                    case (0, _):
                        return new(idValue.Value, idIndex, nameIndex);
                    case (_, 0):
                        return new(nameValue.Value, idIndex, nameIndex);
                    case (1, 1):
                        idIndex++;
                        nameIndex++;
                        idLeftOffset = idIndex;
                        nameLeftOffset = nameIndex;
                        break;
                    case (1, -1):
                        idIndex++;
                        idLeftOffset = idIndex;
                        nameRightOffset = nameIndex;
                        break;
                    case (-1, 1):
                        nameIndex++;
                        idRightOffset = idIndex;
                        nameLeftOffset = nameIndex;
                        break;
                    case (-1, -1):
                        idRightOffset = idIndex;
                        nameRightOffset = nameIndex;
                        break;
                }
            }
            return new(-1, ~idIndex, ~nameIndex);
        }

        private static void Insert<T>(
            ref KeyValuePair<Topic, T>[] array,
            in Topic topicPartition,
            in int index,
            in int size,
            in T value
        )
        {
            if (index >= array.Length)
                Array.Resize(ref array, array.Length * 2);
            Array.Copy(array, index, array, index + 1, size - index);
            array[index] = new(topicPartition, value);
        }

        private static KeyValuePair<Topic, T> Remove<T>(
            in KeyValuePair<Topic, T>[] array,
            in int index,
            in int size
        )
        {
            var item = array[index];
            Array.Copy(array, index + 1, array, index, size - index);
            return item;
        }

        private readonly record struct Indices(
            int ValueIndex,
            int IdIndex,
            int NameIndex
        );
    }
}
