using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeDelegationTokenOwner = Kafka.Client.Messages.DescribeDelegationTokenRequest.DescribeDelegationTokenOwner;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<DescribeDelegationTokenRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<DescribeDelegationTokenRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static DescribeDelegationTokenRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeDelegationTokenRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeDelegationTokenRequest ReadV00(byte[] buffer, ref int index)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, ref index, DescribeDelegationTokenOwnerSerde.ReadV00);
            return new(
                ownersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenRequest message)
        {
            index = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV00);
            return index;
        }
        private static DescribeDelegationTokenRequest ReadV01(byte[] buffer, ref int index)
        {
            var ownersField = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, ref index, DescribeDelegationTokenOwnerSerde.ReadV01);
            return new(
                ownersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenRequest message)
        {
            index = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV01);
            return index;
        }
        private static DescribeDelegationTokenRequest ReadV02(byte[] buffer, ref int index)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, ref index, DescribeDelegationTokenOwnerSerde.ReadV02);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                ownersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenRequest message)
        {
            index = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeDelegationTokenRequest ReadV03(byte[] buffer, ref int index)
        {
            var ownersField = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, ref index, DescribeDelegationTokenOwnerSerde.ReadV03);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                ownersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenRequest message)
        {
            index = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeDelegationTokenOwnerSerde
        {
            public static DescribeDelegationTokenOwner ReadV00(byte[] buffer, ref int index)
            {
                var PrincipalTypeField = Decoder.ReadString(buffer, ref index);
                var PrincipalNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    PrincipalTypeField,
                    PrincipalNameField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenOwner message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                return index;
            }
            public static DescribeDelegationTokenOwner ReadV01(byte[] buffer, ref int index)
            {
                var PrincipalTypeField = Decoder.ReadString(buffer, ref index);
                var PrincipalNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    PrincipalTypeField,
                    PrincipalNameField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenOwner message)
            {
                index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                return index;
            }
            public static DescribeDelegationTokenOwner ReadV02(byte[] buffer, ref int index)
            {
                var PrincipalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var PrincipalNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    PrincipalTypeField,
                    PrincipalNameField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenOwner message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DescribeDelegationTokenOwner ReadV03(byte[] buffer, ref int index)
            {
                var PrincipalTypeField = Decoder.ReadCompactString(buffer, ref index);
                var PrincipalNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    PrincipalTypeField,
                    PrincipalNameField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenOwner message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}