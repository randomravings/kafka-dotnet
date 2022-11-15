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
        private static readonly Func<Stream, OffsetDeleteRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, OffsetDeleteRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static OffsetDeleteRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetDeleteRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetDeleteRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetDeleteRequestTopic>(buffer, b => OffsetDeleteRequestTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetDeleteRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetDeleteRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetDeleteRequestTopicSerde.WriteV00(b, i));
        }
        private static class OffsetDeleteRequestTopicSerde
        {
            public static OffsetDeleteRequestTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetDeleteRequestPartition>(buffer, b => OffsetDeleteRequestPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetDeleteRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetDeleteRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetDeleteRequestPartitionSerde.WriteV00(b, i));
            }
            private static class OffsetDeleteRequestPartitionSerde
            {
                public static OffsetDeleteRequestPartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionIndexField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetDeleteRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                }
            }
        }
    }
}