namespace Kafka.Common.Types.Comparison
{
    public sealed class TopicPartitionCompare :
        IComparer<TopicPartition>
    {
        private TopicPartitionCompare() { }
        public static IComparer<TopicPartition> Instance { get; } = new TopicPartitionCompare();
        int IComparer<TopicPartition>.Compare(TopicPartition x, TopicPartition y) =>
            TopicNameCompare.Instance.Compare(x.Topic, y.Topic) switch
            {
                0 => x.Partition.Value.CompareTo(y.Partition.Value),
                int v => v
            }
        ;
    }
}
