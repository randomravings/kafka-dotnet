using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ResponseHeaderSerde
    {
        private static readonly DecodeDelegate<ResponseHeader>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<ResponseHeader>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ResponseHeader Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ResponseHeader message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ResponseHeader ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var correlationIdField = Decoder.ReadInt32(ref buffer);
            return new(
                correlationIdField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ResponseHeader message)
        {
            buffer = Encoder.WriteInt32(buffer, message.CorrelationIdField);
            return buffer;
        }
        private static ResponseHeader ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var correlationIdField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                correlationIdField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ResponseHeader message)
        {
            buffer = Encoder.WriteInt32(buffer, message.CorrelationIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}