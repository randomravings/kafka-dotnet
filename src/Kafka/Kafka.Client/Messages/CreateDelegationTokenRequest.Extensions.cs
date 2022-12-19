using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatableRenewers = Kafka.Client.Messages.CreateDelegationTokenRequest.CreatableRenewers;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<CreateDelegationTokenRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<CreateDelegationTokenRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static CreateDelegationTokenRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateDelegationTokenRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateDelegationTokenRequest ReadV00(byte[] buffer, ref int index)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(buffer, ref index, CreatableRenewersSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateDelegationTokenRequest message)
        {
            index = Encoder.WriteArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV00);
            index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
            return index;
        }
        private static CreateDelegationTokenRequest ReadV01(byte[] buffer, ref int index)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(buffer, ref index, CreatableRenewersSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateDelegationTokenRequest message)
        {
            index = Encoder.WriteArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV01);
            index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
            return index;
        }
        private static CreateDelegationTokenRequest ReadV02(byte[] buffer, ref int index)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(buffer, ref index, CreatableRenewersSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateDelegationTokenRequest message)
        {
            index = Encoder.WriteCompactArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV02);
            index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateDelegationTokenRequest ReadV03(byte[] buffer, ref int index)
        {
            var ownerPrincipalTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var ownerPrincipalNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(buffer, ref index, CreatableRenewersSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateDelegationTokenRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.OwnerPrincipalTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.OwnerPrincipalNameField);
            index = Encoder.WriteCompactArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV03);
            index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CreatableRenewersSerde
        {
            public static CreatableRenewers ReadV00(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadString(buffer, ref index);
                var principalNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static int WriteV00(byte[] buffer, int index, CreatableRenewers message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                return index;
            }
            public static CreatableRenewers ReadV01(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadString(buffer, ref index);
                var principalNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static int WriteV01(byte[] buffer, int index, CreatableRenewers message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                return index;
            }
            public static CreatableRenewers ReadV02(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static int WriteV02(byte[] buffer, int index, CreatableRenewers message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatableRenewers ReadV03(byte[] buffer, ref int index)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var principalNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static int WriteV03(byte[] buffer, int index, CreatableRenewers message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}