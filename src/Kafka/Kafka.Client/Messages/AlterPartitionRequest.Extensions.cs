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
        private static readonly DecodeDelegate<AlterPartitionRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<AlterPartitionRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterPartitionRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterPartitionRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterPartitionRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterPartitionRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static AlterPartitionRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterPartitionRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static AlterPartitionRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AlterPartitionRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static TopicData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static TopicData ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = default(sbyte);
                    var partitionEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static PartitionData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(ref buffer);
                    var partitionEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static PartitionData ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var newIsrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'NewIsr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(ref buffer);
                    var partitionEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        newIsrField,
                        leaderRecoveryStateField,
                        partitionEpochField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.NewIsrField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}