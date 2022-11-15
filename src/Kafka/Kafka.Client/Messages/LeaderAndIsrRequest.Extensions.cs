using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrTopicState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrTopicState;
using LeaderAndIsrPartitionState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrPartitionState;
using LeaderAndIsrLiveLeader = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrLiveLeader;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrRequestSerde
    {
        private static readonly Func<Stream, LeaderAndIsrRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
        };
        private static readonly Action<Stream, LeaderAndIsrRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static LeaderAndIsrRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, LeaderAndIsrRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static LeaderAndIsrRequest ReadV00(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV00(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV00(b, i));
            Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV00(b, i));
        }
        private static LeaderAndIsrRequest ReadV01(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV01(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV01(b, i));
            Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV01(b, i));
        }
        private static LeaderAndIsrRequest ReadV02(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, b => LeaderAndIsrTopicStateSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV02(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV02(b, i));
            Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV02(b, i));
        }
        private static LeaderAndIsrRequest ReadV03(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, b => LeaderAndIsrTopicStateSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV03(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV03(b, i));
            Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV03(b, i));
        }
        private static LeaderAndIsrRequest ReadV04(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, b => LeaderAndIsrTopicStateSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV04(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV04(b, i));
            Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaderAndIsrRequest ReadV05(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var typeField = Decoder.ReadInt8(buffer);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, b => LeaderAndIsrTopicStateSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV05(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteInt8(buffer, message.TypeField);
            Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV05(b, i));
            Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaderAndIsrRequest ReadV06(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var typeField = Decoder.ReadInt8(buffer);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, b => LeaderAndIsrTopicStateSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, b => LeaderAndIsrLiveLeaderSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static void WriteV06(Stream buffer, LeaderAndIsrRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteInt8(buffer, message.TypeField);
            Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV06(b, i));
            Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class LeaderAndIsrTopicStateSerde
        {
            public static LeaderAndIsrTopicState ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV02(Stream buffer, LeaderAndIsrTopicState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV02(b, i));
            }
            public static LeaderAndIsrTopicState ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV03(Stream buffer, LeaderAndIsrTopicState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV03(b, i));
            }
            public static LeaderAndIsrTopicState ReadV04(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV04(Stream buffer, LeaderAndIsrTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV04(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrTopicState ReadV05(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV05(Stream buffer, LeaderAndIsrTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV05(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrTopicState ReadV06(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, b => LeaderAndIsrPartitionStateSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV06(Stream buffer, LeaderAndIsrTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class LeaderAndIsrPartitionStateSerde
        {
            public static LeaderAndIsrPartitionState ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = ImmutableArray<int>.Empty;
                var removingReplicasField = ImmutableArray<int>.Empty;
                var isNewField = default(bool);
                var leaderRecoveryStateField = default(sbyte);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV00(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static LeaderAndIsrPartitionState ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = ImmutableArray<int>.Empty;
                var removingReplicasField = ImmutableArray<int>.Empty;
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = default(sbyte);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV01(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
            }
            public static LeaderAndIsrPartitionState ReadV02(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = ImmutableArray<int>.Empty;
                var removingReplicasField = ImmutableArray<int>.Empty;
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = default(sbyte);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV02(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
            }
            public static LeaderAndIsrPartitionState ReadV03(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = default(sbyte);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV03(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
            }
            public static LeaderAndIsrPartitionState ReadV04(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV04(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrPartitionState ReadV05(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV05(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrPartitionState ReadV06(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(buffer);
                var leaderRecoveryStateField = Decoder.ReadInt8(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    partitionEpochField,
                    replicasField,
                    addingReplicasField,
                    removingReplicasField,
                    isNewField,
                    leaderRecoveryStateField
                );
            }
            public static void WriteV06(Stream buffer, LeaderAndIsrPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.PartitionEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteBoolean(buffer, message.IsNewField);
                Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class LeaderAndIsrLiveLeaderSerde
        {
            public static LeaderAndIsrLiveLeader ReadV00(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV00(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
            }
            public static LeaderAndIsrLiveLeader ReadV01(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV01(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
            }
            public static LeaderAndIsrLiveLeader ReadV02(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV02(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
            }
            public static LeaderAndIsrLiveLeader ReadV03(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV03(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
            }
            public static LeaderAndIsrLiveLeader ReadV04(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV04(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteCompactString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrLiveLeader ReadV05(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV05(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteCompactString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrLiveLeader ReadV06(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostNameField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static void WriteV06(Stream buffer, LeaderAndIsrLiveLeader message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteCompactString(buffer, message.HostNameField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}