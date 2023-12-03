using Kafka.Common.Model;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal static class Compare
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareTopicId<TValue>(in KeyValuePair<TopicPartition, TValue> item, in TopicPartition key) =>
            item.Key.Topic.TopicId.Value.CompareTo(key.Topic.TopicId.Value) switch
            {
                0 => item.Key.Partition.Value.CompareTo(key.Partition.Value),
                var v => v
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareTopicName<TValue>(in MapValue<TopicPartition, TValue> item, in TopicPartition key) =>
            Math.Sign(string.CompareOrdinal(item.Key.Topic.TopicName.Value, key.Topic.TopicName.Value)) switch
            {
                0 => item.Key.Partition.Value.CompareTo(key.Partition.Value),
                var v => v
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareTopicName<TValue>(in MapValue<Topic, TValue> item, in Topic key) =>
            Math.Sign(string.CompareOrdinal(item.Key.TopicName.Value, key.TopicName.Value))
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareTopicId<TValue>(in KeyValuePair<Topic, TValue> item, in Topic key) =>
            item.Key.TopicId.Value.CompareTo(key.TopicId.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionId(in TopicPartition item, in TopicPartition key) =>
            item.Topic.TopicId.Value.CompareTo(key.Topic.TopicId) switch
            {
                0 => item.Partition.Value.CompareTo(item.Partition.Value),
                var v => v
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionName(in TopicPartition item, in TopicPartition key) =>
            Math.Sign(string.CompareOrdinal(item.Topic.TopicName.Value, key.Topic.TopicName.Value)) switch
            {
                0 => item.Partition.Value.CompareTo(item.Partition.Value),
                var v => v
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicName(in TopicName item, in TopicName key) =>
            Math.Sign(string.CompareOrdinal(item.Value, key.Value))
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Partition(in Partition item, in Partition key) =>
            item.Value.CompareTo(key.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareId(in Topic item, in Topic key) =>
            item.TopicId.Value.CompareTo(
                key.TopicId.Value
            )
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareName(in Topic item, in Topic key) =>
            Math.Sign(string.CompareOrdinal(
                item.TopicName.Value,
                key.TopicName.Value)
            )
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareId(in TopicPartition item, in TopicPartition key) =>
            item.Topic.TopicId.Value.CompareTo(
                key.Topic.TopicId.Value
            ) switch
            {
                0 => item.Partition.Value.CompareTo(
                    key.Partition.Value
                ),
                var v => v
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int CompareName(in TopicPartition item, in TopicPartition key) =>
            Math.Sign(string.CompareOrdinal(
                item.Topic.TopicName.Value,
                key.Topic.TopicName.Value
            )) switch
            {
                0 => item.Partition.Value.CompareTo(
                    key.Partition.Value
                ),
                var v => v
            }
        ;
    }
}