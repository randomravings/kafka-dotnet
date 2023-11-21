using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class PartitionCompare :
        IComparer<Partition>
    {
        private PartitionCompare() { }
        public static IComparer<Partition> Instance { get; } = new PartitionCompare();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<Partition>.Compare(Partition x, Partition y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
