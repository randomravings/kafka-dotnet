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
        private static readonly Func<Stream, VoteRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, VoteRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static VoteRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, VoteRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static VoteRequest ReadV00(Stream buffer)
        {
            var clusterIdField = Decoder.ReadCompactNullableString(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                clusterIdField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, VoteRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicData message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var candidateEpochField = Decoder.ReadInt32(buffer);
                    var candidateIdField = Decoder.ReadInt32(buffer);
                    var lastOffsetEpochField = Decoder.ReadInt32(buffer);
                    var lastOffsetField = Decoder.ReadInt64(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        candidateEpochField,
                        candidateIdField,
                        lastOffsetEpochField,
                        lastOffsetField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.CandidateEpochField);
                    Encoder.WriteInt32(buffer, message.CandidateIdField);
                    Encoder.WriteInt32(buffer, message.LastOffsetEpochField);
                    Encoder.WriteInt64(buffer, message.LastOffsetField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}