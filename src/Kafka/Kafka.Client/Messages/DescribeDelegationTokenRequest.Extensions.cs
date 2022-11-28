using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeDelegationTokenOwner = Kafka.Client.Messages.DescribeDelegationTokenRequest.DescribeDelegationTokenOwner;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<DescribeDelegationTokenRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<DescribeDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeDelegationTokenRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeDelegationTokenRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeDelegationTokenOwnerSerde.ReadV00(ref b));
            return new(
                ownersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeDelegationTokenRequest message)
        {
            buffer = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeDelegationTokenRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeDelegationTokenOwnerSerde.ReadV01(ref b));
            return new(
                ownersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeDelegationTokenRequest message)
        {
            buffer = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeDelegationTokenRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeDelegationTokenOwnerSerde.ReadV02(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                ownersField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeDelegationTokenRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeDelegationTokenOwnerSerde.ReadV03(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                ownersField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeDelegationTokenOwnerSerde
        {
            public static DescribeDelegationTokenOwner ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeDelegationTokenOwner message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                return buffer;
            }
            public static DescribeDelegationTokenOwner ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadString(ref buffer);
                var principalNameField = Decoder.ReadString(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeDelegationTokenOwner message)
            {
                buffer = Encoder.WriteString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalNameField);
                return buffer;
            }
            public static DescribeDelegationTokenOwner ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeDelegationTokenOwner message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribeDelegationTokenOwner ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(ref buffer);
                var principalNameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeDelegationTokenOwner message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}