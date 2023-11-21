using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicCompareById :
        IComparer<Topic>,
        IEqualityComparer<Topic>
    {
        private static readonly TopicCompareById INSTANCE = new();
        private TopicCompareById() { }
        public static IComparer<Topic> Instance => INSTANCE;
        public static IEqualityComparer<Topic> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<Topic>.Compare(Topic x, Topic y) =>
            TopicIdCompare.Instance.Compare(x.TopicId, y.TopicId)
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Topic x, Topic y) =>
            TopicIdCompare.Equality.Equals(x.TopicId, y.TopicId)
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode([DisallowNull] Topic obj) =>
            TopicIdCompare.Equality.GetHashCode(obj.TopicId)
        ;
    }
}
