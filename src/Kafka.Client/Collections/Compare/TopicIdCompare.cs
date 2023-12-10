using Kafka.Common.Model;

namespace Kafka.Client.Collections.Compare
{
    internal class TopicIdCompare :
        IKeyCompare<Topic>
    {
        int IKeyCompare<Topic>.Compare(in Topic left, in Topic right) =>
            left.TopicId.Value.CompareTo(right.TopicId.Value)
        ;

        int IKeyCompare<Topic>.Compare<TValue>(in TValue left, in Topic right, in Func<TValue, Topic> key) =>
            key(left).TopicId.Value.CompareTo(right.TopicId.Value)
        ;

        bool IKeyCompare<Topic>.Equals(in Topic left, in Topic right) =>
            left.TopicId.Value.CompareTo(right.TopicId.Value) == 0
        ;

        bool IKeyCompare<Topic>.Equals<TValue>(in TValue left, in Topic right, in Func<TValue, Topic> key) =>
            key(left).TopicId.Value.CompareTo(right.TopicId.Value) == 0
        ;

        int IKeyCompare<Topic>.GetHashCode(in Topic key) =>
            HashCode.Combine(key.TopicId.Value)
        ;

        int IKeyCompare<Topic>.GetHashCode<TValue>(in TValue value, in Func<TValue, Topic> key) =>
            HashCode.Combine(key(value).TopicId.Value)
        ;

        bool IKeyCompare<Topic>.IsValid(in Topic key) =>
            !key.TopicId.IsEmpty
        ;

        bool IKeyCompare<Topic>.IsValid<TValue>(in TValue value, in Func<TValue, Topic> key) =>
            !key(value).TopicId.IsEmpty
        ;
    }
}
