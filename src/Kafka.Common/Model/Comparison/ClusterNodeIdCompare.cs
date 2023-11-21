using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class ClusterNodeIdCompare :
        IComparer<ClusterNodeId>
    {
        private ClusterNodeIdCompare() { }
        public static IComparer<ClusterNodeId> Instance { get; } = new ClusterNodeIdCompare();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<ClusterNodeId>.Compare(ClusterNodeId x, ClusterNodeId y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
