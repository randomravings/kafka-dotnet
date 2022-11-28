using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterUserScramCredentialsResult = Kafka.Client.Messages.AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsResponseSerde
    {
        private static readonly DecodeDelegate<AlterUserScramCredentialsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AlterUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterUserScramCredentialsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterUserScramCredentialsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterUserScramCredentialsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<AlterUserScramCredentialsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterUserScramCredentialsResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterUserScramCredentialsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AlterUserScramCredentialsResult>(buffer, message.ResultsField, (b, i) => AlterUserScramCredentialsResultSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AlterUserScramCredentialsResultSerde
        {
            public static AlterUserScramCredentialsResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var userField = Decoder.ReadCompactString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AlterUserScramCredentialsResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.UserField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}