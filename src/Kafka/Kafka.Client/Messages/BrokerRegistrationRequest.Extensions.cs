using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Feature = Kafka.Client.Messages.BrokerRegistrationRequest.Feature;
using Listener = Kafka.Client.Messages.BrokerRegistrationRequest.Listener;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationRequestSerde
    {
        private static readonly DecodeDelegate<BrokerRegistrationRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<BrokerRegistrationRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerRegistrationRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, BrokerRegistrationRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static BrokerRegistrationRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var clusterIdField = Decoder.ReadCompactString(ref buffer);
            var incarnationIdField = Decoder.ReadUuid(ref buffer);
            var listenersField = Decoder.ReadCompactArray<Listener>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListenerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Listeners'");
            var featuresField = Decoder.ReadCompactArray<Feature>(ref buffer, (ref ReadOnlyMemory<byte> b) => FeatureSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Features'");
            var rackField = Decoder.ReadCompactNullableString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                clusterIdField,
                incarnationIdField,
                listenersField,
                featuresField,
                rackField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, BrokerRegistrationRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteCompactString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteUuid(buffer, message.IncarnationIdField);
            buffer = Encoder.WriteCompactArray<Listener>(buffer, message.ListenersField, (b, i) => ListenerSerde.WriteV00(b, i));
            buffer = Encoder.WriteCompactArray<Feature>(buffer, message.FeaturesField, (b, i) => FeatureSerde.WriteV00(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class FeatureSerde
        {
            public static Feature ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var minSupportedVersionField = Decoder.ReadInt16(ref buffer);
                var maxSupportedVersionField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    minSupportedVersionField,
                    maxSupportedVersionField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, Feature message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.MinSupportedVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxSupportedVersionField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class ListenerSerde
        {
            public static Listener ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadUInt16(ref buffer);
                var securityProtocolField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    hostField,
                    portField,
                    securityProtocolField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, Listener message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteUInt16(buffer, message.PortField);
                buffer = Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}