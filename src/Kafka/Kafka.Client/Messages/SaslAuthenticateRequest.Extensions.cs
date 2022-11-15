using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateRequestSerde
    {
        private static readonly Func<Stream, SaslAuthenticateRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, SaslAuthenticateRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static SaslAuthenticateRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SaslAuthenticateRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SaslAuthenticateRequest ReadV00(Stream buffer)
        {
            var authBytesField = Decoder.ReadBytes(buffer);
            return new(
                authBytesField
            );
        }
        private static void WriteV00(Stream buffer, SaslAuthenticateRequest message)
        {
            Encoder.WriteBytes(buffer, message.AuthBytesField);
        }
        private static SaslAuthenticateRequest ReadV01(Stream buffer)
        {
            var authBytesField = Decoder.ReadBytes(buffer);
            return new(
                authBytesField
            );
        }
        private static void WriteV01(Stream buffer, SaslAuthenticateRequest message)
        {
            Encoder.WriteBytes(buffer, message.AuthBytesField);
        }
        private static SaslAuthenticateRequest ReadV02(Stream buffer)
        {
            var authBytesField = Decoder.ReadCompactBytes(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                authBytesField
            );
        }
        private static void WriteV02(Stream buffer, SaslAuthenticateRequest message)
        {
            Encoder.WriteCompactBytes(buffer, message.AuthBytesField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}