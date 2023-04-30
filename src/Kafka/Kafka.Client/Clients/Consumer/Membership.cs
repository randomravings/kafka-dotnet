using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public static class Membership
    {
        public static byte[] Pack(IEnumerable<TopicPartition> assignments)
        {
            var groupedTopics = assignments
                .GroupBy(r => r.Topic.Value ?? "")
            ;
            var topicNameCount = groupedTopics.Count();
            var topicPartitionCount = groupedTopics.Sum(r => r.Count());
            var topicNameBytes = groupedTopics.Sum(r => r.Key.Length);
            var size =
                4 + // total size of assignment
                2 + // number of assignments
                (topicNameCount * 2) + // topic name length
                topicNameBytes + // total bytes for topic names
                (topicNameCount * 4) + // partition counts
                (topicPartitionCount * 4) // total partition indices
            ;

            var bytes = new byte[size];
            var offset = 0;
            offset = Encoder.WriteInt32(bytes, offset, size);
            offset = Encoder.WriteInt16(bytes, offset, (short)topicNameCount);
            foreach (var groupedTopic in groupedTopics)
            {
                offset = Encoder.WriteString(bytes, offset, groupedTopic.Key);
                offset = Encoder.WriteInt32(bytes, offset, groupedTopic.Count());
                foreach (var partition in groupedTopic.OrderBy(r => r.Partition.Value))
                    offset = Encoder.WriteInt32(bytes, offset, partition.Partition.Value);
            }
            return bytes;
        }

        public static byte[] Pack(IEnumerable<TopicName> assignments)
        {
            var metadataSize =
                2 + // version
                4 + // count
                assignments.Sum(r => 2 + r.Value?.Length ?? 0) + // topic names including size
                8 // no idea what this is ...
            ;
            var topicMetadata = new byte[metadataSize];
            var offset = 0;
            offset = Encoder.WriteInt16(topicMetadata, offset, 1);
            offset = Encoder.WriteInt32(topicMetadata, offset, assignments.Count());
            foreach (var topic in assignments)
                offset = Encoder.WriteString(topicMetadata, offset, topic);
            return topicMetadata;
        }



        public static ImmutableSortedSet<TopicPartition> Unpack(byte[] data)
        {
            var set = ImmutableSortedSet.CreateBuilder(TopicPartitionCompare.Instance);
            var offset = 0;
            (offset, var _) = Decoder.ReadInt32(data, offset);
            (offset, var topicCount) = Decoder.ReadInt16(data, offset);
            for (int i = 0; i < topicCount; i++)
            {
                (offset, var topic) = Decoder.ReadString(data, offset);
                (offset, var partitionCount) = Decoder.ReadInt32(data, offset);
                for (int j = 0; j < partitionCount; j++)
                {
                    (offset, var partition) = Decoder.ReadInt32(data, offset);
                    set.Add(new TopicPartition(topic, partition));
                }
            }
            return set.ToImmutable();
        }
    }
}
