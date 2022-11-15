using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UnregisterBrokerResponseSerde
    {
        private static readonly Func<Stream, UnregisterBrokerResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, UnregisterBrokerResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static UnregisterBrokerResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UnregisterBrokerResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UnregisterBrokerResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField
            );
        }
        private static void WriteV00(Stream buffer, UnregisterBrokerResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}