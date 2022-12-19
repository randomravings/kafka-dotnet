using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeRequestSerde
    {
        private static readonly DecodeDelegate<SaslHandshakeRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<SaslHandshakeRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static SaslHandshakeRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SaslHandshakeRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SaslHandshakeRequest ReadV00(byte[] buffer, ref int index)
        {
            var mechanismField = Decoder.ReadString(buffer, ref index);
            return new(
                mechanismField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SaslHandshakeRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.MechanismField);
            return index;
        }
        private static SaslHandshakeRequest ReadV01(byte[] buffer, ref int index)
        {
            var mechanismField = Decoder.ReadString(buffer, ref index);
            return new(
                mechanismField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SaslHandshakeRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.MechanismField);
            return index;
        }
    }
}