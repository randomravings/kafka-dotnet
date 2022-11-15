using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RequestHeaderSerde
    {
        private static readonly Func<Stream, RequestHeader>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, RequestHeader>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static RequestHeader Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, RequestHeader message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static RequestHeader ReadV00(Stream buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(buffer);
            var requestApiVersionField = Decoder.ReadInt16(buffer);
            var correlationIdField = Decoder.ReadInt32(buffer);
            var clientIdField = default(string?);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static void WriteV00(Stream buffer, RequestHeader message)
        {
            Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
        }
        private static RequestHeader ReadV01(Stream buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(buffer);
            var requestApiVersionField = Decoder.ReadInt16(buffer);
            var correlationIdField = Decoder.ReadInt32(buffer);
            var clientIdField = Decoder.ReadNullableString(buffer);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static void WriteV01(Stream buffer, RequestHeader message)
        {
            Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
            Encoder.WriteNullableString(buffer, message.ClientIdField);
        }
        private static RequestHeader ReadV02(Stream buffer)
        {
            var requestApiKeyField = Decoder.ReadInt16(buffer);
            var requestApiVersionField = Decoder.ReadInt16(buffer);
            var correlationIdField = Decoder.ReadInt32(buffer);
            var clientIdField = Decoder.ReadNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            );
        }
        private static void WriteV02(Stream buffer, RequestHeader message)
        {
            Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
            Encoder.WriteNullableString(buffer, message.ClientIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}