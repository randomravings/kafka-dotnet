using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeRequestSerde
    {
        private static readonly DecodeDelegate<SaslHandshakeRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<SaslHandshakeRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static SaslHandshakeRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SaslHandshakeRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SaslHandshakeRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var mechanismField = Decoder.ReadString(ref buffer);
            return new(
                mechanismField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SaslHandshakeRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.MechanismField);
            return buffer;
        }
        private static SaslHandshakeRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var mechanismField = Decoder.ReadString(ref buffer);
            return new(
                mechanismField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, SaslHandshakeRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.MechanismField);
            return buffer;
        }
    }
}