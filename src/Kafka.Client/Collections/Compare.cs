using Kafka.Common.Model;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Collections
{
    internal static class Compare
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionById(in TopicPartition left, in TopicPartition right) =>
            TopicById(left.Topic, right.Topic) switch
            {
                0 => Partition(left.Partition, right.Partition),
                var c => c
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionById<TValue>(in TopicPartition left, in KeyValuePair<TopicPartition, TValue>  right) =>
            TopicById(left.Topic, right.Key.Topic) switch
            {
                0 => Partition(left.Partition, right.Key.Partition),
                var c => c
            }
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionByName(in TopicPartition left, in TopicPartition right) =>
            TopicByName(left.Topic, right.Topic) switch
            {
                0 => Partition(left.Partition, right.Partition),
                var c => c
            }
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicPartitionByName<TValue>(in TopicPartition left, in KeyValuePair<TopicPartition, TValue> right) =>
            TopicByName(left.Topic, right.Key.Topic) switch
            {
                0 => Partition(left.Partition, right.Key.Partition),
                var c => c
            }
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicById(in Topic left, in Topic right) =>
            TopicId(left.TopicId, right.TopicId)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicById<TValue>(in Topic left, in KeyValuePair<Topic, TValue> right) =>
            TopicId(left.TopicId, right.Key.TopicId)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicByName(in Topic left, in Topic right) =>
            TopicName(left.TopicName, right.TopicName)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicByName<TValue>(in Topic left, in  KeyValuePair<Topic, TValue> right) =>
            TopicName(left.TopicName, right.Key.TopicName)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicId(in TopicId left, in TopicId right) =>
            left.Value.CompareTo(right.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicId<TValue>(in TopicId left, in  KeyValuePair<TopicId, TValue> right) =>
            left.Value.CompareTo(right.Key.Value)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicName(in TopicName left, in TopicName right) =>
            Math.Sign(string.CompareOrdinal(left.Value, right.Value))
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int TopicName<TValue>(in TopicName left, in KeyValuePair<TopicName, TValue> right) =>
            Math.Sign(string.CompareOrdinal(left.Value, right.Key.Value))
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int ClusterNodeId(in ClusterNodeId left, in ClusterNodeId right) =>
            left.Value.CompareTo(right.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int ClusterNodeId<TValue>(in ClusterNodeId left, in KeyValuePair<ClusterNodeId, TValue> right) =>
            left.Value.CompareTo(right.Key.Value)
        ;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Partition(in Partition left, in Partition right) =>
            left.Value.CompareTo(right.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Offset(in Offset left, in Offset right) =>
            left.Value.CompareTo(right.Value)
        ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Int32<TValue>(in int left, in KeyValuePair<int, TValue> right) =>
            left.CompareTo(right.Key)
        ;
    }
}