using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.EndQuorumEpochResponse.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.EndQuorumEpochResponse.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndQuorumEpochResponseSerde
    {
        private static readonly DecodeDelegate<EndQuorumEpochResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<EndQuorumEpochResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static EndQuorumEpochResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, EndQuorumEpochResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static EndQuorumEpochResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, EndQuorumEpochResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
            return index;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicNameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
                return index;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        LeaderIdField,
                        LeaderEpochField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
            }
        }
    }
}