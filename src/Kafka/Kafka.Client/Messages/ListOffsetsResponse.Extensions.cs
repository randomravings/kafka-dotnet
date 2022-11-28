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
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<ListOffsetsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static ListOffsetsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListOffsetsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListOffsetsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV00(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV01(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV02(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV03(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV04(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV05(b, i));
            return buffer;
        }
        private static ListOffsetsResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static ListOffsetsResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicResponseSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicResponseSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ListOffsetsTopicResponseSerde
        {
            public static ListOffsetsTopicResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV00(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV01(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV02(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV03(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV04(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV05(b, i));
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static ListOffsetsTopicResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionResponseSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsTopicResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionResponseSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class ListOffsetsPartitionResponseSerde
            {
                public static ListOffsetsPartitionResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = Decoder.ReadArray<long>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt64(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteArray<long>(buffer, message.OldStyleOffsetsField, (b, i) => Encoder.WriteInt64(b, i));
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static ListOffsetsPartitionResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsPartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}