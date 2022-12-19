using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeResponseSerde
    {
        private static readonly DecodeDelegate<EnvelopeResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<EnvelopeResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static EnvelopeResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, EnvelopeResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static EnvelopeResponse ReadV00(byte[] buffer, ref int index)
        {
            var responseDataField = Decoder.ReadCompactNullableBytes(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                responseDataField,
                errorCodeField
            );
        }
        private static int WriteV00(byte[] buffer, int index, EnvelopeResponse message)
        {
            index = Encoder.WriteCompactNullableBytes(buffer, index, message.ResponseDataField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}