using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal sealed class TopicSet(
        int initialTopicCapacity
    ) :
        IReadOnlyCollection<Topic>
    {
        private SpinLock _lock;
        private Topic[] _names = new Topic[initialTopicCapacity];
        private Topic[] _ids = new Topic[initialTopicCapacity];
        private int _count;

        int IReadOnlyCollection<Topic>.Count => _count;

        public int Count => _count;

        IEnumerator<Topic> IEnumerable<Topic>.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var items = CopyItems();
            return items.AsEnumerable().GetEnumerator();
        }

        internal TopicSet()
            : this(8) { }

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(
            in Topic key,
            [MaybeNullWhen(false)] out Topic value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                value = default;
                var (topicId, topicName) = key;
                var index = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out index))
                {
                    value = _ids[index];
                    return true;
                }
                if (GetTopic(topicName, out index))
                {
                    value = _names[index];
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
                if (!topicId.IsEmpty && GetTopic(topicId, out _))
                    return true;
                if (GetTopic(topicName, out _))
                    return true;
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
            in Topic key
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (topicId, topicName) = key;
                var idIndex = -1;
                var nameIndex = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex))
                    return false;
                if (GetTopic(topicName, out nameIndex))
                    return true;
                _count++;
                Insert(ref _ids, key, ~idIndex, _count);
                Insert(ref _names, key, ~nameIndex, _count);
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
            in Topic key,
            [MaybeNullWhen(false)] out Topic value
        )
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var idIndex = -1;
                var nameIndex = -1;
                value = default;
                var (topicId, topicName) = key;
                var index = -1;
                if (!topicId.IsEmpty && GetTopic(topicId, out idIndex))
                {
                    value = _ids[index];
                    Remove(_ids, idIndex, _count);
                    if (GetTopic(value.TopicName, out nameIndex))
                        Remove(_names, nameIndex, _count);
                    _count--;
                    return true;
                }
                if (GetTopic(topicName, out nameIndex))
                {
                    value = _names[index];
                    Remove(_names, nameIndex, _count);
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
                _count = 0;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public ImmutableArray<Topic> CopyItems(
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
                        builder.Add(_ids[i]);
                else
                    for (int i = 0; i < _count; i++)
                        builder.Add(_names[i]);
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
            out int index
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
                return true;
            }
            else
            {
                index = -1;
                return false;
            }
        }

        private bool GetTopic(
            in TopicName topicName,
            out int index
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
                return true;
            }
            else
            {
                index = -1;
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
        private static int CompareTopicId(in Topic item, in TopicId key) =>
            item.TopicId.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CompareTopicName(in Topic item, in TopicName key) =>
            Math.Sign(string.CompareOrdinal(item.TopicName.Value, key.Value))
        ;
    }
}
