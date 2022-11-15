using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeUserScramCredentialsResult = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult;
using CredentialInfo = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsResponseSerde
    {
        private static readonly Func<Stream, DescribeUserScramCredentialsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeUserScramCredentialsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeUserScramCredentialsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeUserScramCredentialsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeUserScramCredentialsResult>(buffer, b => DescribeUserScramCredentialsResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeUserScramCredentialsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<DescribeUserScramCredentialsResult>(buffer, message.ResultsField, (b, i) => DescribeUserScramCredentialsResultSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeUserScramCredentialsResultSerde
        {
            public static DescribeUserScramCredentialsResult ReadV00(Stream buffer)
            {
                var userField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var credentialInfosField = Decoder.ReadCompactArray<CredentialInfo>(buffer, b => CredentialInfoSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'CredentialInfos'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField,
                    credentialInfosField
                );
            }
            public static void WriteV00(Stream buffer, DescribeUserScramCredentialsResult message)
            {
                Encoder.WriteCompactString(buffer, message.UserField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteCompactArray<CredentialInfo>(buffer, message.CredentialInfosField, (b, i) => CredentialInfoSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class CredentialInfoSerde
            {
                public static CredentialInfo ReadV00(Stream buffer)
                {
                    var mechanismField = Decoder.ReadInt8(buffer);
                    var iterationsField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        mechanismField,
                        iterationsField
                    );
                }
                public static void WriteV00(Stream buffer, CredentialInfo message)
                {
                    Encoder.WriteInt8(buffer, message.MechanismField);
                    Encoder.WriteInt32(buffer, message.IterationsField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}