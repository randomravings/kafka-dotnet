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
        private static readonly DecodeDelegate<OffsetCommitResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
        };
        private static readonly EncodeDelegate<OffsetCommitResponse>[] WRITE_VERSIONS = {
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
        public static OffsetCommitResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetCommitResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetCommitResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV06(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV07(b, i));
            return buffer;
        }
        private static OffsetCommitResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponseTopicSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<OffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitResponseTopicSerde.WriteV08(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetCommitResponseTopicSerde
        {
            public static OffsetCommitResponseTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV06(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV07(b, i));
                return buffer;
            }
            public static OffsetCommitResponseTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitResponsePartitionSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<OffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitResponsePartitionSerde.WriteV08(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetCommitResponsePartitionSerde
            {
                public static OffsetCommitResponsePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetCommitResponsePartition ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}