using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrTopicState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrTopicState;
using LeaderAndIsrLiveLeader = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrLiveLeader;
using LeaderAndIsrPartitionState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrPartitionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrRequestSerde
    {
        private static readonly DecodeDelegate<LeaderAndIsrRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<LeaderAndIsrRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static LeaderAndIsrRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, LeaderAndIsrRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static LeaderAndIsrRequest ReadV00(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.UngroupedPartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV00);
            index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV00);
            return index;
        }
        private static LeaderAndIsrRequest ReadV01(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.UngroupedPartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV01);
            index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV01);
            return index;
        }
        private static LeaderAndIsrRequest ReadV02(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV02);
            index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV02);
            return index;
        }
        private static LeaderAndIsrRequest ReadV03(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV03);
            index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV03);
            return index;
        }
        private static LeaderAndIsrRequest ReadV04(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = default(sbyte);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV04(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV04);
            index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrRequest ReadV05(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = Decoder.ReadInt8(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV05(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteInt8(buffer, index, message.TypeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV05);
            index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrRequest ReadV06(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = Decoder.ReadInt8(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV06(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteInt8(buffer, index, message.TypeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV06);
            index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrRequest ReadV07(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = Decoder.ReadInt32(buffer, ref index);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var typeField = Decoder.ReadInt8(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, ref index, LeaderAndIsrTopicStateSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveLeadersField = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, ref index, LeaderAndIsrLiveLeaderSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                typeField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveLeadersField
            );
        }
        private static int WriteV07(byte[] buffer, int index, LeaderAndIsrRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteInt8(buffer, index, message.TypeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV07);
            index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class LeaderAndIsrTopicStateSerde
        {
            public static LeaderAndIsrTopicState ReadV02(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV02(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV02);
                return index;
            }
            public static LeaderAndIsrTopicState ReadV03(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionStatesField = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV03(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV03);
                return index;
            }
            public static LeaderAndIsrTopicState ReadV04(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV04(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV04);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrTopicState ReadV05(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV05(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV05);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrTopicState ReadV06(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV06(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrTopicState ReadV07(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, ref index, LeaderAndIsrPartitionStateSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV07(byte[] buffer, int index, LeaderAndIsrTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class LeaderAndIsrLiveLeaderSerde
        {
            public static LeaderAndIsrLiveLeader ReadV00(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV00(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV01(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV01(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV02(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV02(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV03(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV03(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV04(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV04(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV05(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV05(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV06(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV06(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrLiveLeader ReadV07(byte[] buffer, ref int index)
            {
                var BrokerIdField = Decoder.ReadInt32(buffer, ref index);
                var HostNameField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    BrokerIdField,
                    HostNameField,
                    PortField
                );
            }
            public static int WriteV07(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class LeaderAndIsrPartitionStateSerde
        {
            public static LeaderAndIsrPartitionState ReadV00(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = ImmutableArray<int>.Empty;
                var RemovingReplicasField = ImmutableArray<int>.Empty;
                var IsNewField = default(bool);
                var LeaderRecoveryStateField = default(sbyte);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV00(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV01(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = ImmutableArray<int>.Empty;
                var RemovingReplicasField = ImmutableArray<int>.Empty;
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = default(sbyte);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV01(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV02(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = ImmutableArray<int>.Empty;
                var RemovingReplicasField = ImmutableArray<int>.Empty;
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = default(sbyte);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV02(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV03(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var RemovingReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = default(sbyte);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV03(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV04(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var RemovingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV04(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV05(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var RemovingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV05(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV06(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var RemovingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV06(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionState ReadV07(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var PartitionEpochField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var AddingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                var RemovingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                var IsNewField = Decoder.ReadBoolean(buffer, ref index);
                var LeaderRecoveryStateField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    PartitionEpochField,
                    ReplicasField,
                    AddingReplicasField,
                    RemovingReplicasField,
                    IsNewField,
                    LeaderRecoveryStateField
                );
            }
            public static int WriteV07(byte[] buffer, int index, LeaderAndIsrPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
                index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}