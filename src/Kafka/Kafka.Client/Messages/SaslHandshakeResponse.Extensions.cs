using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeResponseSerde
    {
        private static readonly DecodeDelegate<SaslHandshakeResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<SaslHandshakeResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static SaslHandshakeResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SaslHandshakeResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SaslHandshakeResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var mechanismsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SaslHandshakeResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<string>(buffer, message.MechanismsField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static SaslHandshakeResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var mechanismsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, SaslHandshakeResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<string>(buffer, message.MechanismsField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
    }
}