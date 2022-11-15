using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DefaultPrincipalDataSerde
    {
        private static readonly Func<Stream, DefaultPrincipalData>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DefaultPrincipalData>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DefaultPrincipalData Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DefaultPrincipalData message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DefaultPrincipalData ReadV00(Stream buffer)
        {
            var typeField = Decoder.ReadCompactString(buffer);
            var nameField = Decoder.ReadCompactString(buffer);
            var tokenAuthenticatedField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                typeField,
                nameField,
                tokenAuthenticatedField
            );
        }
        private static void WriteV00(Stream buffer, DefaultPrincipalData message)
        {
            Encoder.WriteCompactString(buffer, message.TypeField);
            Encoder.WriteCompactString(buffer, message.NameField);
            Encoder.WriteBoolean(buffer, message.TokenAuthenticatedField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}