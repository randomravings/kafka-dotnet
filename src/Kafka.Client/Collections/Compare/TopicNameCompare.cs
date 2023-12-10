using Kafka.Common.Model;

namespace Kafka.Client.Collections.Compare
{
    internal class TopicNameCompare :
        IKeyCompare<Topic>
    {
        int IKeyCompare<Topic>.Compare(in Topic left, in Topic right) =>
            Math.Sign(string.CompareOrdinal(left.TopicName.Value, right.TopicName.Value))
        ;

        int IKeyCompare<Topic>.Compare<TValue>(in TValue left, in Topic right, in Func<TValue, Topic> key) =>
            Math.Sign(string.CompareOrdinal(key(left).TopicName.Value, right.TopicName.Value))
        ;

        bool IKeyCompare<Topic>.Equals(in Topic left, in Topic right) =>
            string.CompareOrdinal(left.TopicName.Value, right.TopicName.Value) == 0
        ;

        bool IKeyCompare<Topic>.Equals<TValue>(in TValue left, in Topic right, in Func<TValue, Topic> key) =>
            string.CompareOrdinal(key(left).TopicName.Value, right.TopicName.Value) == 0
        ;

        int IKeyCompare<Topic>.GetHashCode(in Topic key) =>
            HashCode.Combine(key.TopicName.Value)
        ;

        int IKeyCompare<Topic>.GetHashCode<TValue>(in TValue value, in Func<TValue, Topic> key) =>
            HashCode.Combine(key(value).TopicName.Value)
        ;

        bool IKeyCompare<Topic>.IsValid(in Topic key) =>
            !key.TopicName.IsEmpty
        ;

        bool IKeyCompare<Topic>.IsValid<TValue>(in TValue value, in Func<TValue, Topic> key) =>
            !key(value).TopicName.IsEmpty
        ;
    }
}
