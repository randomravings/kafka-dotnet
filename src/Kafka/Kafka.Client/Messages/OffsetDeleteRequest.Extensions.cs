using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetDeleteRequestPartition = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic.OffsetDeleteRequestPartition;
using OffsetDeleteRequestTopic = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteRequestSerde
    {
        private static readonly DecodeDelegate<OffsetDeleteRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<OffsetDeleteRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static OffsetDeleteRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetDeleteRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetDeleteRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetDeleteRequestTopic>(buffer, ref index, OffsetDeleteRequestTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetDeleteRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetDeleteRequestTopic>(buffer, index, message.TopicsField, OffsetDeleteRequestTopicSerde.WriteV00);
            return index;
        }
        private static class OffsetDeleteRequestTopicSerde
        {
            public static OffsetDeleteRequestTopic ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<OffsetDeleteRequestPartition>(buffer, ref index, OffsetDeleteRequestPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetDeleteRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetDeleteRequestPartition>(buffer, index, message.PartitionsField, OffsetDeleteRequestPartitionSerde.WriteV00);
                return index;
            }
            private static class OffsetDeleteRequestPartitionSerde
            {
                public static OffsetDeleteRequestPartition ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionIndexField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetDeleteRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    return index;
                }
            }
        }
    }
}