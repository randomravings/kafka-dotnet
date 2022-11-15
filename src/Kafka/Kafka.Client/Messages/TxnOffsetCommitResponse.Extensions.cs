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
        private static readonly Func<Stream, TxnOffsetCommitResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, TxnOffsetCommitResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static TxnOffsetCommitResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, TxnOffsetCommitResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static TxnOffsetCommitResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, b => TxnOffsetCommitResponseTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, TxnOffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV00(b, i));
        }
        private static TxnOffsetCommitResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, b => TxnOffsetCommitResponseTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, TxnOffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV01(b, i));
        }
        private static TxnOffsetCommitResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, b => TxnOffsetCommitResponseTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, TxnOffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV02(b, i));
        }
        private static TxnOffsetCommitResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitResponseTopic>(buffer, b => TxnOffsetCommitResponseTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, TxnOffsetCommitResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<TxnOffsetCommitResponseTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitResponseTopicSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TxnOffsetCommitResponseTopicSerde
        {
            public static TxnOffsetCommitResponseTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, b => TxnOffsetCommitResponsePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TxnOffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV00(b, i));
            }
            public static TxnOffsetCommitResponseTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, b => TxnOffsetCommitResponsePartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TxnOffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV01(b, i));
            }
            public static TxnOffsetCommitResponseTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, b => TxnOffsetCommitResponsePartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, TxnOffsetCommitResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV02(b, i));
            }
            public static TxnOffsetCommitResponseTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<TxnOffsetCommitResponsePartition>(buffer, b => TxnOffsetCommitResponsePartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, TxnOffsetCommitResponseTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<TxnOffsetCommitResponsePartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitResponsePartitionSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class TxnOffsetCommitResponsePartitionSerde
            {
                public static TxnOffsetCommitResponsePartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, TxnOffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static TxnOffsetCommitResponsePartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, TxnOffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static TxnOffsetCommitResponsePartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, TxnOffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static TxnOffsetCommitResponsePartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV03(Stream buffer, TxnOffsetCommitResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}