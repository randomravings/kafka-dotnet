using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DefaultPrincipalDataSerde
    {
        private static readonly DecodeDelegate<DefaultPrincipalData>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DefaultPrincipalData>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DefaultPrincipalData Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DefaultPrincipalData message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DefaultPrincipalData ReadV00(byte[] buffer, ref int index)
        {
            var typeField = Decoder.ReadCompactString(buffer, ref index);
            var nameField = Decoder.ReadCompactString(buffer, ref index);
            var tokenAuthenticatedField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                typeField,
                nameField,
                tokenAuthenticatedField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DefaultPrincipalData message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.TypeField);
            index = Encoder.WriteCompactString(buffer, index, message.NameField);
            index = Encoder.WriteBoolean(buffer, index, message.TokenAuthenticatedField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}