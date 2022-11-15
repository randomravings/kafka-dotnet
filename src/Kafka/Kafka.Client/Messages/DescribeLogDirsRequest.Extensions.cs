using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribableLogDirTopic = Kafka.Client.Messages.DescribeLogDirsRequest.DescribableLogDirTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsRequestSerde
    {
        private static readonly Func<Stream, DescribeLogDirsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, DescribeLogDirsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeLogDirsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeLogDirsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeLogDirsRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(buffer, b => DescribableLogDirTopicSerde.ReadV00(b));
            return new(
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeLogDirsRequest message)
        {
            Encoder.WriteArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV00(b, i));
        }
        private static DescribeLogDirsRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(buffer, b => DescribableLogDirTopicSerde.ReadV01(b));
            return new(
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeLogDirsRequest message)
        {
            Encoder.WriteArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV01(b, i));
        }
        private static DescribeLogDirsRequest ReadV02(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, b => DescribableLogDirTopicSerde.ReadV02(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeLogDirsRequest message)
        {
            Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeLogDirsRequest ReadV03(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, b => DescribableLogDirTopicSerde.ReadV03(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeLogDirsRequest message)
        {
            Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeLogDirsRequest ReadV04(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, b => DescribableLogDirTopicSerde.ReadV04(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, DescribeLogDirsRequest message)
        {
            Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribableLogDirTopicSerde
        {
            public static DescribableLogDirTopic ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, DescribableLogDirTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static DescribableLogDirTopic ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, DescribableLogDirTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static DescribableLogDirTopic ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, DescribableLogDirTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribableLogDirTopic ReadV03(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, DescribableLogDirTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribableLogDirTopic ReadV04(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, DescribableLogDirTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}