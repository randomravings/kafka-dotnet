using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribableLogDirTopic = Kafka.Client.Messages.DescribeLogDirsRequest.DescribableLogDirTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeLogDirsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<DescribeLogDirsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static DescribeLogDirsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeLogDirsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeLogDirsRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(buffer, ref index, DescribableLogDirTopicSerde.ReadV00);
            return new(
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeLogDirsRequest message)
        {
            index = Encoder.WriteArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV00);
            return index;
        }
        private static DescribeLogDirsRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<DescribableLogDirTopic>(buffer, ref index, DescribableLogDirTopicSerde.ReadV01);
            return new(
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeLogDirsRequest message)
        {
            index = Encoder.WriteArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV01);
            return index;
        }
        private static DescribeLogDirsRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, ref index, DescribableLogDirTopicSerde.ReadV02);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeLogDirsRequest message)
        {
            index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeLogDirsRequest ReadV03(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, ref index, DescribableLogDirTopicSerde.ReadV03);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeLogDirsRequest message)
        {
            index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeLogDirsRequest ReadV04(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, ref index, DescribableLogDirTopicSerde.ReadV04);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DescribeLogDirsRequest message)
        {
            index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribableLogDirTopicSerde
        {
            public static DescribableLogDirTopic ReadV00(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribableLogDirTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static DescribableLogDirTopic ReadV01(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DescribableLogDirTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static DescribableLogDirTopic ReadV02(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DescribableLogDirTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribableLogDirTopic ReadV03(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DescribableLogDirTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribableLogDirTopic ReadV04(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, DescribableLogDirTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}