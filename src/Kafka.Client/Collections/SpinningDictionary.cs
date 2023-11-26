using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections
{
    internal class SpinningDictionary<TKey, TValue>(
        CompareDelegate<KeyValuePair<TKey, TValue>, TKey> compare
    ) : SpinningCollection<KeyValuePair<TKey, TValue>, TKey>(compare),
        IReadOnlyDictionary<TKey, TValue>
    {
        TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] =>
            this[key]
        ;

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys =>
            CopyKeys()
        ;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values =>
            CopyValues()
        ;

        bool IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key) =>
            Contains(key)
        ;

        bool IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) =>
            Get(key, out value)
        ;

        public TValue this[TKey key]
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

        public bool Add(in TKey key, in TValue value)
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);

                var index = IndexOf(
                    key,
                    _comparer
                );
                if (index < 0)
                {
                    Insert(~index, new(key, value));
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

        public bool Get(in TKey key, [MaybeNullWhen(false)] out TValue value)
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

        public bool Set(in TKey key, in TValue value)
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
                    _items[index] = new(key, value);
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

        public void Upsert(in TKey key, in TValue value)
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
                    _items[index] = new(key, value);
                else
                    Insert(~index, new(key, value));
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public bool Remove(in TKey key, [MaybeNullWhen(false)] out TValue value)
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
                    value = Remove(index).Value;
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

        protected TKey[] CopyKeys()
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var keys = new TKey[_count];
                for (int i = 0; i < _count; i++)
                    keys[i] = _items[i].Key;
                return keys;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        protected TValue[] CopyValues()
        {
            var lockTaken = false;
            try
            {
                _lock.TryEnter(ref lockTaken);
                var values = new TValue[_count];
                for (int i = 0; i < _count; i++)
                    values[i] = _items[i].Value;
                return values;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }
    }
}
