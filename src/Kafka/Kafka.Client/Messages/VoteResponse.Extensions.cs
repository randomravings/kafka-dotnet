using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicData = Kafka.Client.Messages.VoteResponse.TopicData;
using PartitionData = Kafka.Client.Messages.VoteResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteResponseSerde
    {
        private static readonly DecodeDelegate<VoteResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<VoteResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static VoteResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, VoteResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static VoteResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, VoteResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var leaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var voteGrantedField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        voteGrantedField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteBoolean(buffer, index, message.VoteGrantedField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}