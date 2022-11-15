using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeRequestSerde
    {
        private static readonly Func<Stream, EnvelopeRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, EnvelopeRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static EnvelopeRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, EnvelopeRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static EnvelopeRequest ReadV00(Stream buffer)
        {
            var requestDataField = Decoder.ReadCompactBytes(buffer);
            var requestPrincipalField = Decoder.ReadCompactNullableBytes(buffer);
            var clientHostAddressField = Decoder.ReadCompactBytes(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                requestDataField,
                requestPrincipalField,
                clientHostAddressField
            );
        }
        private static void WriteV00(Stream buffer, EnvelopeRequest message)
        {
            Encoder.WriteCompactBytes(buffer, message.RequestDataField);
            Encoder.WriteCompactNullableBytes(buffer, message.RequestPrincipalField);
            Encoder.WriteCompactBytes(buffer, message.ClientHostAddressField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}