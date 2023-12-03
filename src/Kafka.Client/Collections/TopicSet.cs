using Kafka.Common.Model;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections
{
    internal sealed class TopicSet(
        int initialTopicCapacity
    ) :
        IReadOnlyCollection<Topic>
    {
        private readonly object _guard = new();
        private Topic[] _names =
            new Topic[initialTopicCapacity];
        private Topic[] _ids =
            new Topic[initialTopicCapacity];
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
            Monitor.Enter(_guard);
            try
            {
                var index = -1;
                if (LookupId(key, out index))
                {
                    value = _ids[index];
                    return true;
                }
                else if (LookupName(key, out index))
                {
                    value = _names[index];
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

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(
            in Topic key
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
            in Topic key
        )
        {
            Monitor.Enter(_guard);
            try
            {
                var idIndex = -1;
                var nameIndex = -1;
                if (LookupId(key, out idIndex))
                    return false;
                if (LookupName(key, out nameIndex))
                    return false;
                _count++;
                if (!key.TopicId.IsEmpty)
                    ArrayOperations.Insert(ref _ids, key, ~idIndex, _count);
                if (!key.TopicName.IsEmpty)
                    ArrayOperations.Insert(ref _names, key, ~nameIndex, _count);
                return true;
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
            in Topic key,
            [MaybeNullWhen(false)] out Topic value
        )
        {
            Monitor.Enter(_guard);
            try
            {
                var idIndex = -1;
                var nameIndex = -1;
                value = Topic.Empty;
                if (!LookupId(key, out idIndex) & !LookupName(key, out nameIndex))
                {
                    return false;
                }
                else
                {
                    if (idIndex >= 0)
                    {
                        value = _ids[idIndex];
                        ArrayOperations.Remove(_ids, idIndex, _count);
                    }
                    if (nameIndex >= 0)
                    {
                        value = _ids[idIndex];
                        ArrayOperations.Remove(_names, nameIndex, _count);
                    }
                    return true;
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
                Array.Clear(_names);
                _count = 0;
            }
            finally
            {
                Monitor.Exit(_guard);
            }
        }

        public ImmutableArray<Topic> CopyItems(
            in bool sortById = false
        )
        {
            Monitor.Enter(_guard);
            try
            {
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
                Monitor.Exit(_guard);
            }
        }

        private bool LookupId(
            in Topic key,
            out int index
        )
        {
            index = 1;
            if (key.TopicId.IsEmpty)
                return false;
            index = ArrayOperations.BinaryIndexOf(
                _ids,
                key,
                _count,
                Compare.CompareId
            );
            return index >= 0;
        }

        private bool LookupName(
            in Topic key,
            out int index
        )
        {
            index = ArrayOperations.BinaryIndexOf(
                _names,
                key,
                _count,
                Compare.CompareName
            );
            return index >= 0;
        }
    }
}
