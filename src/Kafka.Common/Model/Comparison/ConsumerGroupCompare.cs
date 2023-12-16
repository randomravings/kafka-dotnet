using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class ConsumerGroupCompare :
        IComparer<ConsumerGroup>,
        IEqualityComparer<ConsumerGroup>
    {
        private static readonly ConsumerGroupCompare INSTANCE = new();
        private ConsumerGroupCompare() { }
        public static IComparer<ConsumerGroup> Instance => INSTANCE;
        public static IEqualityComparer<ConsumerGroup> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<ConsumerGroup>.Compare(ConsumerGroup x, ConsumerGroup y) =>
            Math.Sign(string.CompareOrdinal(x.Value, y.Value))
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<ConsumerGroup>.Equals(ConsumerGroup x, ConsumerGroup y) =>
            string.CompareOrdinal(x.Value, y.Value) == 0
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<ConsumerGroup>.GetHashCode(ConsumerGroup obj) =>
            HashCode.Combine(obj.Value)
        ;
    }
}
