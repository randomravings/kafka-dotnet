using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeLogDirsResult = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult;
using DescribeLogDirsPartition = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition;
using DescribeLogDirsTopic = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsResponseSerde
    {
        private static readonly Func<Stream, DescribeLogDirsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, DescribeLogDirsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeLogDirsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeLogDirsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeLogDirsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(buffer, b => DescribeLogDirsResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV00(b, i));
        }
        private static DescribeLogDirsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(buffer, b => DescribeLogDirsResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV01(b, i));
        }
        private static DescribeLogDirsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, b => DescribeLogDirsResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeLogDirsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, b => DescribeLogDirsResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeLogDirsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, b => DescribeLogDirsResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static void WriteV04(Stream buffer, DescribeLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, message.ResultsField, (b, i) => DescribeLogDirsResultSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeLogDirsResultSerde
        {
            public static DescribeLogDirsResult ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var logDirField = Decoder.ReadString(buffer);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, b => DescribeLogDirsTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
            public static void WriteV00(Stream buffer, DescribeLogDirsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.LogDirField);
                Encoder.WriteArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV00(b, i));
            }
            public static DescribeLogDirsResult ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var logDirField = Decoder.ReadString(buffer);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, b => DescribeLogDirsTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
            public static void WriteV01(Stream buffer, DescribeLogDirsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.LogDirField);
                Encoder.WriteArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV01(b, i));
            }
            public static DescribeLogDirsResult ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var logDirField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, b => DescribeLogDirsTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static void WriteV02(Stream buffer, DescribeLogDirsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactString(buffer, message.LogDirField);
                Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribeLogDirsResult ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var logDirField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, b => DescribeLogDirsTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static void WriteV03(Stream buffer, DescribeLogDirsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactString(buffer, message.LogDirField);
                Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribeLogDirsResult ReadV04(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var logDirField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, b => DescribeLogDirsTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = Decoder.ReadInt64(buffer);
                var usableBytesField = Decoder.ReadInt64(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static void WriteV04(Stream buffer, DescribeLogDirsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactString(buffer, message.LogDirField);
                Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, message.TopicsField, (b, i) => DescribeLogDirsTopicSerde.WriteV04(b, i));
                Encoder.WriteInt64(buffer, message.TotalBytesField);
                Encoder.WriteInt64(buffer, message.UsableBytesField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DescribeLogDirsTopicSerde
            {
                public static DescribeLogDirsTopic ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, b => DescribeLogDirsPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV00(Stream buffer, DescribeLogDirsTopic message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV00(b, i));
                }
                public static DescribeLogDirsTopic ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, b => DescribeLogDirsPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV01(Stream buffer, DescribeLogDirsTopic message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV01(b, i));
                }
                public static DescribeLogDirsTopic ReadV02(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, b => DescribeLogDirsPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV02(Stream buffer, DescribeLogDirsTopic message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV02(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static DescribeLogDirsTopic ReadV03(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, b => DescribeLogDirsPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV03(Stream buffer, DescribeLogDirsTopic message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV03(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static DescribeLogDirsTopic ReadV04(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, b => DescribeLogDirsPartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV04(Stream buffer, DescribeLogDirsTopic message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, message.PartitionsField, (b, i) => DescribeLogDirsPartitionSerde.WriteV04(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class DescribeLogDirsPartitionSerde
                {
                    public static DescribeLogDirsPartition ReadV00(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var partitionSizeField = Decoder.ReadInt64(buffer);
                        var offsetLagField = Decoder.ReadInt64(buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static void WriteV00(Stream buffer, DescribeLogDirsPartition message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        Encoder.WriteInt64(buffer, message.OffsetLagField);
                        Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                    }
                    public static DescribeLogDirsPartition ReadV01(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var partitionSizeField = Decoder.ReadInt64(buffer);
                        var offsetLagField = Decoder.ReadInt64(buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static void WriteV01(Stream buffer, DescribeLogDirsPartition message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        Encoder.WriteInt64(buffer, message.OffsetLagField);
                        Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                    }
                    public static DescribeLogDirsPartition ReadV02(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var partitionSizeField = Decoder.ReadInt64(buffer);
                        var offsetLagField = Decoder.ReadInt64(buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static void WriteV02(Stream buffer, DescribeLogDirsPartition message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        Encoder.WriteInt64(buffer, message.OffsetLagField);
                        Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static DescribeLogDirsPartition ReadV03(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var partitionSizeField = Decoder.ReadInt64(buffer);
                        var offsetLagField = Decoder.ReadInt64(buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static void WriteV03(Stream buffer, DescribeLogDirsPartition message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        Encoder.WriteInt64(buffer, message.OffsetLagField);
                        Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static DescribeLogDirsPartition ReadV04(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var partitionSizeField = Decoder.ReadInt64(buffer);
                        var offsetLagField = Decoder.ReadInt64(buffer);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static void WriteV04(Stream buffer, DescribeLogDirsPartition message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.PartitionSizeField);
                        Encoder.WriteInt64(buffer, message.OffsetLagField);
                        Encoder.WriteBoolean(buffer, message.IsFutureKeyField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}