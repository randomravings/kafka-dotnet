namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicPartitionByNameCompare :
        IComparer<TopicPartition>,
        IEqualityComparer<TopicPartition>
    {
        private TopicPartitionByNameCompare() { }
        private static readonly TopicPartitionByNameCompare INSTANCE = new();
        public static IComparer<TopicPartition> Instance => INSTANCE;
        public static IEqualityComparer<TopicPartition> Equality => INSTANCE;
        int IComparer<TopicPartition>.Compare(TopicPartition x, TopicPartition y) =>
            TopicByNameCompare.Instance.Compare(x.Topic, y.Topic) switch
            {
                0 => x.Partition.Value.CompareTo(y.Partition.Value),
                int v => v
            }
        ;

        bool IEqualityComparer<TopicPartition>.Equals(TopicPartition x, TopicPartition y) =>
            TopicByNameCompare.Equality.Equals(x.Topic, y.Topic) && x.Partition == y.Partition
        ;

        int IEqualityComparer<TopicPartition>.GetHashCode(TopicPartition obj) =>
            HashCode.Combine(obj.Topic.TopicName, obj.Partition)
        ;
    }
}
