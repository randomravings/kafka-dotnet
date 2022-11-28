using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetDeleteResponseTopic = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic;
using OffsetDeleteResponsePartition = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteResponseSerde
    {
        private static readonly DecodeDelegate<OffsetDeleteResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<OffsetDeleteResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static OffsetDeleteResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetDeleteResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetDeleteResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetDeleteResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetDeleteResponseTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                errorCodeField,
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetDeleteResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetDeleteResponseTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static class OffsetDeleteResponseTopicSerde
        {
            public static OffsetDeleteResponseTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetDeleteResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetDeleteResponsePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetDeleteResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetDeleteResponsePartitionSerde.WriteV00(b, i));
                return buffer;
            }
            private static class OffsetDeleteResponsePartitionSerde
            {
                public static OffsetDeleteResponsePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
            }
        }
    }
}