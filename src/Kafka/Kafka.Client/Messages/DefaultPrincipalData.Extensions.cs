using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DefaultPrincipalDataSerde
    {
        private static readonly DecodeDelegate<DefaultPrincipalData>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DefaultPrincipalData>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DefaultPrincipalData Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DefaultPrincipalData message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DefaultPrincipalData ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var typeField = Decoder.ReadCompactString(ref buffer);
            var nameField = Decoder.ReadCompactString(ref buffer);
            var tokenAuthenticatedField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                typeField,
                nameField,
                tokenAuthenticatedField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DefaultPrincipalData message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.TypeField);
            buffer = Encoder.WriteCompactString(buffer, message.NameField);
            buffer = Encoder.WriteBoolean(buffer, message.TokenAuthenticatedField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}