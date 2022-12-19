using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateRequestSerde
    {
        private static readonly DecodeDelegate<SaslAuthenticateRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<SaslAuthenticateRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static SaslAuthenticateRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SaslAuthenticateRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SaslAuthenticateRequest ReadV00(byte[] buffer, ref int index)
        {
            var authBytesField = Decoder.ReadBytes(buffer, ref index);
            return new(
                authBytesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SaslAuthenticateRequest message)
        {
            index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
            return index;
        }
        private static SaslAuthenticateRequest ReadV01(byte[] buffer, ref int index)
        {
            var authBytesField = Decoder.ReadBytes(buffer, ref index);
            return new(
                authBytesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SaslAuthenticateRequest message)
        {
            index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
            return index;
        }
        private static SaslAuthenticateRequest ReadV02(byte[] buffer, ref int index)
        {
            var authBytesField = Decoder.ReadCompactBytes(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                authBytesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, SaslAuthenticateRequest message)
        {
            index = Encoder.WriteCompactBytes(buffer, index, message.AuthBytesField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}