using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsResponseSerde
    {
        private static readonly Func<Stream, ListOffsetsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, ListOffsetsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static ListOffsetsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListOffsetsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListOffsetsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV00(b, i));
        }
        private static ListOffsetsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV01(b, i));
        }
        private static ListOffsetsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV02(b, i));
        }
        private static ListOffsetsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV03(b, i));
        }
        private static ListOffsetsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV04(b, i));
        }
        private static ListOffsetsResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV05(b, i));
        }
        private static ListOffsetsResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static ListOffsetsResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, b => ListOffsetsTopicResponseSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV07(Stream buffer, ListOffsetsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ListOffsetsTopicResponseSerde
        {
            public static ListOffsetsTopicResponse ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV00(b, i));
            }
            public static ListOffsetsTopicResponse ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV01(b, i));
            }
            public static ListOffsetsTopicResponse ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV02(b, i));
            }
            public static ListOffsetsTopicResponse ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV03(b, i));
            }
            public static ListOffsetsTopicResponse ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV04(b, i));
            }
            public static ListOffsetsTopicResponse ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV05(b, i));
            }
            public static ListOffsetsTopicResponse ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static ListOffsetsTopicResponse ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, b => ListOffsetsPartitionResponseSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, ListOffsetsTopicResponse message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class ListOffsetsPartitionResponseSerde
            {
                public static ListOffsetsPartitionResponse ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = Decoder.ReadArray<long>(buffer, b => Decoder.ReadInt64(b)) ?? throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
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
                public static void WriteV00(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteArray<long>(buffer, message.OldStyleOffsetsField, (b, i) => Encoder.WriteInt64(b, i));
                }
                public static ListOffsetsPartitionResponse ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
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
                public static void WriteV01(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                }
                public static ListOffsetsPartitionResponse ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
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
                public static void WriteV02(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                }
                public static ListOffsetsPartitionResponse ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
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
                public static void WriteV03(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                }
                public static ListOffsetsPartitionResponse ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static void WriteV04(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static ListOffsetsPartitionResponse ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static void WriteV05(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static ListOffsetsPartitionResponse ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static void WriteV06(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static ListOffsetsPartitionResponse ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static void WriteV07(Stream buffer, ListOffsetsPartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}