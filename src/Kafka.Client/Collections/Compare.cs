using Kafka.Common.Model;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal static class Compare
    {
        internal static int IndexOf<TItem, TKey>(
            in TItem[] topicPartitions,
            in TKey key,
            in int limit,
            in CompareDelegate<TItem, TKey> compare
        )
        {
            var index = 0;
            var itemOffset = 0;
            var keyOffset = limit;
            while (itemOffset < keyOffset)
            {
                index = itemOffset + ((keyOffset - itemOffset) / 2);
                var value = topicPartitions[index];
                var direction = compare(value, key);
                switch (direction)
                {
                    case 0:
                        return index;
                    case 1:
                        keyOffset = index;
                        break;
                    default:
                        index++;
                        itemOffset = index;
                        break;
                }
            }
            return ~index;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionById(in TopicPartition item, in TopicPartition key) =>
            TopicById(item.Topic, key.Topic) switch
            {
                0 => Partition(item.Partition, key.Partition),
                var c => c
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionById<TValue>(in KeyValuePair<TopicPartition, TValue> item, in TopicPartition key) =>
            TopicById(item.Key.Topic, key.Topic) switch
            {
                0 => Partition(item.Key.Partition, key.Partition),
                var c => c
            }
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionByName(in TopicPartition item, in TopicPartition key) =>
            TopicByName(item.Topic, key.Topic) switch
            {
                0 => Partition(item.Partition, key.Partition),
                var c => c
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionByName<TValue>(in KeyValuePair<TopicPartition, TValue> item, in TopicPartition key) =>
            TopicByName(item.Key.Topic, key.Topic) switch
            {
                0 => Partition(item.Key.Partition, key.Partition),
                var c => c
            }
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicById(in Topic item, in Topic key) =>
            TopicId(item.TopicId, key.TopicId)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicById<TValue>(in KeyValuePair<Topic, TValue> item, in Topic key) =>
            TopicId(item.Key.TopicId, key.TopicId)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicByName(in Topic item, in Topic key) =>
            TopicName(item.TopicName, key.TopicName)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicByName<TValue>(in KeyValuePair<Topic, TValue> item, in Topic key) =>
            TopicName(item.Key.TopicName, key.TopicName)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicId(in TopicId item, in TopicId key) =>
            item.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicId<TValue>(in KeyValuePair<TopicId, TValue> item, in TopicId key) =>
            item.Key.Value.CompareTo(key.Value)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicName(in TopicName item, in TopicName key) =>
            Math.Sign(string.CompareOrdinal(item.Value, key.Value))
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicName<TValue>(in KeyValuePair<TopicName, TValue> item, in TopicName key) =>
            Math.Sign(string.CompareOrdinal(item.Key.Value, key.Value))
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int ClusterNodeId(in ClusterNodeId item, in ClusterNodeId key) =>
            item.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int ClusterNodeId<TValue>(in KeyValuePair<ClusterNodeId, TValue> item, in ClusterNodeId key) =>
            item.Key.Value.CompareTo(key.Value)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Partition(in Partition item, in Partition key) =>
            item.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Partition(in TopicPartition item, in Partition key) =>
            item.Partition.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Offset(in Offset item, in Offset key) =>
            item.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Int32<TValue>(in KeyValuePair<int, TValue> item, in int key) =>
            item.Key.CompareTo(key)
        ;
    }
}