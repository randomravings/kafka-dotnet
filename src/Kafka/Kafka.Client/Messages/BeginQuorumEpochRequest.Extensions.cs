using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData;
using PartitionData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BeginQuorumEpochRequestSerde
    {
        private static readonly DecodeDelegate<BeginQuorumEpochRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<BeginQuorumEpochRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BeginQuorumEpochRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, BeginQuorumEpochRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static BeginQuorumEpochRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var topicsField = Decoder.ReadArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                clusterIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, BeginQuorumEpochRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            return buffer;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                return buffer;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
            }
        }
    }
}