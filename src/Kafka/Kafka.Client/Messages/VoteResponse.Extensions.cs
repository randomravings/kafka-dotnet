using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.VoteResponse.TopicData;
using PartitionData = Kafka.Client.Messages.VoteResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteResponseSerde
    {
        private static readonly DecodeDelegate<VoteResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<VoteResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static VoteResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, VoteResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static VoteResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, VoteResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
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
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var voteGrantedField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        voteGrantedField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteBoolean(buffer, message.VoteGrantedField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}