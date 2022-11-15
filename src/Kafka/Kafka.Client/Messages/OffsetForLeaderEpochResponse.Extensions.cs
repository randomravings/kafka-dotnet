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
        private static readonly Func<Stream, OffsetForLeaderEpochResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, OffsetForLeaderEpochResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static OffsetForLeaderEpochResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetForLeaderEpochResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetForLeaderEpochResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, b => OffsetForLeaderTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetForLeaderEpochResponse message)
        {
            Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV00(b, i));
        }
        private static OffsetForLeaderEpochResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, b => OffsetForLeaderTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, OffsetForLeaderEpochResponse message)
        {
            Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV01(b, i));
        }
        private static OffsetForLeaderEpochResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, b => OffsetForLeaderTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, OffsetForLeaderEpochResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV02(b, i));
        }
        private static OffsetForLeaderEpochResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, b => OffsetForLeaderTopicResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, OffsetForLeaderEpochResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV03(b, i));
        }
        private static OffsetForLeaderEpochResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopicResult>(buffer, b => OffsetForLeaderTopicResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, OffsetForLeaderEpochResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<OffsetForLeaderTopicResult>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicResultSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetForLeaderTopicResultSerde
        {
            public static OffsetForLeaderTopicResult ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, b => EpochEndOffsetSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetForLeaderTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV00(b, i));
            }
            public static OffsetForLeaderTopicResult ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, b => EpochEndOffsetSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, OffsetForLeaderTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV01(b, i));
            }
            public static OffsetForLeaderTopicResult ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, b => EpochEndOffsetSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, OffsetForLeaderTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV02(b, i));
            }
            public static OffsetForLeaderTopicResult ReadV03(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, b => EpochEndOffsetSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, OffsetForLeaderTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV03(b, i));
            }
            public static OffsetForLeaderTopicResult ReadV04(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<EpochEndOffset>(buffer, b => EpochEndOffsetSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, OffsetForLeaderTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<EpochEndOffset>(buffer, message.PartitionsField, (b, i) => EpochEndOffsetSerde.WriteV04(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class EpochEndOffsetSerde
            {
                public static EpochEndOffset ReadV00(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var endOffsetField = Decoder.ReadInt64(buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static void WriteV00(Stream buffer, EpochEndOffset message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.EndOffsetField);
                }
                public static EpochEndOffset ReadV01(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var endOffsetField = Decoder.ReadInt64(buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static void WriteV01(Stream buffer, EpochEndOffset message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.EndOffsetField);
                }
                public static EpochEndOffset ReadV02(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var endOffsetField = Decoder.ReadInt64(buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static void WriteV02(Stream buffer, EpochEndOffset message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.EndOffsetField);
                }
                public static EpochEndOffset ReadV03(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var endOffsetField = Decoder.ReadInt64(buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static void WriteV03(Stream buffer, EpochEndOffset message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.EndOffsetField);
                }
                public static EpochEndOffset ReadV04(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var endOffsetField = Decoder.ReadInt64(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static void WriteV04(Stream buffer, EpochEndOffset message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.EndOffsetField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}