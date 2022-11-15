using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatResponseSerde
    {
        private static readonly Func<Stream, BrokerHeartbeatResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, BrokerHeartbeatResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerHeartbeatResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, BrokerHeartbeatResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static BrokerHeartbeatResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var isCaughtUpField = Decoder.ReadBoolean(buffer);
            var isFencedField = Decoder.ReadBoolean(buffer);
            var shouldShutDownField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                isCaughtUpField,
                isFencedField,
                shouldShutDownField
            );
        }
        private static void WriteV00(Stream buffer, BrokerHeartbeatResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBoolean(buffer, message.IsCaughtUpField);
            Encoder.WriteBoolean(buffer, message.IsFencedField);
            Encoder.WriteBoolean(buffer, message.ShouldShutDownField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}