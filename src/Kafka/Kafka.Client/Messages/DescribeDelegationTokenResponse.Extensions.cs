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
        private static readonly Func<Stream, DescribeDelegationTokenResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DescribeDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeDelegationTokenResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeDelegationTokenResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(buffer, b => DescribedDelegationTokenSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static DescribeDelegationTokenResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(buffer, b => DescribedDelegationTokenSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static DescribeDelegationTokenResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, b => DescribedDelegationTokenSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeDelegationTokenResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, b => DescribedDelegationTokenSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, message.TokensField, (b, i) => DescribedDelegationTokenSerde.WriteV03(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribedDelegationTokenSerde
        {
            public static DescribedDelegationToken ReadV00(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer);
                var expiryTimestampField = Decoder.ReadInt64(buffer);
                var maxTimestampField = Decoder.ReadInt64(buffer);
                var tokenIdField = Decoder.ReadString(buffer);
                var hmacField = Decoder.ReadBytes(buffer);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, b => DescribedDelegationTokenRenewerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
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
            public static void WriteV00(Stream buffer, DescribedDelegationToken message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
                Encoder.WriteInt64(buffer, message.IssueTimestampField);
                Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                Encoder.WriteInt64(buffer, message.MaxTimestampField);
                Encoder.WriteString(buffer, message.TokenIdField);
                Encoder.WriteBytes(buffer, message.HmacField);
                Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV00(b, i));
            }
            public static DescribedDelegationToken ReadV01(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer);
                var expiryTimestampField = Decoder.ReadInt64(buffer);
                var maxTimestampField = Decoder.ReadInt64(buffer);
                var tokenIdField = Decoder.ReadString(buffer);
                var hmacField = Decoder.ReadBytes(buffer);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, b => DescribedDelegationTokenRenewerSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
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
            public static void WriteV01(Stream buffer, DescribedDelegationToken message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
                Encoder.WriteInt64(buffer, message.IssueTimestampField);
                Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                Encoder.WriteInt64(buffer, message.MaxTimestampField);
                Encoder.WriteString(buffer, message.TokenIdField);
                Encoder.WriteBytes(buffer, message.HmacField);
                Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV01(b, i));
            }
            public static DescribedDelegationToken ReadV02(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer);
                var expiryTimestampField = Decoder.ReadInt64(buffer);
                var maxTimestampField = Decoder.ReadInt64(buffer);
                var tokenIdField = Decoder.ReadCompactString(buffer);
                var hmacField = Decoder.ReadCompactBytes(buffer);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, b => DescribedDelegationTokenRenewerSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV02(Stream buffer, DescribedDelegationToken message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteInt64(buffer, message.IssueTimestampField);
                Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                Encoder.WriteInt64(buffer, message.MaxTimestampField);
                Encoder.WriteCompactString(buffer, message.TokenIdField);
                Encoder.WriteCompactBytes(buffer, message.HmacField);
                Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribedDelegationToken ReadV03(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(buffer);
                var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(buffer);
                var issueTimestampField = Decoder.ReadInt64(buffer);
                var expiryTimestampField = Decoder.ReadInt64(buffer);
                var maxTimestampField = Decoder.ReadInt64(buffer);
                var tokenIdField = Decoder.ReadCompactString(buffer);
                var hmacField = Decoder.ReadCompactBytes(buffer);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, b => DescribedDelegationTokenRenewerSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV03(Stream buffer, DescribedDelegationToken message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.TokenRequesterPrincipalNameField);
                Encoder.WriteInt64(buffer, message.IssueTimestampField);
                Encoder.WriteInt64(buffer, message.ExpiryTimestampField);
                Encoder.WriteInt64(buffer, message.MaxTimestampField);
                Encoder.WriteCompactString(buffer, message.TokenIdField);
                Encoder.WriteCompactBytes(buffer, message.HmacField);
                Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, message.RenewersField, (b, i) => DescribedDelegationTokenRenewerSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DescribedDelegationTokenRenewerSerde
            {
                public static DescribedDelegationTokenRenewer ReadV00(Stream buffer)
                {
                    var principalTypeField = Decoder.ReadString(buffer);
                    var principalNameField = Decoder.ReadString(buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static void WriteV00(Stream buffer, DescribedDelegationTokenRenewer message)
                {
                    Encoder.WriteString(buffer, message.PrincipalTypeField);
                    Encoder.WriteString(buffer, message.PrincipalNameField);
                }
                public static DescribedDelegationTokenRenewer ReadV01(Stream buffer)
                {
                    var principalTypeField = Decoder.ReadString(buffer);
                    var principalNameField = Decoder.ReadString(buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static void WriteV01(Stream buffer, DescribedDelegationTokenRenewer message)
                {
                    Encoder.WriteString(buffer, message.PrincipalTypeField);
                    Encoder.WriteString(buffer, message.PrincipalNameField);
                }
                public static DescribedDelegationTokenRenewer ReadV02(Stream buffer)
                {
                    var principalTypeField = Decoder.ReadCompactString(buffer);
                    var principalNameField = Decoder.ReadCompactString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static void WriteV02(Stream buffer, DescribedDelegationTokenRenewer message)
                {
                    Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                    Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static DescribedDelegationTokenRenewer ReadV03(Stream buffer)
                {
                    var principalTypeField = Decoder.ReadCompactString(buffer);
                    var principalNameField = Decoder.ReadCompactString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static void WriteV03(Stream buffer, DescribedDelegationTokenRenewer message)
                {
                    Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                    Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}