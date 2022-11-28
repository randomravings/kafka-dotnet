using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaPartitionState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState;
using StopReplicaPartitionV0 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaPartitionV0;
using StopReplicaTopicV1 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicV1;
using StopReplicaTopicState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaRequestSerde
    {
        private static readonly DecodeDelegate<StopReplicaRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<StopReplicaRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static StopReplicaRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, StopReplicaRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static StopReplicaRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var deletePartitionsField = Decoder.ReadBoolean(ref buffer);
            var ungroupedPartitionsField = Decoder.ReadArray<StopReplicaPartitionV0>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionV0Serde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitions'");
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, StopReplicaRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            buffer = Encoder.WriteArray<StopReplicaPartitionV0>(buffer, message.UngroupedPartitionsField, (b, i) => StopReplicaPartitionV0Serde.WriteV00(b, i));
            return buffer;
        }
        private static StopReplicaRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var deletePartitionsField = Decoder.ReadBoolean(ref buffer);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadArray<StopReplicaTopicV1>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaTopicV1Serde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, StopReplicaRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            buffer = Encoder.WriteArray<StopReplicaTopicV1>(buffer, message.TopicsField, (b, i) => StopReplicaTopicV1Serde.WriteV01(b, i));
            return buffer;
        }
        private static StopReplicaRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var deletePartitionsField = Decoder.ReadBoolean(ref buffer);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadCompactArray<StopReplicaTopicV1>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaTopicV1Serde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, StopReplicaRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            buffer = Encoder.WriteCompactArray<StopReplicaTopicV1>(buffer, message.TopicsField, (b, i) => StopReplicaTopicV1Serde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static StopReplicaRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var deletePartitionsField = default(bool);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<StopReplicaTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaTopicStateSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, StopReplicaRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, message.TopicStatesField, (b, i) => StopReplicaTopicStateSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class StopReplicaPartitionV0Serde
        {
            public static StopReplicaPartitionV0 ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, StopReplicaPartitionV0 message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                return buffer;
            }
        }
        private static class StopReplicaTopicV1Serde
        {
            public static StopReplicaTopicV1 ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, StopReplicaTopicV1 message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static StopReplicaTopicV1 ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, StopReplicaTopicV1 message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class StopReplicaTopicStateSerde
        {
            public static StopReplicaTopicState ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionStatesField = Decoder.ReadCompactArray<StopReplicaPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionStateSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, StopReplicaTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, message.PartitionStatesField, (b, i) => StopReplicaPartitionStateSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class StopReplicaPartitionStateSerde
            {
                public static StopReplicaPartitionState ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var deletePartitionField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        deletePartitionField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, StopReplicaPartitionState message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteBoolean(buffer, message.DeletePartitionField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}