using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetCommitResponsePartition = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic.OffsetCommitResponsePartition;
using OffsetCommitResponseTopic = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitResponseSerde
    {
        private static readonly DecodeDelegate<OffsetCommitResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
        };
        private static readonly EncodeDelegate<OffsetCommitResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
        };
        public static OffsetCommitResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetCommitResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetCommitResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV00);
            return index;
        }
        private static OffsetCommitResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV01);
            return index;
        }
        private static OffsetCommitResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV02);
            return index;
        }
        private static OffsetCommitResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV03);
            return index;
        }
        private static OffsetCommitResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV04);
            return index;
        }
        private static OffsetCommitResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV05);
            return index;
        }
        private static OffsetCommitResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV06);
            return index;
        }
        private static OffsetCommitResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV07);
            return index;
        }
        private static OffsetCommitResponse ReadV08(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitResponseTopic>(buffer, ref index, OffsetCommitResponseTopicSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, OffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV08);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetCommitResponseTopicSerde
        {
            public static OffsetCommitResponseTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV00);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV01);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV02);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV03);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV04);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV05);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV06);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV07(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV07);
                return index;
            }
            public static OffsetCommitResponseTopic ReadV08(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<OffsetCommitResponsePartition>(buffer, ref index, OffsetCommitResponsePartitionSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, OffsetCommitResponseTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV08);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetCommitResponsePartitionSerde
            {
                public static OffsetCommitResponsePartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV05(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV06(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV07(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetCommitResponsePartition ReadV08(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, OffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}