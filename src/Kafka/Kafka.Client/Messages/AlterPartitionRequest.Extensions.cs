using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.AlterPartitionRequest.TopicData;
using PartitionData = Kafka.Client.Messages.AlterPartitionRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionRequestSerde
    {
        private static readonly Func<Stream, AlterPartitionRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterPartitionRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterPartitionRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterPartitionRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterPartitionRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, AlterPartitionRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static AlterPartitionRequest ReadV01(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, AlterPartitionRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static AlterPartitionRequest ReadV02(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, AlterPartitionRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
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
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = default(sbyte);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer);
                    var partitionEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}