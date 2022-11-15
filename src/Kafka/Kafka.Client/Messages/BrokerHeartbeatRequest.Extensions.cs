using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatRequestSerde
    {
        private static readonly Func<Stream, BrokerHeartbeatRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, BrokerHeartbeatRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerHeartbeatRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, BrokerHeartbeatRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static BrokerHeartbeatRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            var currentMetadataOffsetField = Decoder.ReadInt64(buffer);
            var wantFenceField = Decoder.ReadBoolean(buffer);
            var wantShutDownField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                currentMetadataOffsetField,
                wantFenceField,
                wantShutDownField
            );
        }
        private static void WriteV00(Stream buffer, BrokerHeartbeatRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteInt64(buffer, message.CurrentMetadataOffsetField);
            Encoder.WriteBoolean(buffer, message.WantFenceField);
            Encoder.WriteBoolean(buffer, message.WantShutDownField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}