namespace Kafka.Common.Types.Comparison
{
    public sealed class ClusterIdCompare :
        IComparer<ClusterId>
    {
        private ClusterIdCompare() { }
        public static IComparer<ClusterId> Instance { get; } = new ClusterIdCompare();
        int IComparer<ClusterId>.Compare(ClusterId x, ClusterId y) =>
            string.CompareOrdinal(x.Value, y.Value)
        ;
    }
}
