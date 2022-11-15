using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Listener = Kafka.Client.Messages.BrokerRegistrationRequest.Listener;
using Feature = Kafka.Client.Messages.BrokerRegistrationRequest.Feature;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationRequestSerde
    {
        private static readonly Func<Stream, BrokerRegistrationRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, BrokerRegistrationRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerRegistrationRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, BrokerRegistrationRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static BrokerRegistrationRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var clusterIdField = Decoder.ReadCompactString(buffer);
            var incarnationIdField = Decoder.ReadUuid(buffer);
            var listenersField = Decoder.ReadCompactArray<Listener>(buffer, b => ListenerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Listeners'");
            var featuresField = Decoder.ReadCompactArray<Feature>(buffer, b => FeatureSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Features'");
            var rackField = Decoder.ReadCompactNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                clusterIdField,
                incarnationIdField,
                listenersField,
                featuresField,
                rackField
            );
        }
        private static void WriteV00(Stream buffer, BrokerRegistrationRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteCompactString(buffer, message.ClusterIdField);
            Encoder.WriteUuid(buffer, message.IncarnationIdField);
            Encoder.WriteCompactArray<Listener>(buffer, message.ListenersField, (b, i) => ListenerSerde.WriteV00(b, i));
            Encoder.WriteCompactArray<Feature>(buffer, message.FeaturesField, (b, i) => FeatureSerde.WriteV00(b, i));
            Encoder.WriteCompactNullableString(buffer, message.RackField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ListenerSerde
        {
            public static Listener ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadUInt16(buffer);
                var securityProtocolField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    hostField,
                    portField,
                    securityProtocolField
                );
            }
            public static void WriteV00(Stream buffer, Listener message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteUInt16(buffer, message.PortField);
                Encoder.WriteInt16(buffer, message.SecurityProtocolField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class FeatureSerde
        {
            public static Feature ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var minSupportedVersionField = Decoder.ReadInt16(buffer);
                var maxSupportedVersionField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    minSupportedVersionField,
                    maxSupportedVersionField
                );
            }
            public static void WriteV00(Stream buffer, Feature message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.MinSupportedVersionField);
                Encoder.WriteInt16(buffer, message.MaxSupportedVersionField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}