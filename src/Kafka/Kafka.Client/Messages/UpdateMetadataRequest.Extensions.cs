using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdateMetadataPartitionState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataPartitionState;
using UpdateMetadataBroker = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker;
using UpdateMetadataEndpoint = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint;
using UpdateMetadataTopicState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataRequestSerde
    {
        private static readonly DecodeDelegate<UpdateMetadataRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
        };
        private static readonly EncodeDelegate<UpdateMetadataRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
        };
        public static UpdateMetadataRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UpdateMetadataRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UpdateMetadataRequest ReadV00(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV00);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV00);
            return index;
        }
        private static UpdateMetadataRequest ReadV01(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV01);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV01);
            return index;
        }
        private static UpdateMetadataRequest ReadV02(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV02);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV02);
            return index;
        }
        private static UpdateMetadataRequest ReadV03(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV03);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV03);
            return index;
        }
        private static UpdateMetadataRequest ReadV04(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV04(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV04);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV04);
            return index;
        }
        private static UpdateMetadataRequest ReadV05(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<UpdateMetadataTopicState>(buffer, ref index, UpdateMetadataTopicStateSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV05(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV05);
            index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV05);
            return index;
        }
        private static UpdateMetadataRequest ReadV06(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, ref index, UpdateMetadataTopicStateSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV06(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV06);
            index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateMetadataRequest ReadV07(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = default(int);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, ref index, UpdateMetadataTopicStateSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV07(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV07);
            index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateMetadataRequest ReadV08(byte[] buffer, ref int index)
        {
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var kRaftControllerIdField = Decoder.ReadInt32(buffer, ref index);
            var controllerEpochField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, ref index, UpdateMetadataTopicStateSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, ref index, UpdateMetadataBrokerSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                controllerIdField,
                kRaftControllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static int WriteV08(byte[] buffer, int index, UpdateMetadataRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV08);
            index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV08);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class UpdateMetadataPartitionStateSerde
        {
            public static UpdateMetadataPartitionState ReadV00(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV00(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV01(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV01(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV02(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV02(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV03(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV03(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV04(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV04(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV05(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV05(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV06(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV06(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV07(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV07(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataPartitionState ReadV08(byte[] buffer, ref int index)
            {
                var TopicNameField = "";
                var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var ControllerEpochField = Decoder.ReadInt32(buffer, ref index);
                var LeaderField = Decoder.ReadInt32(buffer, ref index);
                var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                var IsrField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var ZkVersionField = Decoder.ReadInt32(buffer, ref index);
                var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionIndexField,
                    ControllerEpochField,
                    LeaderField,
                    LeaderEpochField,
                    IsrField,
                    ZkVersionField,
                    ReplicasField,
                    OfflineReplicasField
                );
            }
            public static int WriteV08(byte[] buffer, int index, UpdateMetadataPartitionState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderField);
                index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class UpdateMetadataBrokerSerde
        {
            public static UpdateMetadataBroker ReadV00(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = Decoder.ReadString(buffer, ref index);
                var V0PortField = Decoder.ReadInt32(buffer, ref index);
                var EndpointsField = ImmutableArray<UpdateMetadataEndpoint>.Empty;
                var RackField = default(string?);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV00(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteString(buffer, index, message.V0HostField);
                index = Encoder.WriteInt32(buffer, index, message.V0PortField);
                return index;
            }
            public static UpdateMetadataBroker ReadV01(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = default(string?);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV01(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV01);
                return index;
            }
            public static UpdateMetadataBroker ReadV02(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV02(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV02);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static UpdateMetadataBroker ReadV03(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV03(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV03);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static UpdateMetadataBroker ReadV04(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV04(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV04);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static UpdateMetadataBroker ReadV05(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV05(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV05);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static UpdateMetadataBroker ReadV06(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV06(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV06);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataBroker ReadV07(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV07(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV07);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataBroker ReadV08(byte[] buffer, ref int index)
            {
                var IdField = Decoder.ReadInt32(buffer, ref index);
                var V0HostField = "";
                var V0PortField = default(int);
                var EndpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, ref index, UpdateMetadataEndpointSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    IdField,
                    V0HostField,
                    V0PortField,
                    EndpointsField,
                    RackField
                );
            }
            public static int WriteV08(byte[] buffer, int index, UpdateMetadataBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.IdField);
                index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV08);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class UpdateMetadataEndpointSerde
            {
                public static UpdateMetadataEndpoint ReadV01(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadString(buffer, ref index);
                    var ListenerField = "";
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV02(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadString(buffer, ref index);
                    var ListenerField = "";
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV03(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadString(buffer, ref index);
                    var ListenerField = Decoder.ReadString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV04(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadString(buffer, ref index);
                    var ListenerField = Decoder.ReadString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV05(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadString(buffer, ref index);
                    var ListenerField = Decoder.ReadString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV06(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadCompactString(buffer, ref index);
                    var ListenerField = Decoder.ReadCompactString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteCompactString(buffer, index, message.HostField);
                    index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV07(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadCompactString(buffer, ref index);
                    var ListenerField = Decoder.ReadCompactString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteCompactString(buffer, index, message.HostField);
                    index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static UpdateMetadataEndpoint ReadV08(byte[] buffer, ref int index)
                {
                    var PortField = Decoder.ReadInt32(buffer, ref index);
                    var HostField = Decoder.ReadCompactString(buffer, ref index);
                    var ListenerField = Decoder.ReadCompactString(buffer, ref index);
                    var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PortField,
                        HostField,
                        ListenerField,
                        SecurityProtocolField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, UpdateMetadataEndpoint message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PortField);
                    index = Encoder.WriteCompactString(buffer, index, message.HostField);
                    index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                    index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class UpdateMetadataTopicStateSerde
        {
            public static UpdateMetadataTopicState ReadV05(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV05(byte[] buffer, int index, UpdateMetadataTopicState message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV05);
                return index;
            }
            public static UpdateMetadataTopicState ReadV06(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV06(byte[] buffer, int index, UpdateMetadataTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataTopicState ReadV07(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV07(byte[] buffer, int index, UpdateMetadataTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdateMetadataTopicState ReadV08(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, ref index, UpdateMetadataPartitionStateSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    TopicIdField,
                    PartitionStatesField
                );
            }
            public static int WriteV08(byte[] buffer, int index, UpdateMetadataTopicState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV08);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}