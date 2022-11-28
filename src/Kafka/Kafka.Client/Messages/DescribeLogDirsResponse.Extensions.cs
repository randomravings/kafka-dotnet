using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeLogDirsPartition = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition;
using DescribeLogDirsTopic = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic;
using DescribeLogDirsResult = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeLogDirsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<DescribeLogDirsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeLogDirsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeLogDirsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeLogDirsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeLogDirsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeLogDirsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeLogDirsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeLogDirsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeLogDirsResultSerde
        {
            public static DescribeLogDirsResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var logDirField = Decoder.ReadString(ref buffer);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeLogDirsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.LogDirField);
                buffer = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV00(b, i));
                return buffer;
            }
            public static DescribeLogDirsResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var logDirField = Decoder.ReadString(ref buffer);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeLogDirsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.LogDirField);
                buffer = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV01(b, i));
                return buffer;
            }
            public static DescribeLogDirsResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var logDirField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeLogDirsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactString(buffer, message.LogDirField);
                buffer = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribeLogDirsResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var logDirField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeLogDirsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactString(buffer, message.LogDirField);
                buffer = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribeLogDirsResult ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var logDirField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = Decoder.ReadInt64(ref buffer);
                var usableBytesField = Decoder.ReadInt64(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeLogDirsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactString(buffer, message.LogDirField);
                buffer = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV04(b, i));
                buffer = Encoder.WriteInt64(buffer, message.TotalBytesField);
                buffer = Encoder.WriteInt64(buffer, message.UsableBytesField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DescribeLogDirsTopicSerde
            {
                public static DescribeLogDirsTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeLogDirsTopic message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV00(b, i));
                    return buffer;
                }
                public static DescribeLogDirsTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeLogDirsTopic message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV01(b, i));
                    return buffer;
                }
                public static DescribeLogDirsTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeLogDirsTopic message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV02(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static DescribeLogDirsTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeLogDirsTopic message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV03(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static DescribeLogDirsTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeLogDirsPartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeLogDirsTopic message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV04(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class DescribeLogDirsPartitionSerde
                {
                    public static DescribeLogDirsPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var partitionSizeField = Decoder.ReadInt64(ref buffer);
                        var offsetLagField = Decoder.ReadInt64(ref buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(ref buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeLogDirsPartition message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        buffer = Encoder.WriteInt64(buffer, message.OffsetLagField);
                        buffer = Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        return buffer;
                    }
                    public static DescribeLogDirsPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var partitionSizeField = Decoder.ReadInt64(ref buffer);
                        var offsetLagField = Decoder.ReadInt64(ref buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(ref buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeLogDirsPartition message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        buffer = Encoder.WriteInt64(buffer, message.OffsetLagField);
                        buffer = Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        return buffer;
                    }
                    public static DescribeLogDirsPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var partitionSizeField = Decoder.ReadInt64(ref buffer);
                        var offsetLagField = Decoder.ReadInt64(ref buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeLogDirsPartition message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        buffer = Encoder.WriteInt64(buffer, message.OffsetLagField);
                        buffer = Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static DescribeLogDirsPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var partitionSizeField = Decoder.ReadInt64(ref buffer);
                        var offsetLagField = Decoder.ReadInt64(ref buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeLogDirsPartition message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        buffer = Encoder.WriteInt64(buffer, message.OffsetLagField);
                        buffer = Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static DescribeLogDirsPartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var partitionSizeField = Decoder.ReadInt64(ref buffer);
                        var offsetLagField = Decoder.ReadInt64(ref buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeLogDirsPartition message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        buffer = Encoder.WriteInt64(buffer, message.OffsetLagField);
                        buffer = Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}