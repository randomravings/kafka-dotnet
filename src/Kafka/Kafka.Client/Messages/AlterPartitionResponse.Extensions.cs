using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.AlterPartitionResponse.TopicData;
using PartitionData = Kafka.Client.Messages.AlterPartitionResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionResponseSerde
    {
        private static readonly Func<Stream, AlterPartitionResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterPartitionResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterPartitionResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterPartitionResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterPartitionResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, AlterPartitionResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static AlterPartitionResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, AlterPartitionResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static AlterPartitionResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, AlterPartitionResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicData message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static TopicData ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TopicData message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static TopicData ReadV02(Stream buffer)
            {
                var topicNameField = "";
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, TopicData message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = default(sbyte);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        isrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        isrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        isrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}