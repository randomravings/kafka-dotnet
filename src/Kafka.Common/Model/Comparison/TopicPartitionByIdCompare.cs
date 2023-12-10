using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicPartitionByIdCompare :
        IComparer<TopicPartition>,
        IEqualityComparer<TopicPartition>
    {
        private static readonly TopicPartitionByIdCompare INSTANCE = new();
        private TopicPartitionByIdCompare() { }
        public static IComparer<TopicPartition> Instance => INSTANCE;
        public static IEqualityComparer<TopicPartition> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<TopicPartition>.Compare(TopicPartition x, TopicPartition y) =>
            x.Topic.TopicId.Value.CompareTo(y.Topic.TopicId.Value) switch
            {
                0 => x.Partition.Value.CompareTo(y.Partition.Value),
                var v => v
            }
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<TopicPartition>.Equals(TopicPartition x, TopicPartition y) =>
            x.Topic.TopicId.Value.CompareTo(y.Topic.TopicId.Value) == 0
            && x.Partition == y.Partition
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<TopicPartition>.GetHashCode(TopicPartition obj) =>
            HashCode.Combine(obj.Topic.TopicId.Value, obj.Partition.Value)
        ;
    }
}
