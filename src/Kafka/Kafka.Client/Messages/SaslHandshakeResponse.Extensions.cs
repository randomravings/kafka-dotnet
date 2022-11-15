using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeResponseSerde
    {
        private static readonly Func<Stream, SaslHandshakeResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, SaslHandshakeResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static SaslHandshakeResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SaslHandshakeResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SaslHandshakeResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var mechanismsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static void WriteV00(Stream buffer, SaslHandshakeResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<string>(buffer, message.MechanismsField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static SaslHandshakeResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var mechanismsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static void WriteV01(Stream buffer, SaslHandshakeResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<string>(buffer, message.MechanismsField, (b, i) => Encoder.WriteCompactString(b, i));
        }
    }
}