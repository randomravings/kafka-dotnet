using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaTopicV1 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicV1;
using StopReplicaPartitionState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState;
using StopReplicaPartitionV0 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaPartitionV0;
using StopReplicaTopicState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaRequestSerde
    {
        private static readonly Func<Stream, StopReplicaRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, StopReplicaRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static StopReplicaRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, StopReplicaRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static StopReplicaRequest ReadV00(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var deletePartitionsField = Decoder.ReadBoolean(buffer);
            var ungroupedPartitionsField = Decoder.ReadArray<StopReplicaPartitionV0>(buffer, b => StopReplicaPartitionV0Serde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitions'");
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
        private static void WriteV00(Stream buffer, StopReplicaRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            Encoder.WriteArray<StopReplicaPartitionV0>(buffer, message.UngroupedPartitionsField, (b, i) => StopReplicaPartitionV0Serde.WriteV00(b, i));
        }
        private static StopReplicaRequest ReadV01(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var deletePartitionsField = Decoder.ReadBoolean(buffer);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadArray<StopReplicaTopicV1>(buffer, b => StopReplicaTopicV1Serde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV01(Stream buffer, StopReplicaRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            Encoder.WriteArray<StopReplicaTopicV1>(buffer, message.TopicsField, (b, i) => StopReplicaTopicV1Serde.WriteV01(b, i));
        }
        private static StopReplicaRequest ReadV02(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var deletePartitionsField = Decoder.ReadBoolean(buffer);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadCompactArray<StopReplicaTopicV1>(buffer, b => StopReplicaTopicV1Serde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV02(Stream buffer, StopReplicaRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            Encoder.WriteCompactArray<StopReplicaTopicV1>(buffer, message.TopicsField, (b, i) => StopReplicaTopicV1Serde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static StopReplicaRequest ReadV03(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var deletePartitionsField = default(bool);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<StopReplicaTopicState>(buffer, b => StopReplicaTopicStateSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV03(Stream buffer, StopReplicaRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, message.TopicStatesField, (b, i) => StopReplicaTopicStateSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class StopReplicaTopicV1Serde
        {
            public static StopReplicaTopicV1 ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV01(Stream buffer, StopReplicaTopicV1 message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static StopReplicaTopicV1 ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV02(Stream buffer, StopReplicaTopicV1 message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class StopReplicaPartitionV0Serde
        {
            public static StopReplicaPartitionV0 ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static void WriteV00(Stream buffer, StopReplicaPartitionV0 message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
            }
        }
        private static class StopReplicaTopicStateSerde
        {
            public static StopReplicaTopicState ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionStatesField = Decoder.ReadCompactArray<StopReplicaPartitionState>(buffer, b => StopReplicaPartitionStateSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionStatesField
                );
            }
            public static void WriteV03(Stream buffer, StopReplicaTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, message.PartitionStatesField, (b, i) => StopReplicaPartitionStateSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class StopReplicaPartitionStateSerde
            {
                public static StopReplicaPartitionState ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var deletePartitionField = Decoder.ReadBoolean(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        leaderEpochField,
                        deletePartitionField
                    );
                }
                public static void WriteV03(Stream buffer, StopReplicaPartitionState message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteBoolean(buffer, message.DeletePartitionField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}