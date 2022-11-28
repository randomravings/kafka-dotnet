using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeResponseSerde
    {
        private static readonly DecodeDelegate<EnvelopeResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<EnvelopeResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static EnvelopeResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, EnvelopeResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static EnvelopeResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var responseDataField = Decoder.ReadCompactNullableBytes(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                responseDataField,
                errorCodeField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, EnvelopeResponse message)
        {
            buffer = Encoder.WriteCompactNullableBytes(buffer, message.ResponseDataField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}