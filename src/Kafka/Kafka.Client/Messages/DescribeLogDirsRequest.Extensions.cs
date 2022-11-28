using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribableLogDirTopic = Kafka.Client.Messages.DescribeLogDirsRequest.DescribableLogDirTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeLogDirsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<DescribeLogDirsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeLogDirsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeLogDirsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeLogDirsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribableLogDirTopicSerde.ReadV00(ref b));
            return new(
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeLogDirsRequest message)
        {
            buffer = Encoder.WriteArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeLogDirsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribableLogDirTopicSerde.ReadV01(ref b));
            return new(
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeLogDirsRequest message)
        {
            buffer = Encoder.WriteArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeLogDirsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribableLogDirTopicSerde.ReadV02(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeLogDirsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeLogDirsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribableLogDirTopicSerde.ReadV03(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeLogDirsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeLogDirsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribableLogDirTopicSerde.ReadV04(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeLogDirsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, message.TopicsField, (b, i) => DescribableLogDirTopicSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribableLogDirTopicSerde
        {
            public static DescribableLogDirTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribableLogDirTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static DescribableLogDirTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribableLogDirTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static DescribableLogDirTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribableLogDirTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribableLogDirTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribableLogDirTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribableLogDirTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DescribableLogDirTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}