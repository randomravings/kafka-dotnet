using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaPartitionV0 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaPartitionV0;
using StopReplicaTopicState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState;
using StopReplicaTopicV1 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicV1;
using StopReplicaPartitionState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaRequestSerde
    {
        private static readonly DecodeDelegate<StopReplicaRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<StopReplicaRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static StopReplicaRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, StopReplicaRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static StopReplicaRequest ReadV00(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var deletePartitionsField = Decoder.ReadBoolean(buffer, ref index);
            var ungroupedPartitionsField = Decoder.ReadArray<StopReplicaPartitionV0>(buffer, ref index, StopReplicaPartitionV0Serde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitions'");
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, StopReplicaRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
            index = Encoder.WriteArray<StopReplicaPartitionV0>(buffer, index, message.UngroupedPartitionsField, StopReplicaPartitionV0Serde.WriteV00);
            return index;
        }
        private static StopReplicaRequest ReadV01(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var deletePartitionsField = Decoder.ReadBoolean(buffer, ref index);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadArray<StopReplicaTopicV1>(buffer, ref index, StopReplicaTopicV1Serde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, StopReplicaRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
            index = Encoder.WriteArray<StopReplicaTopicV1>(buffer, index, message.TopicsField, StopReplicaTopicV1Serde.WriteV01);
            return index;
        }
        private static StopReplicaRequest ReadV02(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var deletePartitionsField = Decoder.ReadBoolean(buffer, ref index);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = Decoder.ReadCompactArray<StopReplicaTopicV1>(buffer, ref index, StopReplicaTopicV1Serde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, StopReplicaRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
            index = Encoder.WriteCompactArray<StopReplicaTopicV1>(buffer, index, message.TopicsField, StopReplicaTopicV1Serde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static StopReplicaRequest ReadV03(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var deletePartitionsField = default(bool);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<StopReplicaTopicState>(buffer, ref index, StopReplicaTopicStateSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static int WriteV03(byte[] buffer, int index, StopReplicaRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, index, message.TopicStatesField, StopReplicaTopicStateSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static StopReplicaRequest ReadV04(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = Decoder.ReadInt32(buffer, ref index);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var deletePartitionsField = default(bool);
            var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
            var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<StopReplicaTopicState>(buffer, ref index, StopReplicaTopicStateSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                deletePartitionsField,
                ungroupedPartitionsField,
                topicsField,
                topicStatesField
            );
        }
        private static int WriteV04(byte[] buffer, int index, StopReplicaRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, index, message.TopicStatesField, StopReplicaTopicStateSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class StopReplicaPartitionV0Serde
        {
            public static StopReplicaPartitionV0 ReadV00(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField
                );
            }
            public static int WriteV00(byte[] buffer, int index, StopReplicaPartitionV0 message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                return index;
            }
        }
        private static class StopReplicaTopicStateSerde
        {
            public static StopReplicaTopicState ReadV03(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<StopReplicaPartitionState>(buffer, ref index, StopReplicaPartitionStateSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionStatesField
                );
            }
            public static int WriteV03(byte[] buffer, int index, StopReplicaTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, index, message.PartitionStatesField, StopReplicaPartitionStateSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static StopReplicaTopicState ReadV04(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<StopReplicaPartitionState>(buffer, ref index, StopReplicaPartitionStateSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionStatesField
                );
            }
            public static int WriteV04(byte[] buffer, int index, StopReplicaTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, index, message.PartitionStatesField, StopReplicaPartitionStateSerde.WriteV04);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class StopReplicaPartitionStateSerde
            {
                public static StopReplicaPartitionState ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var DeletePartitionField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        LeaderEpochField,
                        DeletePartitionField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, StopReplicaPartitionState message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static StopReplicaPartitionState ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var DeletePartitionField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        LeaderEpochField,
                        DeletePartitionField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, StopReplicaPartitionState message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class StopReplicaTopicV1Serde
        {
            public static StopReplicaTopicV1 ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    NameField,
                    PartitionIndexesField
                );
            }
            public static int WriteV01(byte[] buffer, int index, StopReplicaTopicV1 message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static StopReplicaTopicV1 ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionIndexesField
                );
            }
            public static int WriteV02(byte[] buffer, int index, StopReplicaTopicV1 message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}