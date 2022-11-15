using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeRequestSerde
    {
        private static readonly Func<Stream, SaslHandshakeRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, SaslHandshakeRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static SaslHandshakeRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SaslHandshakeRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SaslHandshakeRequest ReadV00(Stream buffer)
        {
            var mechanismField = Decoder.ReadString(buffer);
            return new(
                mechanismField
            );
        }
        private static void WriteV00(Stream buffer, SaslHandshakeRequest message)
        {
            Encoder.WriteString(buffer, message.MechanismField);
        }
        private static SaslHandshakeRequest ReadV01(Stream buffer)
        {
            var mechanismField = Decoder.ReadString(buffer);
            return new(
                mechanismField
            );
        }
        private static void WriteV01(Stream buffer, SaslHandshakeRequest message)
        {
            Encoder.WriteString(buffer, message.MechanismField);
        }
    }
}