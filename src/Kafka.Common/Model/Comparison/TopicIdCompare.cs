using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicIdCompare :
        IComparer<TopicId>,
        IEqualityComparer<TopicId>
    {
        private static readonly TopicIdCompare INSTANCE = new();
        private TopicIdCompare() { }
        public static IComparer<TopicId> Instance => INSTANCE;
        public static IEqualityComparer<TopicId> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<TopicId>.Compare(TopicId x, TopicId y) =>
            x.Value.CompareTo(y.Value)
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEqualityComparer<TopicId>.Equals(TopicId x, TopicId y) =>
            x.Value.Equals(y.Value)
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IEqualityComparer<TopicId>.GetHashCode(TopicId obj) =>
            obj.Value.GetHashCode()
        ;
    }
}
