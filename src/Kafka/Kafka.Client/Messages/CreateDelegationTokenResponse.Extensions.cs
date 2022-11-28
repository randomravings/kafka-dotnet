using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<CreateDelegationTokenResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<CreateDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateDelegationTokenResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateDelegationTokenResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var principalTypeField = Decoder.ReadString(ref buffer);
            var principalNameField = Decoder.ReadString(ref buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var maxTimestampMsField = Decoder.ReadInt64(ref buffer);
            var tokenIdField = Decoder.ReadString(ref buffer);
            var hmacField = Decoder.ReadBytes(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
            buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
            buffer = Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            buffer = Encoder.WriteString(buffer, message.TokenIdField);
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static CreateDelegationTokenResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var principalTypeField = Decoder.ReadString(ref buffer);
            var principalNameField = Decoder.ReadString(ref buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var maxTimestampMsField = Decoder.ReadInt64(ref buffer);
            var tokenIdField = Decoder.ReadString(ref buffer);
            var hmacField = Decoder.ReadBytes(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
            buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
            buffer = Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            buffer = Encoder.WriteString(buffer, message.TokenIdField);
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static CreateDelegationTokenResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var principalTypeField = Decoder.ReadCompactString(ref buffer);
            var principalNameField = Decoder.ReadCompactString(ref buffer);
            var tokenRequesterPrincipalTypeField = "";
            var tokenRequesterPrincipalNameField = "";
            var issueTimestampMsField = Decoder.ReadInt64(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var maxTimestampMsField = Decoder.ReadInt64(ref buffer);
            var tokenIdField = Decoder.ReadCompactString(ref buffer);
            var hmacField = Decoder.ReadCompactBytes(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
            buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
            buffer = Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            buffer = Encoder.WriteCompactString(buffer, message.TokenIdField);
            buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateDelegationTokenResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var principalTypeField = Decoder.ReadCompactString(ref buffer);
            var principalNameField = Decoder.ReadCompactString(ref buffer);
            var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(ref buffer);
            var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(ref buffer);
            var issueTimestampMsField = Decoder.ReadInt64(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var maxTimestampMsField = Decoder.ReadInt64(ref buffer);
            var tokenIdField = Decoder.ReadCompactString(ref buffer);
            var hmacField = Decoder.ReadCompactBytes(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
            buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
            buffer = Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalTypeField);
            buffer = Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalNameField);
            buffer = Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            buffer = Encoder.WriteCompactString(buffer, message.TokenIdField);
            buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}