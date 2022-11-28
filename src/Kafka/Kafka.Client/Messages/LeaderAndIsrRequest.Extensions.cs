using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrLiveLeader = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrLiveLeader;
using LeaderAndIsrPartitionState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrPartitionState;
using LeaderAndIsrTopicState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrRequestSerde
    {
        private static readonly DecodeDelegate<LeaderAndIsrRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
        };
        private static readonly EncodeDelegate<LeaderAndIsrRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static LeaderAndIsrRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, LeaderAndIsrRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static LeaderAndIsrRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV00(b, i));
            buffer = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV00(b, i));
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV01(b, i));
            buffer = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV01(b, i));
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicStateSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV02(b, i));
            buffer = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV02(b, i));
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicStateSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV03(b, i));
            buffer = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV03(b, i));
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicStateSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV04(b, i));
            buffer = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var typeField = Decoder.ReadInt8(ref buffer);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicStateSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteInt8(buffer, message.TypeField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV05(b, i));
            buffer = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaderAndIsrRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var typeField = Decoder.ReadInt8(ref buffer);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicStateSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrLiveLeaderSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteInt8(buffer, message.TypeField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, message.TopicStatesField, (b, i) => LeaderAndIsrTopicStateSerde.WriteV06(b, i));
            buffer = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, message.LiveLeadersField, (b, i) => LeaderAndIsrLiveLeaderSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class LeaderAndIsrLiveLeaderSerde
        {
            public static LeaderAndIsrLiveLeader ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrLiveLeader ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostNameField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostNameField,
                    portField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrLiveLeader message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostNameField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class LeaderAndIsrPartitionStateSerde
        {
            public static LeaderAndIsrPartitionState ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
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
            public static Memory<byte> WriteV00(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = ImmutableArray<int>.Empty;
                var removingReplicasField = ImmutableArray<int>.Empty;
                var isNewField = Decoder.ReadBoolean(ref buffer);
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
            public static Memory<byte> WriteV01(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = ImmutableArray<int>.Empty;
                var removingReplicasField = ImmutableArray<int>.Empty;
                var isNewField = Decoder.ReadBoolean(ref buffer);
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
            public static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(ref buffer);
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
            public static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(ref buffer);
                var leaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(ref buffer);
                var leaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrPartitionState ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var partitionEpochField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var addingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var removingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var isNewField = Decoder.ReadBoolean(ref buffer);
                var leaderRecoveryStateField = Decoder.ReadInt8(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.PartitionEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteBoolean(buffer, message.IsNewField);
                buffer = Encoder.WriteInt8(buffer, message.LeaderRecoveryStateField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class LeaderAndIsrTopicStateSerde
        {
            public static LeaderAndIsrTopicState ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrTopicState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV02(b, i));
                return buffer;
            }
            public static LeaderAndIsrTopicState ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrTopicState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV03(b, i));
                return buffer;
            }
            public static LeaderAndIsrTopicState ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV04(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrTopicState ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV05(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrTopicState ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionStateSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, message.PartitionStatesField, (b, i) => LeaderAndIsrPartitionStateSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}