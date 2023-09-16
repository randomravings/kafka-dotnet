using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;

namespace Kafka.Cli.Text
{
    public static class Formatter
    {
        public static string Print<TKey, TValue>(in ConsumerRecord<TKey, TValue> value) =>
            $"{Print(value.TopicPartition)}:{Print(value.Offset)}:{Print(value.Key)}:{Print(value.Value)}"
        ;
        public static string Print(in Error value) =>
            $"{value.Code} - {value.Label} - {value.Message}"
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
        public static string Print<T>(in OptionalValue<T> value) =>
            value.IsNull switch
            {
                true => "(null)",
                false => $"{value.Value}"
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
