using Kafka.Common.Model;

namespace Kafka.Client.Collections.Compare
{
    internal class TopicNamePartitionCompare :
        IKeyCompare<TopicPartition>
    {
        private TopicNamePartitionCompare() { }
        public static IKeyCompare<TopicPartition> Instance { get; } = new TopicNamePartitionCompare();

        int IKeyCompare<TopicPartition>.Compare(in TopicPartition left, in TopicPartition right) =>
            Math.Sign(string.CompareOrdinal(left.Topic.TopicName.Value, right.Topic.TopicName.Value)) switch
            {
                0 => left.Partition.Value.CompareTo(right.Partition.Value),
                var v => v
            }
        ;

        int IKeyCompare<TopicPartition>.Compare<TValue>(in TValue left, in TopicPartition right, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(left);
            return Math.Sign(string.CompareOrdinal(extractedKey.Topic.TopicName.Value, right.Topic.TopicName.Value)) switch
            {
                0 => extractedKey.Partition.Value.CompareTo(right.Partition.Value),
                var v => v
            };
        }

        bool IKeyCompare<TopicPartition>.Equals(in TopicPartition left, in TopicPartition right) =>
            string.CompareOrdinal(left.Topic.TopicName.Value, right.Topic.TopicName.Value) == 0 &&
            left.Partition.Value == right.Partition.Value
        ;

        bool IKeyCompare<TopicPartition>.Equals<TValue>(in TValue left, in TopicPartition right, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(left);
            return string.CompareOrdinal(extractedKey.Topic.TopicName.Value, right.Topic.TopicName.Value) == 0 &&
                extractedKey.Partition.Value == right.Partition.Value
            ;
        }

        int IKeyCompare<TopicPartition>.GetHashCode(in TopicPartition key) =>
            HashCode.Combine(key.Topic.TopicName.Value, key.Partition.Value)
        ;

        int IKeyCompare<TopicPartition>.GetHashCode<TValue>(in TValue value, in Func<TValue, TopicPartition> key)
        {
            var extractedKey = key(value);
            return HashCode.Combine(extractedKey.Topic.TopicName.Value, extractedKey.Partition.Value);
        }

        bool IKeyCompare<TopicPartition>.IsValid(in TopicPartition key) =>
            !key.Topic.TopicName.IsEmpty
        ;

        bool IKeyCompare<TopicPartition>.IsValid<TValue>(in TValue value, in Func<TValue, TopicPartition> key) =>
            !key(value).Topic.TopicName.IsEmpty
        ;
    }
}
