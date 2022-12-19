using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatRequestSerde
    {
        private static readonly DecodeDelegate<BrokerHeartbeatRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<BrokerHeartbeatRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static BrokerHeartbeatRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, BrokerHeartbeatRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static BrokerHeartbeatRequest ReadV00(byte[] buffer, ref int index)
        {
            var brokerIdField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            var currentMetadataOffsetField = Decoder.ReadInt64(buffer, ref index);
            var wantFenceField = Decoder.ReadBoolean(buffer, ref index);
            var wantShutDownField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                brokerIdField,
                brokerEpochField,
                currentMetadataOffsetField,
                wantFenceField,
                wantShutDownField
            );
        }
        private static int WriteV00(byte[] buffer, int index, BrokerHeartbeatRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteInt64(buffer, index, message.CurrentMetadataOffsetField);
            index = Encoder.WriteBoolean(buffer, index, message.WantFenceField);
            index = Encoder.WriteBoolean(buffer, index, message.WantShutDownField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}