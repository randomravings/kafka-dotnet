using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeLogDirsResult = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult;
using DescribeLogDirsPartition = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition;
using DescribeLogDirsTopic = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeLogDirsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<DescribeLogDirsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static DescribeLogDirsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeLogDirsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeLogDirsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(buffer, ref index, DescribeLogDirsResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV00);
            return index;
        }
        private static DescribeLogDirsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadArray<DescribeLogDirsResult>(buffer, ref index, DescribeLogDirsResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV01);
            return index;
        }
        private static DescribeLogDirsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, ref index, DescribeLogDirsResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeLogDirsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, ref index, DescribeLogDirsResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeLogDirsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, ref index, DescribeLogDirsResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                resultsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DescribeLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeLogDirsResultSerde
        {
            public static DescribeLogDirsResult ReadV00(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var logDirField = Decoder.ReadString(buffer, ref index);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, ref index, DescribeLogDirsTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
            public static int WriteV00(byte[] buffer, int index, DescribeLogDirsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.LogDirField);
                index = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV00);
                return index;
            }
            public static DescribeLogDirsResult ReadV01(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var logDirField = Decoder.ReadString(buffer, ref index);
                var topicsField = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, ref index, DescribeLogDirsTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
            public static int WriteV01(byte[] buffer, int index, DescribeLogDirsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.LogDirField);
                index = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV01);
                return index;
            }
            public static DescribeLogDirsResult ReadV02(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var logDirField = Decoder.ReadCompactString(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, ref index, DescribeLogDirsTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DescribeLogDirsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
                index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribeLogDirsResult ReadV03(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var logDirField = Decoder.ReadCompactString(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, ref index, DescribeLogDirsTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = default(long);
                var usableBytesField = default(long);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DescribeLogDirsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
                index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribeLogDirsResult ReadV04(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var logDirField = Decoder.ReadCompactString(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, ref index, DescribeLogDirsTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var totalBytesField = Decoder.ReadInt64(buffer, ref index);
                var usableBytesField = Decoder.ReadInt64(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    logDirField,
                    topicsField,
                    totalBytesField,
                    usableBytesField
                );
            }
            public static int WriteV04(byte[] buffer, int index, DescribeLogDirsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
                index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV04);
                index = Encoder.WriteInt64(buffer, index, message.TotalBytesField);
                index = Encoder.WriteInt64(buffer, index, message.UsableBytesField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DescribeLogDirsTopicSerde
            {
                public static DescribeLogDirsTopic ReadV00(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, ref index, DescribeLogDirsPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, DescribeLogDirsTopic message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV00);
                    return index;
                }
                public static DescribeLogDirsTopic ReadV01(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var partitionsField = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, ref index, DescribeLogDirsPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, DescribeLogDirsTopic message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV01);
                    return index;
                }
                public static DescribeLogDirsTopic ReadV02(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, ref index, DescribeLogDirsPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, DescribeLogDirsTopic message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV02);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static DescribeLogDirsTopic ReadV03(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, ref index, DescribeLogDirsPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, DescribeLogDirsTopic message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV03);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static DescribeLogDirsTopic ReadV04(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionsField = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, ref index, DescribeLogDirsPartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, DescribeLogDirsTopic message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV04);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class DescribeLogDirsPartitionSerde
                {
                    public static DescribeLogDirsPartition ReadV00(byte[] buffer, ref int index)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var partitionSizeField = Decoder.ReadInt64(buffer, ref index);
                        var offsetLagField = Decoder.ReadInt64(buffer, ref index);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer, ref index);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, DescribeLogDirsPartition message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                        index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                        index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                        return index;
                    }
                    public static DescribeLogDirsPartition ReadV01(byte[] buffer, ref int index)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var partitionSizeField = Decoder.ReadInt64(buffer, ref index);
                        var offsetLagField = Decoder.ReadInt64(buffer, ref index);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer, ref index);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static int WriteV01(byte[] buffer, int index, DescribeLogDirsPartition message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                        index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                        index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                        return index;
                    }
                    public static DescribeLogDirsPartition ReadV02(byte[] buffer, ref int index)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var partitionSizeField = Decoder.ReadInt64(buffer, ref index);
                        var offsetLagField = Decoder.ReadInt64(buffer, ref index);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static int WriteV02(byte[] buffer, int index, DescribeLogDirsPartition message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                        index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                        index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static DescribeLogDirsPartition ReadV03(byte[] buffer, ref int index)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var partitionSizeField = Decoder.ReadInt64(buffer, ref index);
                        var offsetLagField = Decoder.ReadInt64(buffer, ref index);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static int WriteV03(byte[] buffer, int index, DescribeLogDirsPartition message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                        index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                        index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static DescribeLogDirsPartition ReadV04(byte[] buffer, ref int index)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var partitionSizeField = Decoder.ReadInt64(buffer, ref index);
                        var offsetLagField = Decoder.ReadInt64(buffer, ref index);
                        var isFutureKeyField = Decoder.ReadBoolean(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            partitionIndexField,
                            partitionSizeField,
                            offsetLagField,
                            isFutureKeyField
                        );
                    }
                    public static int WriteV04(byte[] buffer, int index, DescribeLogDirsPartition message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                        index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                        index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}