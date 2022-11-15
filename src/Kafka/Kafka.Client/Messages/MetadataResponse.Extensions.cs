using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponse.MetadataResponseBroker;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataResponseSerde
    {
        private static readonly Func<Stream, MetadataResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
            b => ReadV10(b),
            b => ReadV11(b),
            b => ReadV12(b),
        };
        private static readonly Action<Stream, MetadataResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
            (b, m) => WriteV10(b, m),
            (b, m) => WriteV11(b, m),
            (b, m) => WriteV12(b, m),
        };
        public static MetadataResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, MetadataResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static MetadataResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV00(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV00(b, i));
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV00(b, i));
        }
        private static MetadataResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV01(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV01(b, i));
        }
        private static MetadataResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV02(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV02(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV02(b, i));
        }
        private static MetadataResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV03(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV03(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV03(b, i));
        }
        private static MetadataResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV04(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV04(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV04(b, i));
        }
        private static MetadataResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV05(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV05(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV05(b, i));
        }
        private static MetadataResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV06(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV06(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV06(b, i));
        }
        private static MetadataResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV07(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV07(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV07(b, i));
        }
        private static MetadataResponse ReadV08(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV08(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV08(b, i));
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV08(b, i));
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
        }
        private static MetadataResponse ReadV09(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV09(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV09(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV09(b, i));
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataResponse ReadV10(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV10(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV10(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV10(b, i));
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataResponse ReadV11(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV11(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV11(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV11(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataResponse ReadV12(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, b => MetadataResponseBrokerSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, b => MetadataResponseTopicSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static void WriteV12(Stream buffer, MetadataResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV12(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV12(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class MetadataResponseBrokerSerde
        {
            public static MetadataResponseBroker ReadV00(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = default(string?);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV00(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
            }
            public static MetadataResponseBroker ReadV01(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV01(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV02(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV02(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV03(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV03(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV04(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV04(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV05(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV05(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV06(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV06(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV07(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV07(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV08(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadNullableString(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV08(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteNullableString(buffer, message.RackField);
            }
            public static MetadataResponseBroker ReadV09(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV09(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseBroker ReadV10(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV10(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseBroker ReadV11(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV11(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseBroker ReadV12(Stream buffer)
            {
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV12(Stream buffer, MetadataResponseBroker message)
            {
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class MetadataResponseTopicSerde
        {
            public static MetadataResponseTopic ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV00(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV00(b, i));
            }
            public static MetadataResponseTopic ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV01(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV01(b, i));
            }
            public static MetadataResponseTopic ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV02(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV02(b, i));
            }
            public static MetadataResponseTopic ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV03(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV03(b, i));
            }
            public static MetadataResponseTopic ReadV04(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV04(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV04(b, i));
            }
            public static MetadataResponseTopic ReadV05(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV05(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV05(b, i));
            }
            public static MetadataResponseTopic ReadV06(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV06(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV06(b, i));
            }
            public static MetadataResponseTopic ReadV07(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV07(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV07(b, i));
            }
            public static MetadataResponseTopic ReadV08(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV08(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV08(b, i));
                Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
            }
            public static MetadataResponseTopic ReadV09(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV09(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV09(b, i));
                Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseTopic ReadV10(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV10(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV10(b, i));
                Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseTopic ReadV11(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV11(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV11(b, i));
                Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataResponseTopic ReadV12(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var nameField = Decoder.ReadCompactNullableString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var isInternalField = Decoder.ReadBoolean(buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, b => MetadataResponsePartitionSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static void WriteV12(Stream buffer, MetadataResponseTopic message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteBoolean(buffer, message.IsInternalField);
                Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV12(b, i));
                Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class MetadataResponsePartitionSerde
            {
                public static MetadataResponsePartition ReadV00(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV00(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV01(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV01(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV02(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV02(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV03(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV03(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV04(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV04(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV05(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV05(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV06(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV06(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV07(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV07(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV08(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV08(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static MetadataResponsePartition ReadV09(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV09(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static MetadataResponsePartition ReadV10(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV10(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static MetadataResponsePartition ReadV11(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV11(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static MetadataResponsePartition ReadV12(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField
                    );
                }
                public static void WriteV12(Stream buffer, MetadataResponsePartition message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}