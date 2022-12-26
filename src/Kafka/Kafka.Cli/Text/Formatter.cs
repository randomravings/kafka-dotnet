using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Types;

namespace Kafka.Cli.Text
{
    public static class Formatter
    {
        public static string Print(Error error) =>
            $"{error.Code} - {error.Label} - {error.Message}"
        ;
        public static string Print(TopicPartitionOffset topicPartitionOffset) =>
            $"{Print(topicPartitionOffset.Topic)}:{topicPartitionOffset.PartitionOffset}"
        ;
        public static string Print(TopicName topic) =>
            topic.Value switch
            {
                null => "(null)",
                string s => s
            }
        ;
        public static string Print(PartitionOffset partitionOffset) =>
            $"{Print(partitionOffset.Partition)}:{Print(partitionOffset.Offset)}"
        ;
        public static string Print(Partition partition)
        {
            if (partition == Partition.Unassigned)
                return "unassigned";
            else
                return $"{partition.Value}";
        }
        public static string Print(Offset offset)
        {
            if (offset >= 0)
                return $"{offset.Value}";
            if (offset == Offset.Beginning)
                return $"beginning";
            if (offset == Offset.End)
                return $"end";
            if (offset == Offset.Stored)
                return $"stored";
            if (offset == Offset.Unset)
                return $"unset";
            return "unknown";
        }
        public static string Print(ProduceRecordError produceRecordError) =>
            $"{produceRecordError.Index}:{produceRecordError.ErrorMessage}"
        ;
    }
}
