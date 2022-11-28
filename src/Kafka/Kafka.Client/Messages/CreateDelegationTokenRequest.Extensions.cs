using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableRenewers = Kafka.Client.Messages.CreateDelegationTokenRequest.CreatableRenewers;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<CreateDelegationTokenRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<CreateDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateDelegationTokenRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateDelegationTokenRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableRenewersSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(ref buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateDelegationTokenRequest message)
        {
            buffer = Encoder.WriteArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            return buffer;
        }
        private static CreateDelegationTokenRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadArray<CreatableRenewers>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableRenewersSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(ref buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateDelegationTokenRequest message)
        {
            buffer = Encoder.WriteArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            return buffer;
        }
        private static CreateDelegationTokenRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var ownerPrincipalTypeField = default(string?);
            var ownerPrincipalNameField = default(string?);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableRenewersSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateDelegationTokenRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var ownerPrincipalTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var ownerPrincipalNameField = Decoder.ReadCompactNullableString(ref buffer);
            var renewersField = Decoder.ReadCompactArray<CreatableRenewers>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableRenewersSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Renewers'");
            var maxLifetimeMsField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                ownerPrincipalTypeField,
                ownerPrincipalNameField,
                renewersField,
                maxLifetimeMsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.OwnerPrincipalTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.OwnerPrincipalNameField);
            buffer = Encoder.WriteCompactArray<CreatableRenewers>(buffer, message.RenewersField, (b, i) => CreatableRenewersSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class CreatableRenewersSerde
        {
            public static CreatableRenewers ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, CreatableRenewers message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                return buffer;
            }
            public static CreatableRenewers ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, CreatableRenewers message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                return buffer;
            }
            public static CreatableRenewers ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, CreatableRenewers message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatableRenewers ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, CreatableRenewers message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}