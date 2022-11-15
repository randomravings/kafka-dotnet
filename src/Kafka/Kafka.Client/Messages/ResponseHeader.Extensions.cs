using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ResponseHeaderSerde
    {
        private static readonly Func<Stream, ResponseHeader>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, ResponseHeader>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ResponseHeader Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ResponseHeader message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ResponseHeader ReadV00(Stream buffer)
        {
            var correlationIdField = Decoder.ReadInt32(buffer);
            return new(
                correlationIdField
            );
        }
        private static void WriteV00(Stream buffer, ResponseHeader message)
        {
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
        }
        private static ResponseHeader ReadV01(Stream buffer)
        {
            var correlationIdField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                correlationIdField
            );
        }
        private static void WriteV01(Stream buffer, ResponseHeader message)
        {
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}