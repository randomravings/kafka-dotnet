using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.VoteRequest.TopicData;
using PartitionData = Kafka.Client.Messages.VoteRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteRequestSerde
    {
        private static readonly DecodeDelegate<VoteRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<VoteRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static VoteRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, VoteRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static VoteRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = Decoder.ReadCompactNullableString(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                clusterIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, VoteRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var candidateEpochField = Decoder.ReadInt32(ref buffer);
                    var candidateIdField = Decoder.ReadInt32(ref buffer);
                    var lastOffsetEpochField = Decoder.ReadInt32(ref buffer);
                    var lastOffsetField = Decoder.ReadInt64(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        candidateEpochField,
                        candidateIdField,
                        lastOffsetEpochField,
                        lastOffsetField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.CandidateEpochField);
                    buffer = Encoder.WriteInt32(buffer, message.CandidateIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LastOffsetEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.LastOffsetField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}