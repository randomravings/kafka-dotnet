using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicCompare :
        IComparer<Topic>,
        IEqualityComparer<Topic>
    {
        private static readonly TopicCompare INSTANCE = new();
        private TopicCompare() { }
        public static IComparer<Topic> Instance => INSTANCE;
        public static IEqualityComparer<Topic> Equality => INSTANCE;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparer<Topic>.Compare(Topic x, Topic y) =>
            Math.Sign(string.CompareOrdinal(x.TopicName.Value, y.TopicName.Value))
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Topic x, Topic y) =>
            string.CompareOrdinal(x.TopicName.Value, y.TopicName.Value) == 0
        ;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode([DisallowNull] Topic obj) =>
            HashCode.Combine(obj.TopicName.Value)
        ;
    }
}
