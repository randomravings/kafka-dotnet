using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenResponseSerde
    {
        private static readonly Func<Stream, CreateDelegationTokenResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreateDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateDelegationTokenResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateDelegationTokenResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var principalTypeField = Decoder.ReadString(buffer);
            var principalNameField = Decoder.ReadString(buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var maxTimestampMsField = Decoder.ReadInt64(buffer);
            var tokenIdField = Decoder.ReadString(buffer);
            var hmacField = Decoder.ReadBytes(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
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
        private static void WriteV00(Stream buffer, CreateDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.PrincipalTypeField);
            Encoder.WriteString(buffer, message.PrincipalNameField);
            Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            Encoder.WriteString(buffer, message.TokenIdField);
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static CreateDelegationTokenResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var principalTypeField = Decoder.ReadString(buffer);
            var principalNameField = Decoder.ReadString(buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var maxTimestampMsField = Decoder.ReadInt64(buffer);
            var tokenIdField = Decoder.ReadString(buffer);
            var hmacField = Decoder.ReadBytes(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
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
        private static void WriteV01(Stream buffer, CreateDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.PrincipalTypeField);
            Encoder.WriteString(buffer, message.PrincipalNameField);
            Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            Encoder.WriteString(buffer, message.TokenIdField);
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static CreateDelegationTokenResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var principalTypeField = Decoder.ReadCompactString(buffer);
            var principalNameField = Decoder.ReadCompactString(buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var maxTimestampMsField = Decoder.ReadInt64(buffer);
            var tokenIdField = Decoder.ReadCompactString(buffer);
            var hmacField = Decoder.ReadCompactBytes(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV02(Stream buffer, CreateDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
            Encoder.WriteCompactString(buffer, message.PrincipalNameField);
            Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            Encoder.WriteCompactString(buffer, message.TokenIdField);
            Encoder.WriteCompactBytes(buffer, message.HmacField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateDelegationTokenResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var principalTypeField = Decoder.ReadCompactString(buffer);
            var principalNameField = Decoder.ReadCompactString(buffer);
            var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(buffer);
            var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(buffer);
            var issueTimestampMsField = Decoder.ReadInt64(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var maxTimestampMsField = Decoder.ReadInt64(buffer);
            var tokenIdField = Decoder.ReadCompactString(buffer);
            var hmacField = Decoder.ReadCompactBytes(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV03(Stream buffer, CreateDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
            Encoder.WriteCompactString(buffer, message.PrincipalNameField);
            Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalTypeField);
            Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalNameField);
            Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            Encoder.WriteCompactString(buffer, message.TokenIdField);
            Encoder.WriteCompactBytes(buffer, message.HmacField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}