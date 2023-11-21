using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class ClusterIdCompare :
        IComparer<ClusterId>
    {
        private ClusterIdCompare() { }
        public static IComparer<ClusterId> Instance { get; } = new ClusterIdCompare();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<ClusterId>.Compare(ClusterId x, ClusterId y) =>
            string.CompareOrdinal(x.Value, y.Value)
        ;
    }
}
