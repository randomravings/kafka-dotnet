using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TxnOffsetCommitResponseTopic = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic;
using TxnOffsetCommitResponsePartition = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic.TxnOffsetCommitResponsePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class TxnOffsetCommitResponseSerde
    {
        private static readonly DecodeDelegate<TxnOffsetCommitResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<TxnOffsetCommitResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static TxnOffsetCommitResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, TxnOffsetCommitResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static TxnOffsetCommitResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponseTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static TxnOffsetCommitResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponseTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static TxnOffsetCommitResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponseTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static TxnOffsetCommitResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponseTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TxnOffsetCommitResponseTopicSerde
        {
            public static TxnOffsetCommitResponseTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponsePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static TxnOffsetCommitResponseTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponsePartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static TxnOffsetCommitResponseTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponsePartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static TxnOffsetCommitResponseTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<TxnOffsetCommitResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitResponsePartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitResponseTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class TxnOffsetCommitResponsePartitionSerde
            {
                public static TxnOffsetCommitResponsePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static TxnOffsetCommitResponsePartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static TxnOffsetCommitResponsePartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static TxnOffsetCommitResponsePartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitResponsePartition message)
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