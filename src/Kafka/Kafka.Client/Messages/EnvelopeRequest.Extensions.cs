using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeRequestSerde
    {
        private static readonly DecodeDelegate<EnvelopeRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<EnvelopeRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static EnvelopeRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, EnvelopeRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static EnvelopeRequest ReadV00(byte[] buffer, ref int index)
        {
            var requestDataField = Decoder.ReadCompactBytes(buffer, ref index);
            var requestPrincipalField = Decoder.ReadCompactNullableBytes(buffer, ref index);
            var clientHostAddressField = Decoder.ReadCompactBytes(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                requestDataField,
                requestPrincipalField,
                clientHostAddressField
            );
        }
        private static int WriteV00(byte[] buffer, int index, EnvelopeRequest message)
        {
            index = Encoder.WriteCompactBytes(buffer, index, message.RequestDataField);
            index = Encoder.WriteCompactNullableBytes(buffer, index, message.RequestPrincipalField);
            index = Encoder.WriteCompactBytes(buffer, index, message.ClientHostAddressField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}