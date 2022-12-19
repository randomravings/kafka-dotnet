using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribedDelegationTokenRenewer = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken.DescribedDelegationTokenRenewer;
using DescribedDelegationToken = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<DescribeDelegationTokenResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<DescribeDelegationTokenResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static DescribeDelegationTokenResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeDelegationTokenResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeDelegationTokenResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(buffer, ref index, DescribedDelegationTokenSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static DescribeDelegationTokenResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var tokensField = Decoder.ReadArray<DescribedDelegationToken>(buffer, ref index, DescribedDelegationTokenSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static DescribeDelegationTokenResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, ref index, DescribedDelegationTokenSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeDelegationTokenResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var tokensField = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, ref index, DescribedDelegationTokenSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Tokens'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                tokensField,
                throttleTimeMsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV03);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribedDelegationTokenSerde
        {
            public static DescribedDelegationToken ReadV00(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadString(buffer, ref index);
                var principalNameField = Decoder.ReadString(buffer, ref index);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer, ref index);
                var expiryTimestampField = Decoder.ReadInt64(buffer, ref index);
                var maxTimestampField = Decoder.ReadInt64(buffer, ref index);
                var tokenIdField = Decoder.ReadString(buffer, ref index);
                var hmacField = Decoder.ReadBytes(buffer, ref index);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, ref index, DescribedDelegationTokenRenewerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
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
            public static int WriteV00(byte[] buffer, int index, DescribedDelegationToken message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
                index = Encoder.WriteString(buffer, index, message.TokenIdField);
                index = Encoder.WriteBytes(buffer, index, message.HmacField);
                index = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV00);
                return index;
            }
            public static DescribedDelegationToken ReadV01(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadString(buffer, ref index);
                var principalNameField = Decoder.ReadString(buffer, ref index);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer, ref index);
                var expiryTimestampField = Decoder.ReadInt64(buffer, ref index);
                var maxTimestampField = Decoder.ReadInt64(buffer, ref index);
                var tokenIdField = Decoder.ReadString(buffer, ref index);
                var hmacField = Decoder.ReadBytes(buffer, ref index);
                var renewersField = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, ref index, DescribedDelegationTokenRenewerSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
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
            public static int WriteV01(byte[] buffer, int index, DescribedDelegationToken message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
                index = Encoder.WriteString(buffer, index, message.TokenIdField);
                index = Encoder.WriteBytes(buffer, index, message.HmacField);
                index = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV01);
                return index;
            }
            public static DescribedDelegationToken ReadV02(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                var tokenRequesterPrincipalTypeField = "";
                var tokenRequesterPrincipalNameField = "";
                var issueTimestampField = Decoder.ReadInt64(buffer, ref index);
                var expiryTimestampField = Decoder.ReadInt64(buffer, ref index);
                var maxTimestampField = Decoder.ReadInt64(buffer, ref index);
                var tokenIdField = Decoder.ReadCompactString(buffer, ref index);
                var hmacField = Decoder.ReadCompactBytes(buffer, ref index);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, ref index, DescribedDelegationTokenRenewerSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
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
            public static int WriteV02(byte[] buffer, int index, DescribedDelegationToken message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
                index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
                index = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribedDelegationToken ReadV03(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                var tokenRequesterPrincipalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var tokenRequesterPrincipalNameField = Decoder.ReadCompactString(buffer, ref index);
                var issueTimestampField = Decoder.ReadInt64(buffer, ref index);
                var expiryTimestampField = Decoder.ReadInt64(buffer, ref index);
                var maxTimestampField = Decoder.ReadInt64(buffer, ref index);
                var tokenIdField = Decoder.ReadCompactString(buffer, ref index);
                var hmacField = Decoder.ReadCompactBytes(buffer, ref index);
                var renewersField = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, ref index, DescribedDelegationTokenRenewerSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
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
            public static int WriteV03(byte[] buffer, int index, DescribedDelegationToken message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalNameField);
                index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
                index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
                index = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DescribedDelegationTokenRenewerSerde
            {
                public static DescribedDelegationTokenRenewer ReadV00(byte[] buffer, ref int index)
                {
                    var principalTypeField = Decoder.ReadString(buffer, ref index);
                    var principalNameField = Decoder.ReadString(buffer, ref index);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
                {
                    index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                    index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                    return index;
                }
                public static DescribedDelegationTokenRenewer ReadV01(byte[] buffer, ref int index)
                {
                    var principalTypeField = Decoder.ReadString(buffer, ref index);
                    var principalNameField = Decoder.ReadString(buffer, ref index);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
                {
                    index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                    index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                    return index;
                }
                public static DescribedDelegationTokenRenewer ReadV02(byte[] buffer, ref int index)
                {
                    var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                    var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                    index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static DescribedDelegationTokenRenewer ReadV03(byte[] buffer, ref int index)
                {
                    var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                    var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        principalTypeField,
                        principalNameField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                    index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}