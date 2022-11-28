using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatResponseSerde
    {
        private static readonly DecodeDelegate<BrokerHeartbeatResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<BrokerHeartbeatResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerHeartbeatResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, BrokerHeartbeatResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static BrokerHeartbeatResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var isCaughtUpField = Decoder.ReadBoolean(ref buffer);
            var isFencedField = Decoder.ReadBoolean(ref buffer);
            var shouldShutDownField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                isCaughtUpField,
                isFencedField,
                shouldShutDownField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, BrokerHeartbeatResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteBoolean(buffer, message.IsCaughtUpField);
            buffer = Encoder.WriteBoolean(buffer, message.IsFencedField);
            buffer = Encoder.WriteBoolean(buffer, message.ShouldShutDownField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}