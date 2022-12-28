using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Feature = Kafka.Client.Messages.BrokerRegistrationRequest.Feature;
using Listener = Kafka.Client.Messages.BrokerRegistrationRequest.Listener;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationRequestSerde
    {
        private static readonly DecodeDelegate<BrokerRegistrationRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<BrokerRegistrationRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static BrokerRegistrationRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, BrokerRegistrationRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static BrokerRegistrationRequest ReadV00(byte[] buffer, ref int index)
        {
            var brokerIdField = Decoder.ReadInt32(buffer, ref index);
            var clusterIdField = Decoder.ReadCompactString(buffer, ref index);
            var incarnationIdField = Decoder.ReadUuid(buffer, ref index);
            var listenersField = Decoder.ReadCompactArray<Listener>(buffer, ref index, ListenerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Listeners'");
            var featuresField = Decoder.ReadCompactArray<Feature>(buffer, ref index, FeatureSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Features'");
            var rackField = Decoder.ReadCompactNullableString(buffer, ref index);
            var isMigratingZkBrokerField = default(sbyte);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                brokerIdField,
                clusterIdField,
                incarnationIdField,
                listenersField,
                featuresField,
                rackField,
                isMigratingZkBrokerField
            );
        }
        private static int WriteV00(byte[] buffer, int index, BrokerRegistrationRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
            index = Encoder.WriteCompactString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteUuid(buffer, index, message.IncarnationIdField);
            index = Encoder.WriteCompactArray<Listener>(buffer, index, message.ListenersField, ListenerSerde.WriteV00);
            index = Encoder.WriteCompactArray<Feature>(buffer, index, message.FeaturesField, FeatureSerde.WriteV00);
            index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
            index = Encoder.WriteInt8(buffer, index, message.IsMigratingZkBrokerField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class FeatureSerde
        {
            public static Feature ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var MinSupportedVersionField = Decoder.ReadInt16(buffer, ref index);
                var MaxSupportedVersionField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    MinSupportedVersionField,
                    MaxSupportedVersionField
                );
            }
            public static int WriteV00(byte[] buffer, int index, Feature message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.MinSupportedVersionField);
                index = Encoder.WriteInt16(buffer, index, message.MaxSupportedVersionField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class ListenerSerde
        {
            public static Listener ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadUInt16(buffer, ref index);
                var SecurityProtocolField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    HostField,
                    PortField,
                    SecurityProtocolField
                );
            }
            public static int WriteV00(byte[] buffer, int index, Listener message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteUInt16(buffer, index, message.PortField);
                index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}