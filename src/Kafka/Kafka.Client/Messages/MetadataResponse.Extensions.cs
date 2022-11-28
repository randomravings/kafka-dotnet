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
        private static readonly DecodeDelegate<MetadataResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV10(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV11(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV12(ref b),
        };
        private static readonly EncodeDelegate<MetadataResponse>[] WRITE_VERSIONS = {
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
        public static MetadataResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, MetadataResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static MetadataResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV00(b, i));
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV02(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV03(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV04(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV04(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV05(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV05(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV06(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV06(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV06(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV07(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV07(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV07(b, i));
            return buffer;
        }
        private static MetadataResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV08(b, i));
            buffer = Encoder.WriteNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV08(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            return buffer;
        }
        private static MetadataResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV09(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV09(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataResponse ReadV10(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV10(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV10(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV10(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataResponse ReadV11(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV11(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV11(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV11(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataResponse ReadV12(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseBrokerSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponseTopicSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV12(Memory<byte> buffer, MetadataResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, message.BrokersField, (b, i) => MetadataResponseBrokerSerde.WriteV12(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, message.TopicsField, (b, i) => MetadataResponseTopicSerde.WriteV12(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class MetadataResponseBrokerSerde
        {
            public static MetadataResponseBroker ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = default(string?);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadNullableString(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteNullableString(buffer, message.RackField);
                return buffer;
            }
            public static MetadataResponseBroker ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseBroker ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseBroker ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseBroker ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, MetadataResponseBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class MetadataResponseTopicSerde
        {
            public static MetadataResponseTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV00(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV01(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV02(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV03(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV04(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV05(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV06(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV06(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
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
            public static Memory<byte> WriteV07(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV07(b, i));
                return buffer;
            }
            public static MetadataResponseTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV08(b, i));
                buffer = Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                return buffer;
            }
            public static MetadataResponseTopic ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV09(b, i));
                buffer = Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseTopic ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV10(b, i));
                buffer = Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseTopic ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV11(b, i));
                buffer = Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataResponseTopic ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var isInternalField = Decoder.ReadBoolean(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataResponsePartitionSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var topicAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, MetadataResponseTopic message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteBoolean(buffer, message.IsInternalField);
                buffer = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, message.PartitionsField, (b, i) => MetadataResponsePartitionSerde.WriteV12(b, i));
                buffer = Encoder.WriteInt32(buffer, message.TopicAuthorizedOperationsField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class MetadataResponsePartitionSerde
            {
                public static MetadataResponsePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
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
                public static Memory<byte> WriteV01(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
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
                public static Memory<byte> WriteV02(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
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
                public static Memory<byte> WriteV03(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
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
                public static Memory<byte> WriteV04(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
                public static Memory<byte> WriteV05(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = default(int);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
                public static Memory<byte> WriteV06(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
                public static Memory<byte> WriteV07(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
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
                public static Memory<byte> WriteV08(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static MetadataResponsePartition ReadV09(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV09(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static MetadataResponsePartition ReadV10(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV10(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static MetadataResponsePartition ReadV11(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV11(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static MetadataResponsePartition ReadV12(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var replicaNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var isrNodesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var offlineReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV12(Memory<byte> buffer, MetadataResponsePartition message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicaNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.IsrNodesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.OfflineReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}