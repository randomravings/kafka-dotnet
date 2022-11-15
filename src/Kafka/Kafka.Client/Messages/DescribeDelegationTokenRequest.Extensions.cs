using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeDelegationTokenOwner = Kafka.Client.Messages.DescribeDelegationTokenRequest.DescribeDelegationTokenOwner;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenRequestSerde
    {
        private static readonly Func<Stream, DescribeDelegationTokenRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DescribeDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeDelegationTokenRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeDelegationTokenRequest ReadV00(Stream buffer)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, b => DescribeDelegationTokenOwnerSerde.ReadV00(b));
            return new(
                ownersField
            );
        }
        private static void WriteV00(Stream buffer, DescribeDelegationTokenRequest message)
        {
            Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV00(b, i));
        }
        private static DescribeDelegationTokenRequest ReadV01(Stream buffer)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, b => DescribeDelegationTokenOwnerSerde.ReadV01(b));
            return new(
                ownersField
            );
        }
        private static void WriteV01(Stream buffer, DescribeDelegationTokenRequest message)
        {
            Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV01(b, i));
        }
        private static DescribeDelegationTokenRequest ReadV02(Stream buffer)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, b => DescribeDelegationTokenOwnerSerde.ReadV02(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                ownersField
            );
        }
        private static void WriteV02(Stream buffer, DescribeDelegationTokenRequest message)
        {
            Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeDelegationTokenRequest ReadV03(Stream buffer)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, b => DescribeDelegationTokenOwnerSerde.ReadV03(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                ownersField
            );
        }
        private static void WriteV03(Stream buffer, DescribeDelegationTokenRequest message)
        {
            Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, message.OwnersField, (b, i) => DescribeDelegationTokenOwnerSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeDelegationTokenOwnerSerde
        {
            public static DescribeDelegationTokenOwner ReadV00(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV00(Stream buffer, DescribeDelegationTokenOwner message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
            }
            public static DescribeDelegationTokenOwner ReadV01(Stream buffer)
            {
                var principalTypeField = Decoder.ReadString(buffer);
                var principalNameField = Decoder.ReadString(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV01(Stream buffer, DescribeDelegationTokenOwner message)
            {
                Encoder.WriteString(buffer, message.PrincipalTypeField);
                Encoder.WriteString(buffer, message.PrincipalNameField);
            }
            public static DescribeDelegationTokenOwner ReadV02(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV02(Stream buffer, DescribeDelegationTokenOwner message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribeDelegationTokenOwner ReadV03(Stream buffer)
            {
                var principalTypeField = Decoder.ReadCompactString(buffer);
                var principalNameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    principalTypeField,
                    principalNameField
                );
            }
            public static void WriteV03(Stream buffer, DescribeDelegationTokenOwner message)
            {
                Encoder.WriteCompactString(buffer, message.PrincipalTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalNameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}