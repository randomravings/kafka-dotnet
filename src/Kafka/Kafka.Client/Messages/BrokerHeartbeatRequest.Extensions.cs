using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatRequestSerde
    {
        private static readonly DecodeDelegate<BrokerHeartbeatRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<BrokerHeartbeatRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerHeartbeatRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, BrokerHeartbeatRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static BrokerHeartbeatRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            var currentMetadataOffsetField = Decoder.ReadInt64(ref buffer);
            var wantFenceField = Decoder.ReadBoolean(ref buffer);
            var wantShutDownField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField,
                currentMetadataOffsetField,
                wantFenceField,
                wantShutDownField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, BrokerHeartbeatRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteInt64(buffer, message.CurrentMetadataOffsetField);
            buffer = Encoder.WriteBoolean(buffer, message.WantFenceField);
            buffer = Encoder.WriteBoolean(buffer, message.WantShutDownField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}