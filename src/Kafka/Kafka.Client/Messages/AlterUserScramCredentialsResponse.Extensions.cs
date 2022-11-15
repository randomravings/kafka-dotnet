using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterUserScramCredentialsResult = Kafka.Client.Messages.AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsResponseSerde
    {
        private static readonly Func<Stream, AlterUserScramCredentialsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AlterUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterUserScramCredentialsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterUserScramCredentialsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterUserScramCredentialsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<AlterUserScramCredentialsResult>(buffer, b => AlterUserScramCredentialsResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, AlterUserScramCredentialsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AlterUserScramCredentialsResult>(buffer, message.ResultsField, (b, i) => AlterUserScramCredentialsResultSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AlterUserScramCredentialsResultSerde
        {
            public static AlterUserScramCredentialsResult ReadV00(Stream buffer)
            {
                var userField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV00(Stream buffer, AlterUserScramCredentialsResult message)
            {
                Encoder.WriteCompactString(buffer, message.UserField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}