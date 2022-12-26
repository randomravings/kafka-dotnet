using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetDeleteResponseTopic = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic;
using OffsetDeleteResponsePartition = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteResponseSerde
    {
        private static readonly DecodeDelegate<OffsetDeleteResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<OffsetDeleteResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static OffsetDeleteResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetDeleteResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetDeleteResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetDeleteResponseTopic>(buffer, ref index, OffsetDeleteResponseTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                errorCodeField,
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetDeleteResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetDeleteResponseTopic>(buffer, index, message.TopicsField, OffsetDeleteResponseTopicSerde.WriteV00);
            return index;
        }
        private static class OffsetDeleteResponseTopicSerde
        {
            public static OffsetDeleteResponseTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetDeleteResponsePartition>(buffer, ref index, OffsetDeleteResponsePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetDeleteResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetDeleteResponsePartition>(buffer, index, message.PartitionsField, OffsetDeleteResponsePartitionSerde.WriteV00);
                return index;
            }
            private static class OffsetDeleteResponsePartitionSerde
            {
                public static OffsetDeleteResponsePartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetDeleteResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
            }
        }
    }
}