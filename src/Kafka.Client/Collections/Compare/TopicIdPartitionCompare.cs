using Kafka.Common.Model;

namespace Kafka.Client.Collections.Compare
{
    internal class TopicIdPartitionCompare :
        IKeyCompare<TopicPartition>
    {
        private TopicIdPartitionCompare() { }
        public static IKeyCompare<TopicPartition> Instance { get; } = new TopicIdPartitionCompare();

        int IKeyCompare<TopicPartition>.Compare(in TopicPartition left, in TopicPartition right) =>
            left.Topic.TopicId.Value.CompareTo(right.Topic.TopicId.Value) switch
            {
                0 => left.Partition.Value.CompareTo(right.Partition.Value),
                var v => v
            }
        ;

        int IKeyCompare<TopicPartition>.Compare<TValue>(in TValue left, in TopicPartition right, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(left);
            return extractedKey.Topic.TopicId.Value.CompareTo(right.Topic.TopicId.Value) switch
            {
                0 => extractedKey.Partition.Value.CompareTo(right.Partition.Value),
                var v => v
            };
        }

        bool IKeyCompare<TopicPartition>.Equals(in TopicPartition left, in TopicPartition right) =>
            left.Topic.TopicId.Value.CompareTo(right.Topic.TopicId.Value) == 0 &&
            left.Partition.Value == right.Partition.Value
        ;

        bool IKeyCompare<TopicPartition>.Equals<TValue>(in TValue left, in TopicPartition right, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(left);
            return extractedKey.Topic.TopicId.Value.CompareTo(right.Topic.TopicId.Value) == 0 &&
                extractedKey.Partition.Value == right.Partition.Value
            ;
        }

        int IKeyCompare<TopicPartition>.GetHashCode(in TopicPartition key) =>
            HashCode.Combine(key.Topic.TopicId.Value, key.Partition.Value)
        ;

        int IKeyCompare<TopicPartition>.GetHashCode<TValue>(in TValue value, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(value);
            return HashCode.Combine(extractedKey.Topic.TopicId.Value, extractedKey.Partition.Value);
        }

        bool IKeyCompare<TopicPartition>.IsValid(in TopicPartition key) =>
            !key.Topic.TopicId.IsEmpty
        ;

        bool IKeyCompare<TopicPartition>.IsValid<TValue>(in TValue value, in Func<TValue, TopicPartition> key) =>
            !key(value).Topic.TopicId.IsEmpty
        ;
    }
}
