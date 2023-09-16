namespace Kafka.Common.Model.Comparison
{
    public sealed class PartitionCompare :
        IComparer<Partition>
    {
        private PartitionCompare() { }
        public static IComparer<Partition> Instance { get; } = new PartitionCompare();
        int IComparer<Partition>.Compare(Partition x, Partition y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
