using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationResponseSerde
    {
        private static readonly Func<Stream, BrokerRegistrationResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, BrokerRegistrationResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static BrokerRegistrationResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, BrokerRegistrationResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static BrokerRegistrationResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                brokerEpochField
            );
        }
        private static void WriteV00(Stream buffer, BrokerRegistrationResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}