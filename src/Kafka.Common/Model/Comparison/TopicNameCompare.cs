using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicNameCompare :
        IComparer<TopicName>,
        IEqualityComparer<TopicName>
    {
        private static readonly TopicNameCompare INSTANCE = new();
        private TopicNameCompare() { }
        public static IComparer<TopicName> Instance => INSTANCE;
        public static IEqualityComparer<TopicName> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<TopicName>.Compare(TopicName x, TopicName y) =>
            string.CompareOrdinal(x.Value, y.Value)
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<TopicName>.Equals(TopicName x, TopicName y) =>
            string.CompareOrdinal(x.Value, y.Value) == 0
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<TopicName>.GetHashCode(TopicName obj) =>
            HashCode.Combine(obj.Value)
        ;
    }
}
