using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EpochEndOffset = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult.EpochEndOffset;
using OffsetForLeaderTopicResult = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochResponseSerde
    {
        private static readonly DecodeDelegate<OffsetForLeaderEpochResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<OffsetForLeaderEpochResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static OffsetForLeaderEpochResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetForLeaderEpochResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetForLeaderEpochResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, ref index, OffsetForLeaderTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
        {
            index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV00);
            return index;
        }
        private static OffsetForLeaderEpochResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, ref index, OffsetForLeaderTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
        {
            index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV01);
            return index;
        }
        private static OffsetForLeaderEpochResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, ref index, OffsetForLeaderTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV02);
            return index;
        }
        private static OffsetForLeaderEpochResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, ref index, OffsetForLeaderTopicResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV03);
            return index;
        }
        private static OffsetForLeaderEpochResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopicResult>(buffer, ref index, OffsetForLeaderTopicResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetForLeaderTopicResultSerde
        {
            public static OffsetForLeaderTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, ref index, EpochEndOffsetSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetForLeaderTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV00);
                return index;
            }
            public static OffsetForLeaderTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, ref index, EpochEndOffsetSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetForLeaderTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV01);
                return index;
            }
            public static OffsetForLeaderTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, ref index, EpochEndOffsetSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetForLeaderTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV02);
                return index;
            }
            public static OffsetForLeaderTopicResult ReadV03(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<EpochEndOffset>(buffer, ref index, EpochEndOffsetSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetForLeaderTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV03);
                return index;
            }
            public static OffsetForLeaderTopicResult ReadV04(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<EpochEndOffset>(buffer, ref index, EpochEndOffsetSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetForLeaderTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV04);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class EpochEndOffsetSerde
            {
                public static EpochEndOffset ReadV00(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = default(int);
                    var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, EpochEndOffset message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                    return index;
                }
                public static EpochEndOffset ReadV01(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, EpochEndOffset message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                    return index;
                }
                public static EpochEndOffset ReadV02(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, EpochEndOffset message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                    return index;
                }
                public static EpochEndOffset ReadV03(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, EpochEndOffset message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                    return index;
                }
                public static EpochEndOffset ReadV04(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        errorCodeField,
                        partitionField,
                        leaderEpochField,
                        endOffsetField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, EpochEndOffset message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}