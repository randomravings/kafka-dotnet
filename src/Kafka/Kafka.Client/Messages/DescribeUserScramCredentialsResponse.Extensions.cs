using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CredentialInfo = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo;
using DescribeUserScramCredentialsResult = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeUserScramCredentialsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeUserScramCredentialsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeUserScramCredentialsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeUserScramCredentialsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeUserScramCredentialsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeUserScramCredentialsResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeUserScramCredentialsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<DescribeUserScramCredentialsResult>(buffer, message.ResultsField, (b, i) => DescribeUserScramCredentialsResultSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeUserScramCredentialsResultSerde
        {
            public static DescribeUserScramCredentialsResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var userField = Decoder.ReadCompactString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var credentialInfosField = Decoder.ReadCompactArray<CredentialInfo>(ref buffer, (ref ReadOnlyMemory<byte> b) => CredentialInfoSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'CredentialInfos'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField,
                    credentialInfosField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeUserScramCredentialsResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.UserField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteCompactArray<CredentialInfo>(buffer, message.CredentialInfosField, (b, i) => CredentialInfoSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class CredentialInfoSerde
            {
                public static CredentialInfo ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var mechanismField = Decoder.ReadInt8(ref buffer);
                    var iterationsField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        mechanismField,
                        iterationsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, CredentialInfo message)
                {
                    buffer = Encoder.WriteInt8(buffer, message.MechanismField);
                    buffer = Encoder.WriteInt32(buffer, message.IterationsField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}