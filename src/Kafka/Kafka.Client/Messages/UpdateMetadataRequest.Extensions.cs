using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdateMetadataBroker = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker;
using UpdateMetadataEndpoint = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint;
using UpdateMetadataTopicState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataTopicState;
using UpdateMetadataPartitionState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataPartitionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataRequestSerde
    {
        private static readonly Func<Stream, UpdateMetadataRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, UpdateMetadataRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static UpdateMetadataRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UpdateMetadataRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UpdateMetadataRequest ReadV00(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV00(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV00(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV00(b, i));
        }
        private static UpdateMetadataRequest ReadV01(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV01(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV01(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV01(b, i));
        }
        private static UpdateMetadataRequest ReadV02(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV02(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV02(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV02(b, i));
        }
        private static UpdateMetadataRequest ReadV03(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV03(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV03(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV03(b, i));
        }
        private static UpdateMetadataRequest ReadV04(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            var ungroupedPartitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
            var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV04(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.UngroupedPartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV04(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV04(b, i));
        }
        private static UpdateMetadataRequest ReadV05(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadArray<UpdateMetadataTopicState>(buffer, b => UpdateMetadataTopicStateSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV05(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV05(b, i));
            Encoder.WriteArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV05(b, i));
        }
        private static UpdateMetadataRequest ReadV06(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, b => UpdateMetadataTopicStateSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV06(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV06(b, i));
            Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static UpdateMetadataRequest ReadV07(Stream buffer)
        {
            var controllerIdField = Decoder.ReadInt32(buffer);
            var controllerEpochField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
            var topicStatesField = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, b => UpdateMetadataTopicStateSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicStates'");
            var liveBrokersField = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, b => UpdateMetadataBrokerSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                controllerIdField,
                controllerEpochField,
                brokerEpochField,
                ungroupedPartitionStatesField,
                topicStatesField,
                liveBrokersField
            );
        }
        private static void WriteV07(Stream buffer, UpdateMetadataRequest message)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, message.TopicStatesField, (b, i) => UpdateMetadataTopicStateSerde.WriteV07(b, i));
            Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, message.LiveBrokersField, (b, i) => UpdateMetadataBrokerSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class UpdateMetadataBrokerSerde
        {
            public static UpdateMetadataBroker ReadV00(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = Decoder.ReadString(buffer);
                var v0PortField = Decoder.ReadInt32(buffer);
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
            public static void WriteV00(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteString(buffer, message.V0HostField);
                Encoder.WriteInt32(buffer, message.V0PortField);
            }
            public static UpdateMetadataBroker ReadV01(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = default(string?);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV01(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV01(b, i));
            }
            public static UpdateMetadataBroker ReadV02(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV02(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV02(b, i));
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static UpdateMetadataBroker ReadV03(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV03(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV03(b, i));
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static UpdateMetadataBroker ReadV04(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV04(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV04(b, i));
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static UpdateMetadataBroker ReadV05(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV05(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV05(b, i));
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static UpdateMetadataBroker ReadV06(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV06(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV06(b, i));
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static UpdateMetadataBroker ReadV07(Stream buffer)
            {
                var idField = Decoder.ReadInt32(buffer);
                var v0HostField = "";
                var v0PortField = default(int);
                var endpointsField = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, b => UpdateMetadataEndpointSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Endpoints'");
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    idField,
                    v0HostField,
                    v0PortField,
                    endpointsField,
                    rackField
                );
            }
            public static void WriteV07(Stream buffer, UpdateMetadataBroker message)
            {
                Encoder.WriteInt32(buffer, message.IdField);
                Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, message.EndpointsField, (b, i) => UpdateMetadataEndpointSerde.WriteV07(b, i));
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class UpdateMetadataEndpointSerde
            {
                public static UpdateMetadataEndpoint ReadV01(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var listenerField = "";
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV01(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                }
                public static UpdateMetadataEndpoint ReadV02(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var listenerField = "";
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV02(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                }
                public static UpdateMetadataEndpoint ReadV03(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var listenerField = Decoder.ReadString(buffer);
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV03(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteString(buffer, message.ListenerField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                }
                public static UpdateMetadataEndpoint ReadV04(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var listenerField = Decoder.ReadString(buffer);
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV04(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteString(buffer, message.ListenerField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                }
                public static UpdateMetadataEndpoint ReadV05(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var listenerField = Decoder.ReadString(buffer);
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV05(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteString(buffer, message.ListenerField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                }
                public static UpdateMetadataEndpoint ReadV06(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var listenerField = Decoder.ReadCompactString(buffer);
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV06(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteCompactString(buffer, message.HostField);
                    Encoder.WriteCompactString(buffer, message.ListenerField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static UpdateMetadataEndpoint ReadV07(Stream buffer)
                {
                    var portField = Decoder.ReadInt32(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var listenerField = Decoder.ReadCompactString(buffer);
                    var securityProtocolField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        portField,
                        hostField,
                        listenerField,
                        securityProtocolField
                    );
                }
                public static void WriteV07(Stream buffer, UpdateMetadataEndpoint message)
                {
                    Encoder.WriteInt32(buffer, message.PortField);
                    Encoder.WriteCompactString(buffer, message.HostField);
                    Encoder.WriteCompactString(buffer, message.ListenerField);
                    Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
        private static class UpdateMetadataTopicStateSerde
        {
            public static UpdateMetadataTopicState ReadV05(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV05(Stream buffer, UpdateMetadataTopicState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV05(b, i));
            }
            public static UpdateMetadataTopicState ReadV06(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV06(Stream buffer, UpdateMetadataTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static UpdateMetadataTopicState ReadV07(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionStatesField = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, b => UpdateMetadataPartitionStateSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionStates'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    topicIdField,
                    partitionStatesField
                );
            }
            public static void WriteV07(Stream buffer, UpdateMetadataTopicState message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, message.PartitionStatesField, (b, i) => UpdateMetadataPartitionStateSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class UpdateMetadataPartitionStateSerde
        {
            public static UpdateMetadataPartitionState ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
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
            public static void WriteV00(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
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
            public static void WriteV01(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
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
            public static void WriteV02(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
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
            public static void WriteV03(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV04(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
            public static void WriteV04(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV05(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
            public static void WriteV05(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static UpdateMetadataPartitionState ReadV06(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV06(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static UpdateMetadataPartitionState ReadV07(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var controllerEpochField = Decoder.ReadInt32(buffer);
                var leaderField = Decoder.ReadInt32(buffer);
                var leaderEpochField = Decoder.ReadInt32(buffer);
                var isrField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Isr'");
                var zkVersionField = Decoder.ReadInt32(buffer);
                var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV07(Stream buffer, UpdateMetadataPartitionState message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt32(buffer, message.ControllerEpochField);
                Encoder.WriteInt32(buffer, message.LeaderField);
                Encoder.WriteInt32(buffer, message.LeaderEpochField);
                Encoder.WriteCompactArray<int>(buffer, message.IsrField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteInt32(buffer, message.ZkVersionField);
                Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}