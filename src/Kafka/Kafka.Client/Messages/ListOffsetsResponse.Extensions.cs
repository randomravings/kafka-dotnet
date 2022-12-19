using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsResponseSerde
    {
        private static readonly DecodeDelegate<ListOffsetsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<ListOffsetsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static ListOffsetsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListOffsetsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListOffsetsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV00);
            return index;
        }
        private static ListOffsetsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV01);
            return index;
        }
        private static ListOffsetsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV02);
            return index;
        }
        private static ListOffsetsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV03);
            return index;
        }
        private static ListOffsetsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV04);
            return index;
        }
        private static ListOffsetsResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV05);
            return index;
        }
        private static ListOffsetsResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static ListOffsetsResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, ref index, ListOffsetsTopicResponseSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ListOffsetsTopicResponseSerde
        {
            public static ListOffsetsTopicResponse ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV00);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV01);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV02);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV03);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV04);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV05);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static ListOffsetsTopicResponse ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, ref index, ListOffsetsPartitionResponseSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class ListOffsetsPartitionResponseSerde
            {
                public static ListOffsetsPartitionResponse ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = Decoder.ReadArray<long>(buffer, ref index, Decoder.ReadInt64) ?? throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteArray<long>(buffer, index, message.OldStyleOffsetsField, Encoder.WriteInt64);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = default(int);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = default(int);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV03(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = default(int);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV04(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV05(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV06(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static ListOffsetsPartitionResponse ReadV07(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer, ref index);
                    var offsetField = Decoder.ReadInt64(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}