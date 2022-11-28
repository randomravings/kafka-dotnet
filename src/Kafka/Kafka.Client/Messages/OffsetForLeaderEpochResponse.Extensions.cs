using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using EpochEndOffset = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult.EpochEndOffset;
using OffsetForLeaderTopicResult = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochResponseSerde
    {
        private static readonly DecodeDelegate<OffsetForLeaderEpochResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<OffsetForLeaderEpochResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static OffsetForLeaderEpochResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetForLeaderEpochResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetForLeaderEpochResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetForLeaderEpochResponse message)
        {
            buffer = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetForLeaderEpochResponse message)
        {
            buffer = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetForLeaderEpochResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV02(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetForLeaderEpochResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV03(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetForLeaderEpochResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetForLeaderTopicResultSerde
        {
            public static OffsetForLeaderTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(ref buffer, (ref ReadOnlyMemory<byte> b) => EpochEndOffsetSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetForLeaderTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV00(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(ref buffer, (ref ReadOnlyMemory<byte> b) => EpochEndOffsetSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetForLeaderTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV01(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopicResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(ref buffer, (ref ReadOnlyMemory<byte> b) => EpochEndOffsetSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetForLeaderTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV02(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopicResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(ref buffer, (ref ReadOnlyMemory<byte> b) => EpochEndOffsetSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetForLeaderTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV03(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopicResult ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<EpochEndOffset>(ref buffer, (ref ReadOnlyMemory<byte> b) => EpochEndOffsetSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetForLeaderTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV04(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class EpochEndOffsetSerde
            {
                public static EpochEndOffset ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var endOffsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, EpochEndOffset message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                    return buffer;
                }
                public static EpochEndOffset ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var endOffsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, EpochEndOffset message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                    return buffer;
                }
                public static EpochEndOffset ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var endOffsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, EpochEndOffset message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                    return buffer;
                }
                public static EpochEndOffset ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var endOffsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, EpochEndOffset message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                    return buffer;
                }
                public static EpochEndOffset ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var endOffsetField = Decoder.ReadInt64(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, EpochEndOffset message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}