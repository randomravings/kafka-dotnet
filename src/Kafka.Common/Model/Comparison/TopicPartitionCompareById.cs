using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicPartitionCompareById :
        IComparer<TopicPartition>,
        IEqualityComparer<TopicPartition>
    {
        private static readonly TopicPartitionCompareById INSTANCE = new();
        private TopicPartitionCompareById() { }
        public static IComparer<TopicPartition> Instance => INSTANCE;
        public static IEqualityComparer<TopicPartition> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<TopicPartition>.Compare(TopicPartition x, TopicPartition y) =>
            TopicCompareById.Instance.Compare(x.Topic, y.Topic) switch
            {
                0 => x.Partition.Value.CompareTo(y.Partition.Value),
                int v => v
            }
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<TopicPartition>.Equals(TopicPartition x, TopicPartition y) =>
            TopicCompareById.Equality.Equals(x.Topic, y.Topic) && x.Partition == y.Partition
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<TopicPartition>.GetHashCode(TopicPartition obj) =>
            HashCode.Combine(TopicCompareById.Equality.GetHashCode(obj.Topic), obj.Partition.Value)
        ;
    }
}
