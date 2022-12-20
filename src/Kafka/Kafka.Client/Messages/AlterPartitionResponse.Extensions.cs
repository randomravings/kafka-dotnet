using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.AlterPartitionResponse.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.AlterPartitionResponse.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionResponseSerde
    {
        private static readonly DecodeDelegate<AlterPartitionResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<AlterPartitionResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static AlterPartitionResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterPartitionResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterPartitionResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterPartitionResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static AlterPartitionResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterPartitionResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static AlterPartitionResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AlterPartitionResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static TopicData ReadV01(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static TopicData ReadV02(byte[] buffer, ref int index)
            {
                var topicNameField = "";
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var leaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = default(sbyte);
                    var partitionEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static PartitionData ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var leaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer, ref index);
                    var partitionEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV01(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                    index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static PartitionData ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var leaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var leaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var isrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                    var leaderRecoveryStateField = Decoder.ReadInt8(buffer, ref index);
                    var partitionEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV02(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                    index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}