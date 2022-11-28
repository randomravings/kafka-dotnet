using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeRequestSerde
    {
        private static readonly DecodeDelegate<EnvelopeRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<EnvelopeRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static EnvelopeRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, EnvelopeRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static EnvelopeRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var requestDataField = Decoder.ReadCompactBytes(ref buffer);
            var requestPrincipalField = Decoder.ReadCompactNullableBytes(ref buffer);
            var clientHostAddressField = Decoder.ReadCompactBytes(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                requestDataField,
                requestPrincipalField,
                clientHostAddressField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, EnvelopeRequest message)
        {
            buffer = Encoder.WriteCompactBytes(buffer, message.RequestDataField);
            buffer = Encoder.WriteCompactNullableBytes(buffer, message.RequestPrincipalField);
            buffer = Encoder.WriteCompactBytes(buffer, message.ClientHostAddressField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}