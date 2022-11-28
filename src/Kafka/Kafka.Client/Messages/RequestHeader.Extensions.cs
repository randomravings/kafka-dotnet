using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RequestHeaderSerde
    {
        private static readonly DecodeDelegate<RequestHeader>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<RequestHeader>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static RequestHeader Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, RequestHeader message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static RequestHeader ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(ref buffer);
            var requestApiVersionField = Decoder.ReadInt16(ref buffer);
            var correlationIdField = Decoder.ReadInt32(ref buffer);
            var clientIdField = default(string?);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, RequestHeader message)
        {
            buffer = Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            buffer = Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            buffer = Encoder.WriteInt32(buffer, message.CorrelationIdField);
            return buffer;
        }
        private static RequestHeader ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(ref buffer);
            var requestApiVersionField = Decoder.ReadInt16(ref buffer);
            var correlationIdField = Decoder.ReadInt32(ref buffer);
            var clientIdField = Decoder.ReadNullableString(ref buffer);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, RequestHeader message)
        {
            buffer = Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            buffer = Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            buffer = Encoder.WriteInt32(buffer, message.CorrelationIdField);
            buffer = Encoder.WriteNullableString(buffer, message.ClientIdField);
            return buffer;
        }
        private static RequestHeader ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(ref buffer);
            var requestApiVersionField = Decoder.ReadInt16(ref buffer);
            var correlationIdField = Decoder.ReadInt32(ref buffer);
            var clientIdField = Decoder.ReadNullableString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, RequestHeader message)
        {
            buffer = Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            buffer = Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            buffer = Encoder.WriteInt32(buffer, message.CorrelationIdField);
            buffer = Encoder.WriteNullableString(buffer, message.ClientIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}