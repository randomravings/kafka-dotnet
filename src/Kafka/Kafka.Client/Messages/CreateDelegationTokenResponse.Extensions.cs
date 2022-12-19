using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<CreateDelegationTokenResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<CreateDelegationTokenResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static CreateDelegationTokenResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateDelegationTokenResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateDelegationTokenResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var principalTypeField = Decoder.ReadString(buffer, ref index);
            var principalNameField = Decoder.ReadString(buffer, ref index);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var maxTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var tokenIdField = Decoder.ReadString(buffer, ref index);
            var hmacField = Decoder.ReadBytes(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                principalTypeField,
                principalNameField,
                tokenRequesterPrincipalTypeField,
                tokenRequesterPrincipalNameField,
                issueTimestampMsField,
                expiryTimestampMsField,
                maxTimestampMsField,
                tokenIdField,
                hmacField,
                throttleTimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
            index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
            index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
            index = Encoder.WriteString(buffer, index, message.TokenIdField);
            index = Encoder.WriteBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static CreateDelegationTokenResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var principalTypeField = Decoder.ReadString(buffer, ref index);
            var principalNameField = Decoder.ReadString(buffer, ref index);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var maxTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var tokenIdField = Decoder.ReadString(buffer, ref index);
            var hmacField = Decoder.ReadBytes(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                principalTypeField,
                principalNameField,
                tokenRequesterPrincipalTypeField,
                tokenRequesterPrincipalNameField,
                issueTimestampMsField,
                expiryTimestampMsField,
                maxTimestampMsField,
                tokenIdField,
                hmacField,
                throttleTimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
            index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
            index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
            index = Encoder.WriteString(buffer, index, message.TokenIdField);
            index = Encoder.WriteBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static CreateDelegationTokenResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
            var principalNameField = Decoder.ReadCompactString(buffer, ref index);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var maxTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var tokenIdField = Decoder.ReadCompactString(buffer, ref index);
            var hmacField = Decoder.ReadCompactBytes(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                principalTypeField,
                principalNameField,
                tokenRequesterPrincipalTypeField,
                tokenRequesterPrincipalNameField,
                issueTimestampMsField,
                expiryTimestampMsField,
                maxTimestampMsField,
                tokenIdField,
                hmacField,
                throttleTimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
            index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
            index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
            index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
            index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateDelegationTokenResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
            var principalNameField = Decoder.ReadCompactString(buffer, ref index);
            var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(buffer, ref index);
            var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(buffer, ref index);
            var issueTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var maxTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var tokenIdField = Decoder.ReadCompactString(buffer, ref index);
            var hmacField = Decoder.ReadCompactBytes(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                principalTypeField,
                principalNameField,
                tokenRequesterPrincipalTypeField,
                tokenRequesterPrincipalNameField,
                issueTimestampMsField,
                expiryTimestampMsField,
                maxTimestampMsField,
                tokenIdField,
                hmacField,
                throttleTimeMsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
            index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
            index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalTypeField);
            index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalNameField);
            index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
            index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
            index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}