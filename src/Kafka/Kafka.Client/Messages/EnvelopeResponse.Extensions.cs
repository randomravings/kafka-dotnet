using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeResponseSerde
    {
        private static readonly Func<Stream, EnvelopeResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, EnvelopeResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static EnvelopeResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, EnvelopeResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static EnvelopeResponse ReadV00(Stream buffer)
        {
            var responseDataField = Decoder.ReadCompactNullableBytes(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                responseDataField,
                errorCodeField
            );
        }
        private static void WriteV00(Stream buffer, EnvelopeResponse message)
        {
            Encoder.WriteCompactNullableBytes(buffer, message.ResponseDataField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}