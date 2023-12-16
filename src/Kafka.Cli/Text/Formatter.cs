using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Cli.Text
{
    public static class Formatter
    {
        public static string Print<TKey, TValue>(in ReadRecord<TKey, TValue> value) =>
            $"{Print(value.TopicPartition)}:{Print(value.Offset)}:{PrintKey(value.Key)}:{PrintValue(value.Value)}"
        ;

        public static string Print(in bool value) =>
            value.ToString().ToLowerInvariant()
        ;

        public static string Print(in ApiError value) =>
            value.Code switch
            {
                0 => value.Label,
                _ => $"{value.Code} - {value.Label} - {value.Message}"
            }
        ;
        public static string Print(TopicPartitionOffset value) =>
            $"{Print(value.TopicPartition)}:{Print(value.Offset)}"
        ;

        public static string Print(in TopicName topic) =>
            topic.Value switch
            {
                null => "(null)",
                string s => s
            }
        ;

        public static string PrintKey<TKey>(in TKey key) =>
            key switch
            {
                null => "(null)",
                var k => $"{k}"
            }
        ;
        public static string PrintValue<TValue>(in TValue value) =>
            value switch
            {
                null => "(null)",
                var v => $"{v}"
            }
        ;
        public static string Print(in TopicPartition value) =>
            $"{Print(value.Topic.TopicName)}:{Print(value.Partition)}"
        ;
        public static string Print(in PartitionOffset value) =>
            $"{Print(value.Partition)}:{Print(value.Offset)}"
        ;
        public static string Print(in Partition value)
        {
            if (value == Partition.Unassigned)
                return "unassigned";
            else
                return $"{value.Value}";
        }
        public static string Print(in Offset value)
        {
            if (value >= 0)
                return $"{value.Value}";
            if (value == Offset.Beginning)
                return $"beginning";
            if (value == Offset.End)
                return $"end";
            if (value == Offset.Stored)
                return $"stored";
            if (value == Offset.Unset)
                return $"unset";
            return "unknown";
        }
    }
}
