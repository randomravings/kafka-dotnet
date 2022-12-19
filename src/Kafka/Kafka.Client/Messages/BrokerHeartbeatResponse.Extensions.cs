using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatResponseSerde
    {
        private static readonly DecodeDelegate<BrokerHeartbeatResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<BrokerHeartbeatResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static BrokerHeartbeatResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, BrokerHeartbeatResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static BrokerHeartbeatResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var isCaughtUpField = Decoder.ReadBoolean(buffer, ref index);
            var isFencedField = Decoder.ReadBoolean(buffer, ref index);
            var shouldShutDownField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                isCaughtUpField,
                isFencedField,
                shouldShutDownField
            );
        }
        private static int WriteV00(byte[] buffer, int index, BrokerHeartbeatResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteBoolean(buffer, index, message.IsCaughtUpField);
            index = Encoder.WriteBoolean(buffer, index, message.IsFencedField);
            index = Encoder.WriteBoolean(buffer, index, message.ShouldShutDownField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}