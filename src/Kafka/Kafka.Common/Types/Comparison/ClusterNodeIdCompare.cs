namespace Kafka.Common.Types.Comparison
{
    public sealed class ClusterNodeIdCompare :
        IComparer<ClusterNodeId>
    {
        private ClusterNodeIdCompare() { }
        public static IComparer<ClusterNodeId> Instance { get; } = new ClusterNodeIdCompare();
        int IComparer<ClusterNodeId>.Compare(ClusterNodeId x, ClusterNodeId y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
