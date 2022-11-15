using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetDeleteResponsePartition = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition;
using OffsetDeleteResponseTopic = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteResponseSerde
    {
        private static readonly Func<Stream, OffsetDeleteResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, OffsetDeleteResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static OffsetDeleteResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetDeleteResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetDeleteResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetDeleteResponseTopic>(buffer, b => OffsetDeleteResponseTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                errorCodeField,
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetDeleteResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetDeleteResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetDeleteResponseTopicSerde.WriteV00(b, i));
        }
        private static class OffsetDeleteResponseTopicSerde
        {
            public static OffsetDeleteResponseTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetDeleteResponsePartition>(buffer, b => OffsetDeleteResponsePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetDeleteResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetDeleteResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetDeleteResponsePartitionSerde.WriteV00(b, i));
            }
            private static class OffsetDeleteResponsePartitionSerde
            {
                public static OffsetDeleteResponsePartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetDeleteResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
            }
        }
    }
}