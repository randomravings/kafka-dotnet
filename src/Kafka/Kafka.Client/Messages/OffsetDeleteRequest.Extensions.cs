using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetDeleteRequestPartition = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic.OffsetDeleteRequestPartition;
using OffsetDeleteRequestTopic = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteRequestSerde
    {
        private static readonly DecodeDelegate<OffsetDeleteRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<OffsetDeleteRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static OffsetDeleteRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetDeleteRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetDeleteRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetDeleteRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetDeleteRequestTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetDeleteRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetDeleteRequestTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static class OffsetDeleteRequestTopicSerde
        {
            public static OffsetDeleteRequestTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetDeleteRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetDeleteRequestPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetDeleteRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetDeleteRequestPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            private static class OffsetDeleteRequestPartitionSerde
            {
                public static OffsetDeleteRequestPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionIndexField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetDeleteRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    return buffer;
                }
            }
        }
    }
}