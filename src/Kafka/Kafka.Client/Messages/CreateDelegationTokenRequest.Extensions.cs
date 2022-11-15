using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableRenewers = Kafka.Client.Messages.CreateDelegationTokenRequest.CreatableRenewers;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenRequestSerde
    {
        private static readonly Func<Stream, CreateDelegationTokenRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreateDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateDelegationTokenRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateDelegationTokenRequest ReadV00(Stream buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(buffer, b => CreatableRenewersSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static void WriteV00(Stream buffer, CreateDelegationTokenRequest message)
        {
            Encoder.WriteArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV00(b, i));
            Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
        }
        private static CreateDelegationTokenRequest ReadV01(Stream buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(buffer, b => CreatableRenewersSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static void WriteV01(Stream buffer, CreateDelegationTokenRequest message)
        {
            Encoder.WriteArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV01(b, i));
            Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
        }
        private static CreateDelegationTokenRequest ReadV02(Stream buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(buffer, b => CreatableRenewersSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static void WriteV02(Stream buffer, CreateDelegationTokenRequest message)
        {
            Encoder.WriteCompactArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV02(b, i));
            Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateDelegationTokenRequest ReadV03(Stream buffer)
        {
            var ownerPrincipalTypeField = Decoder.ReadCompactNullableString(buffer);
            var ownerPrincipalNameField = Decoder.ReadCompactNullableString(buffer);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(buffer, b => CreatableRenewersSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static void WriteV03(Stream buffer, CreateDelegationTokenRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.OwnerPrincipalTypeField);
            Encoder.WriteCompactNullableString(buffer, message.OwnerPrincipalNameField);
            Encoder.WriteCompactArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV03(b, i));
            Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CreatableRenewersSerde
        {
            public static CreatableRenewers ReadV00(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV00(Stream buffer, CreatableRenewers message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
            }
            public static CreatableRenewers ReadV01(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV01(Stream buffer, CreatableRenewers message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
            }
            public static CreatableRenewers ReadV02(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV02(Stream buffer, CreatableRenewers message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatableRenewers ReadV03(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV03(Stream buffer, CreatableRenewers message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}