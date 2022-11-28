using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribedDelegationTokenRenewer = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken.DescribedDelegationTokenRenewer;
using DescribedDelegationToken = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<DescribeDelegationTokenResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<DescribeDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeDelegationTokenResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeDelegationTokenResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static DescribeDelegationTokenResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static DescribeDelegationTokenResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeDelegationTokenResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribedDelegationTokenSerde
        {
            public static DescribedDelegationToken ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(ref buffer);
                var expiryTimestampField = Decoder.ReadInt64(ref buffer);
                var maxTimestampField = Decoder.ReadInt64(ref buffer);
                var tokenIdField = Decoder.ReadString(ref buffer);
                var hmacField = Decoder.ReadBytes(ref buffer);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenRenewerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                return new(
                    principalTypeField,
                    principalNameField,
                    tokenRequesterPrincipalTypeField,
                    tokenRequesterPrincipalNameField,
                    issueTimestampField,
                    expiryTimestampField,
                    maxTimestampField,
                    tokenIdField,
                    hmacField,
                    renewersField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribedDelegationToken message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteInt64(buffer, message.IssueTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.MaxTimestampField);
                buffer = Encoder.WriteString(buffer, message.TokenIdField);
                buffer = Encoder.WriteBytes(buffer, message.HmacField);
                buffer = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV00(b, i));
                return buffer;
            }
            public static DescribedDelegationToken ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(ref buffer);
                var expiryTimestampField = Decoder.ReadInt64(ref buffer);
                var maxTimestampField = Decoder.ReadInt64(ref buffer);
                var tokenIdField = Decoder.ReadString(ref buffer);
                var hmacField = Decoder.ReadBytes(ref buffer);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenRenewerSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                return new(
                    principalTypeField,
                    principalNameField,
                    tokenRequesterPrincipalTypeField,
                    tokenRequesterPrincipalNameField,
                    issueTimestampField,
                    expiryTimestampField,
                    maxTimestampField,
                    tokenIdField,
                    hmacField,
                    renewersField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribedDelegationToken message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteInt64(buffer, message.IssueTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.MaxTimestampField);
                buffer = Encoder.WriteString(buffer, message.TokenIdField);
                buffer = Encoder.WriteBytes(buffer, message.HmacField);
                buffer = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV01(b, i));
                return buffer;
            }
            public static DescribedDelegationToken ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(ref buffer);
                var expiryTimestampField = Decoder.ReadInt64(ref buffer);
                var maxTimestampField = Decoder.ReadInt64(ref buffer);
                var tokenIdField = Decoder.ReadCompactString(ref buffer);
                var hmacField = Decoder.ReadCompactBytes(ref buffer);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenRenewerSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField,
                    tokenRequesterPrincipalTypeField,
                    tokenRequesterPrincipalNameField,
                    issueTimestampField,
                    expiryTimestampField,
                    maxTimestampField,
                    tokenIdField,
                    hmacField,
                    renewersField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribedDelegationToken message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteInt64(buffer, message.IssueTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.MaxTimestampField);
                buffer = Encoder.WriteCompactString(buffer, message.TokenIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
                buffer = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribedDelegationToken ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(ref buffer);
                var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(ref buffer);
                var issueTimestampField = Decoder.ReadInt64(ref buffer);
                var expiryTimestampField = Decoder.ReadInt64(ref buffer);
                var maxTimestampField = Decoder.ReadInt64(ref buffer);
                var tokenIdField = Decoder.ReadCompactString(ref buffer);
                var hmacField = Decoder.ReadCompactBytes(ref buffer);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedDelegationTokenRenewerSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField,
                    tokenRequesterPrincipalTypeField,
                    tokenRequesterPrincipalNameField,
                    issueTimestampField,
                    expiryTimestampField,
                    maxTimestampField,
                    tokenIdField,
                    hmacField,
                    renewersField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribedDelegationToken message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalNameField);
                buffer = Encoder.WriteInt64(buffer, message.IssueTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.MaxTimestampField);
                buffer = Encoder.WriteCompactString(buffer, message.TokenIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
                buffer = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DescribedDelegationTokenRenewerSerde
            {
                public static DescribedDelegationTokenRenewer ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalTypeField = Decoder.ReadString(ref buffer);
                    var principalNameField = Decoder.ReadString(ref buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DescribedDelegationTokenRenewer message)
                {
                    buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                    buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                    return buffer;
                }
                public static DescribedDelegationTokenRenewer ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalTypeField = Decoder.ReadString(ref buffer);
                    var principalNameField = Decoder.ReadString(ref buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DescribedDelegationTokenRenewer message)
                {
                    buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                    buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                    return buffer;
                }
                public static DescribedDelegationTokenRenewer ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalTypeField = Decoder.ReadCompactString(ref buffer);
                    var principalNameField = Decoder.ReadCompactString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DescribedDelegationTokenRenewer message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static DescribedDelegationTokenRenewer ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalTypeField = Decoder.ReadCompactString(ref buffer);
                    var principalNameField = Decoder.ReadCompactString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, DescribedDelegationTokenRenewer message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}