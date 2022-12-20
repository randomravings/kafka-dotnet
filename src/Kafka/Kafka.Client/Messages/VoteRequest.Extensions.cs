using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.VoteRequest.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.VoteRequest.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteRequestSerde
    {
        private static readonly DecodeDelegate<VoteRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<VoteRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static VoteRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, VoteRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static VoteRequest ReadV00(byte[] buffer, ref int index)
        {
            var clusterIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                clusterIdField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, VoteRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var candidateEpochField = Decoder.ReadInt32(buffer, ref index);
                    var candidateIdField = Decoder.ReadInt32(buffer, ref index);
                    var lastOffsetEpochField = Decoder.ReadInt32(buffer, ref index);
                    var lastOffsetField = Decoder.ReadInt64(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        candidateEpochField,
                        candidateIdField,
                        lastOffsetEpochField,
                        lastOffsetField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.CandidateEpochField);
                    index = Encoder.WriteInt32(buffer, index, message.CandidateIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LastOffsetEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.LastOffsetField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}