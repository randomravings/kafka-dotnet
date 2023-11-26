using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Client.Collections
{
    internal sealed class TopicSet(
        int initialCapacity
    ) :
        IReadOnlyCollection<Topic>
    {
        private SpinLock _lock;
        private Topic[] _ids = new Topic[initialCapacity];
        private Topic[] _names = new Topic[initialCapacity];
        private int _count;

        int IReadOnlyCollection<Topic>.Count => _count;

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

        public TopicSet()
            : this(16) { }

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

                var (idIndex, nameIndex) = IndexOf(
                    key
                );
                return idIndex >= 0 || nameIndex >= 0;
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
        public bool Add(in Topic key)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var (idIndex, nameIndex) = IndexOf(
                    key
                );
                if (idIndex < 0 || nameIndex >= 0)
                {
                    Insert(ref _ids, key, ~idIndex, _count);
                    Insert(ref _names, key, ~nameIndex, _count);
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

                var (idIndex, nameIndex) = IndexOf(
                    key
                );
                if (idIndex >= 0 || nameIndex >= 0)
                {
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

        public ImmutableArray<Topic> CopyItems()
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var builder = ImmutableArray.CreateBuilder<Topic>(_count);
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
                var idCompare = Compare.TopicById(key, idValue);
                var nameValue = _names[nameIndex];
                var nameCompare = Compare.TopicByName(key, nameValue);
                switch ((idCompare, nameCompare))
                {
                    case (0, _):
                        return new(idIndex, nameIndex);
                    case (_, 0):
                        return new(idIndex, nameIndex);
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
            return new(~idIndex, ~nameIndex);
        }

        private static void Insert(
            ref Topic[] array,
            in Topic topicPartition,
            in int index,
            in int size
        )
        {
            if (index >= array.Length)
                Array.Resize(ref array, array.Length * 2);
            Array.Copy(array, index, array, index + 1, size - index);
            array[index] = topicPartition;
        }

        private static Topic Remove(
            in Topic[] array,
            in int index,
            in int size
        )
        {
            var item = array[index];
            Array.Copy(array, index + 1, array, index, size - index);
            return item;
        }

        private readonly record struct Indices(
            int IdIndex,
            int NameIndex
        );
    }
}
