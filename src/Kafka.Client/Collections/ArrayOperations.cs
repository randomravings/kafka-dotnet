namespace Kafka.Client.Collections
{
    internal static class ArrayOperations
    {
        /// <summary>
        /// Performs a binary search and returns the index of element with the key.
        /// If the key is not present then a binary two complimentary index
        /// is returned to indicate the position where it can be inserted.
        /// </summary>
        /// <typeparam name="TItem">Array type.</typeparam>
        /// <typeparam name="TKey">Key type.</typeparam>
        /// <param name="array">A sorted array of unique elements.</param>
        /// <param name="key">The key to search for.</param>
        /// <param name="size">Number of elements in the array.</param>
        /// <param name="compare">Compare delegate that matches the search key with the element key.</param>
        /// <returns></returns>
        internal static int BinaryIndexOf<TItem, TKey>(
            in TItem[] array,
            in TKey key,
            in int size,
            in CompareKey<TItem, TKey> compare
        )
        {
            var i = 0;
            var l = 0;
            var r = size;
            while (l < r)
            {
                i = l + (r - l) / 2;
                var value = array[i];
                var direction = compare(value, key);
                switch (direction)
                {
                    case 0:
                        return i;
                    case 1:
                        r = i;
                        break;
                    default:
                        i++;
                        l = i;
                        break;
                }
            }
            return ~i;
        }

        internal static void Insert<TItem>(
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

        internal static TItem Remove<TItem>(
            in TItem[] array,
            in int index,
            in int size
        )
        {
            var item = array[index];
            Array.Copy(array, index + 1, array, index, size - index);
            return item;
        }
    }
}