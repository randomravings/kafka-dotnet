using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterUserScramCredentialsResult = Kafka.Client.Messages.AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsResponseSerde
    {
        private static readonly DecodeDelegate<AlterUserScramCredentialsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<AlterUserScramCredentialsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static AlterUserScramCredentialsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterUserScramCredentialsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterUserScramCredentialsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<AlterUserScramCredentialsResult>(buffer, ref index, AlterUserScramCredentialsResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AlterUserScramCredentialsResult>(buffer, index, message.ResultsField, AlterUserScramCredentialsResultSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterUserScramCredentialsResultSerde
        {
            public static AlterUserScramCredentialsResult ReadV00(byte[] buffer, ref int index)
            {
                var userField = Decoder.ReadCompactString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    userField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.UserField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}