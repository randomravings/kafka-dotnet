using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Client.Collections
{
    /// <summary>
    /// A sorted collection on a key.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="comparer"></param>
    internal abstract class SpinningCollection<TType, TKey>(
        CompareDelegate<TType, TKey> comparer,
        int initialCapacity
    ) : IReadOnlyCollection<TType>
    {
        private protected readonly CompareDelegate<TType, TKey> _comparer = comparer;
        private protected SpinLock _lock;
        private protected TType[] _items = new TType[initialCapacity];
        private protected int _count;

        internal SpinningCollection(
            CompareDelegate<TType, TKey> comparer
        ) : this(comparer, 16) { }

        int IReadOnlyCollection<TType>.Count => _count;

        IEnumerator<TType> IEnumerable<TType>.GetEnumerator() =>
            CopyItems().AsEnumerable().GetEnumerator()
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            CopyItems().AsEnumerable().GetEnumerator()
        ;

        public int Count => _count;

        /// <summary>
        /// Checks if the key is present in the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(in TKey key)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var index = IndexOf(
                    key,
                    _comparer
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
        /// Removes a keyed item from the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(in TKey key)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var index = IndexOf(
                    key,
                    _comparer
                );
                if (index >= 0)
                {
                    Remove(index);
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

        /// <summary>
        /// Returns an array containing items in sorted order.
        /// </summary>
        /// <returns></returns>
        public ImmutableArray<TType> CopyItems()
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                return ImmutableArray.Create(_items, 0, _count);
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        protected int IndexOf(
            in TKey key,
            in CompareDelegate<TType, TKey> comparer
        )
        {
            var i = 0;
            var l = 0;
            var r = _count;
            while (l < r)
            {
                i = l + ((r - l) / 2);
                var c = comparer(key, _items[i]);
                switch (c)
                {
                    case 0:
                        return i;
                    case 1:
                        i++;
                        l = i;
                        break;
                    default:
                        r = i;
                        break;
                }
            }
            return ~i;
        }

        protected void Insert(in int index, in TType value)
        {
            if (_count == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = value;
            _count++;
        }

        protected TType Remove(in int index)
        {
            _count--;
            var item = _items[index];
            Array.Copy(_items, index + 1, _items, index, _count - index);
            return item;
        }

        protected void CopyTo(TType[] items, int start)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                Array.Copy(_items, 0, items, start, _count);
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }
    }
}
