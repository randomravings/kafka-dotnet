using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdateMetadataBroker = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker;
using UpdateMetadataTopicState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataTopicState;
using UpdateMetadataPartitionState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataPartitionState;
using UpdateMetadataEndpoint = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataRequestSerde
    {
        private static readonly DecodeDelegate<UpdateMetadataRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<UpdateMetadataRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static UpdateMetadataRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, UpdateMetadataRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static UpdateMetadataRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV00(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV00(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV01(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV01(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV02(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV02(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV03(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV03(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV04(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV04(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<UpdateMetadataTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataTopicStateSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV05(b, i));
            buffer = Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV05(b, i));
            return buffer;
        }
        private static UpdateMetadataRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataTopicStateSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV06(b, i));
            buffer = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static UpdateMetadataRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var controllerEpochField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataTopicStateSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataBrokerSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV07(b, i));
            buffer = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class UpdateMetadataBrokerSerde
        {
            public static UpdateMetadataBroker ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = Decoder.ReadString(ref buffer);
                var v0PortField = Decoder.ReadInt32(ref buffer);
                var endpointsField = ImmutableArray<UpdateMetadataEndpoint>.Empty;
                var rackField = default(string?);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteString(buffer, message.V0HostField);
                buffer = Encoder.WriteInt32(buffer, message.V0PortField);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = default(string?);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV01(b, i));
                return buffer;
            }
            public static UpdateMetadataBroker ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV02(b, i));
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV03(b, i));
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV04(b, i));
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV05(b, i));
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV06(b, i));
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static UpdateMetadataBroker ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var idField = Decoder.ReadInt32(ref buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataEndpointSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.IdField);
                buffer = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV07(b, i));
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class UpdateMetadataEndpointSerde
            {
                public static UpdateMetadataEndpoint ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var listenerField = "";
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var listenerField = "";
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var listenerField = Decoder.ReadString(ref buffer);
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteString(buffer, message.ListenerField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var listenerField = Decoder.ReadString(ref buffer);
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteString(buffer, message.ListenerField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var listenerField = Decoder.ReadString(ref buffer);
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteString(buffer, message.ListenerField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var listenerField = Decoder.ReadCompactString(ref buffer);
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteCompactString(buffer, message.HostField);
                    buffer = Encoder.WriteCompactString(buffer, message.ListenerField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static UpdateMetadataEndpoint ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var portField = Decoder.ReadInt32(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var listenerField = Decoder.ReadCompactString(ref buffer);
                    var securityProtocolField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataEndpoint message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PortField);
                    buffer = Encoder.WriteCompactString(buffer, message.HostField);
                    buffer = Encoder.WriteCompactString(buffer, message.ListenerField);
                    buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
        private static class UpdateMetadataTopicStateSerde
        {
            public static UpdateMetadataTopicState ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataTopicState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV05(b, i));
                return buffer;
            }
            public static UpdateMetadataTopicState ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static UpdateMetadataTopicState ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdateMetadataPartitionStateSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataTopicState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class UpdateMetadataPartitionStateSerde
        {
            public static UpdateMetadataPartitionState ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = ImmutableArray<int>.Empty;
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static UpdateMetadataPartitionState ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var controllerEpochField = Decoder.ReadInt32(ref buffer);
                var leaderField = Decoder.ReadInt32(ref buffer);
                var leaderEpochField = Decoder.ReadInt32(ref buffer);
                var isrField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(ref buffer);
                var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    controllerEpochField,
                    leaderField,
                    leaderEpochField,
                    isrField,
                    zkVersionField,
                    replicasField,
                    offlineReplicasField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataPartitionState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt32(buffer, message.ControllerEpochField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderField);
                buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteInt32(buffer, message.ZkVersionField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}