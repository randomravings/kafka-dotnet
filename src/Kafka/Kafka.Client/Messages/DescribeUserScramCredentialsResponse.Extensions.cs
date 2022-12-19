using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeUserScramCredentialsResult = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult;
using CredentialInfo = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeUserScramCredentialsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeUserScramCredentialsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeUserScramCredentialsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeUserScramCredentialsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<DescribeUserScramCredentialsResult>(buffer, ref index, DescribeUserScramCredentialsResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactArray<DescribeUserScramCredentialsResult>(buffer, index, message.ResultsField, DescribeUserScramCredentialsResultSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeUserScramCredentialsResultSerde
        {
            public static DescribeUserScramCredentialsResult ReadV00(byte[] buffer, ref int index)
            {
                var userField = Decoder.ReadCompactString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var credentialInfosField = Decoder.ReadCompactArray<CredentialInfo>(buffer, ref index, CredentialInfoSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'CredentialInfos'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField,
                    credentialInfosField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.UserField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteCompactArray<CredentialInfo>(buffer, index, message.CredentialInfosField, CredentialInfoSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class CredentialInfoSerde
            {
                public static CredentialInfo ReadV00(byte[] buffer, ref int index)
                {
                    var mechanismField = Decoder.ReadInt8(buffer, ref index);
                    var iterationsField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        mechanismField,
                        iterationsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, CredentialInfo message)
                {
                    index = Encoder.WriteInt8(buffer, index, message.MechanismField);
                    index = Encoder.WriteInt32(buffer, index, message.IterationsField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}