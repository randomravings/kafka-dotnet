using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetCommitResponseTopic = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic;
using OffsetCommitResponsePartition = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic.OffsetCommitResponsePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitResponseSerde
    {
        private static readonly Func<Stream, OffsetCommitResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
        };
        private static readonly Action<Stream, OffsetCommitResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
        };
        public static OffsetCommitResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetCommitResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetCommitResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV00(b, i));
        }
        private static OffsetCommitResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV01(b, i));
        }
        private static OffsetCommitResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV02(b, i));
        }
        private static OffsetCommitResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV03(b, i));
        }
        private static OffsetCommitResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV04(b, i));
        }
        private static OffsetCommitResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV05(b, i));
        }
        private static OffsetCommitResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV06(b, i));
        }
        private static OffsetCommitResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV07(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV07(b, i));
        }
        private static OffsetCommitResponse ReadV08(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitResponseTopic>(buffer, b => OffsetCommitResponseTopicSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV08(Stream buffer, OffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV08(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetCommitResponseTopicSerde
        {
            public static OffsetCommitResponseTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV00(b, i));
            }
            public static OffsetCommitResponseTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV01(b, i));
            }
            public static OffsetCommitResponseTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV02(b, i));
            }
            public static OffsetCommitResponseTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV03(b, i));
            }
            public static OffsetCommitResponseTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV04(b, i));
            }
            public static OffsetCommitResponseTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV05(b, i));
            }
            public static OffsetCommitResponseTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV06(b, i));
            }
            public static OffsetCommitResponseTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV07(b, i));
            }
            public static OffsetCommitResponseTopic ReadV08(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetCommitResponsePartition>(buffer, b => OffsetCommitResponsePartitionSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV08(Stream buffer, OffsetCommitResponseTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV08(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetCommitResponsePartitionSerde
            {
                public static OffsetCommitResponsePartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV03(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV04(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV05(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV06(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV07(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetCommitResponsePartition ReadV08(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV08(Stream buffer, OffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}