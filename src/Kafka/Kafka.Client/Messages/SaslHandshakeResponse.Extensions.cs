using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeResponseSerde
    {
        private static readonly DecodeDelegate<SaslHandshakeResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<SaslHandshakeResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static SaslHandshakeResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SaslHandshakeResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SaslHandshakeResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var mechanismsField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SaslHandshakeResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<string>(buffer, index, message.MechanismsField, Encoder.WriteCompactString);
            return index;
        }
        private static SaslHandshakeResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var mechanismsField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'Mechanisms'");
            return new(
                errorCodeField,
                mechanismsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SaslHandshakeResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<string>(buffer, index, message.MechanismsField, Encoder.WriteCompactString);
            return index;
        }
    }
}