using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicPartitionCompare :
        IComparer<TopicPartition>,
        IEqualityComparer<TopicPartition>
    {
        private static readonly TopicPartitionCompare INSTANCE = new();
        private TopicPartitionCompare() { }
        public static IComparer<TopicPartition> Instance => INSTANCE;
        public static IEqualityComparer<TopicPartition> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<TopicPartition>.Compare(TopicPartition x, TopicPartition y) =>
            Math.Sign(string.CompareOrdinal(x.Topic.TopicName.Value, y.Topic.TopicName.Value)) switch
            {
                0 => x.Partition.Value.CompareTo(y.Partition.Value),
                var v => v
            }
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<TopicPartition>.Equals(TopicPartition x, TopicPartition y) =>
            string.CompareOrdinal(x.Topic.TopicName.Value, y.Topic.TopicName.Value) == 0
            && x.Partition == y.Partition
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<TopicPartition>.GetHashCode(TopicPartition obj) =>
            HashCode.Combine(obj.Topic.TopicName.Value, obj.Partition.Value)
        ;
    }
}
