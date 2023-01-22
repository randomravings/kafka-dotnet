using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Types;

namespace Kafka.Cli.Text
{
    public static class Formatter
    {
        public static string Print<TKey, TValue>(ConsumeResult<TKey, TValue> value) =>
        $"{Print(value.TopicPartition)}:{Print(value.Offset)}:{value.Record.Key}:{value.Record.Value}"
    ;
        public static string Print(Error value) =>
            $"{value.Code} - {value.Label} - {value.Message}"
        ;
        public static string Print(TopicPartitionOffset value) =>
            $"{Print(value.TopicPartition)}:{Print(value.Offset)}"
        ;
        public static string Print(TopicName topic) =>
            topic.Value switch
            {
                null => "(null)",
                string s => s
            }
        ;
        public static string Print(TopicPartition value) =>
            $"{Print(value.Topic)}:{Print(value.Partition)}"
        ;
        public static string Print(PartitionOffset value) =>
            $"{Print(value.Partition)}:{Print(value.Offset)}"
        ;
        public static string Print(Partition value)
        {
            if (value == Partition.Unassigned)
                return "unassigned";
            else
                return $"{value.Value}";
        }
        public static string Print(Offset value)
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
