using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class NodeIdCompare :
        IComparer<NodeId>
    {
        private NodeIdCompare() { }
        public static IComparer<NodeId> Instance { get; } = new NodeIdCompare();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<NodeId>.Compare(NodeId x, NodeId y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
