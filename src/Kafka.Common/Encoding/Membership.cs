using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public static class Membership
    {
        public static byte[] PackProtocolMetadata(
            [NotNull] in ProtocolMetadata memberMetadata
        )
        {
            var metadataSize =
                2 + // version
                4 + // count
                memberMetadata.Assignments.Sum(r => 2 + r.TopicName.Value?.Length ?? 0) +
                memberMetadata.UserData.Length
            ;
            var protocolMetadata = new byte[metadataSize];
            var offset = 0;
            offset = BinaryEncoder.WriteInt16(protocolMetadata, offset, memberMetadata.Version);
            offset = BinaryEncoder.WriteInt32(protocolMetadata, offset, memberMetadata.Assignments.Count);
            foreach (var topic in memberMetadata.Assignments)
                offset = BinaryEncoder.WriteString(protocolMetadata, offset, topic.TopicName.Value ?? "");
            memberMetadata.UserData.CopyTo(0, protocolMetadata, offset, memberMetadata.UserData.Length);
            return protocolMetadata;
        }

        public static byte[] PackTopicPartitions(
            [NotNull] in IReadOnlySet<TopicPartition> assignments
        )
        {
            var groupedTopics = assignments
                .GroupBy(r => r.Topic.TopicName.Value ?? "")
                .ToImmutableSortedDictionary(
                    k => k.Key,
                    v => v.ToImmutableArray()
                );
            ;
            var topicNameCount = groupedTopics.Count;
            var topicPartitionCount = groupedTopics.Sum(r => r.Value.Length);
            var topicNameBytes = groupedTopics.Sum(r => r.Key.Length);
            var size =
                4 + // total size of assignment
                2 + // number of assignments
                topicNameCount * 2 + // topic name length
                topicNameBytes + // total bytes for topic names
                topicNameCount * 4 + // partition counts
                topicPartitionCount * 4 // total partition indices
            ;

            var bytes = new byte[size];
            var offset = 0;
            offset = BinaryEncoder.WriteInt32(bytes, offset, size);
            offset = BinaryEncoder.WriteInt16(bytes, offset, (short)topicNameCount);
            foreach (var groupedTopic in groupedTopics)
            {
                offset = BinaryEncoder.WriteString(bytes, offset, groupedTopic.Key);
                offset = BinaryEncoder.WriteInt32(bytes, offset, groupedTopic.Value.Length);
                foreach (var partition in groupedTopic.Value.OrderBy(r => r.Partition.Value))
                    offset = BinaryEncoder.WriteInt32(bytes, offset, partition.Partition.Value);
            }
            return bytes;
        }

        public static ProtocolMetadata UnpackProtocolMetadata(
            [NotNull] in byte[] data
        )
        {
            var set = ImmutableSortedSet.CreateBuilder(TopicCompare.Instance);
            var offset = 0;
            (offset, var version) = BinaryDecoder.ReadInt16(data, offset);
            (offset, var assignments) = BinaryDecoder.ReadInt32(data, offset);
            for (int i = 0; i < assignments; i++)
            {
                (offset, var topic) = BinaryDecoder.ReadString(data, offset);
                set.Add(topic);
            }
            var userData = ImmutableArray<byte>.Empty;
            if (offset < data.Length)
                userData = ImmutableArray.Create(data[offset..]);
            return new(
                version,
                set.ToImmutable(),
                userData
            );
        }

        public static IReadOnlySet<TopicPartition> UnpackTopicPartitions(
            [NotNull] in byte[] data
        )
        {
            var set = ImmutableSortedSet.CreateBuilder(TopicPartitionCompare.Instance);
            var offset = 0;
            (offset, var _) = BinaryDecoder.ReadInt32(data, offset);
            (offset, var topicCount) = BinaryDecoder.ReadInt16(data, offset);
            for (int i = 0; i < topicCount; i++)
            {
                (offset, var topic) = BinaryDecoder.ReadString(data, offset);
                (offset, var partitionCount) = BinaryDecoder.ReadInt32(data, offset);
                for (int j = 0; j < partitionCount; j++)
                {
                    (offset, var partition) = BinaryDecoder.ReadInt32(data, offset);
                    set.Add(new TopicPartition(topic, partition));
                }
            }
            return set.ToImmutable();
        }
    }
}
