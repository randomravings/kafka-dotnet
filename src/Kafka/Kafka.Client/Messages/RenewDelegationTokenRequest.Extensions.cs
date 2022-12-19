using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RenewDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<RenewDelegationTokenRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<RenewDelegationTokenRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static RenewDelegationTokenRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, RenewDelegationTokenRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static RenewDelegationTokenRequest ReadV00(byte[] buffer, ref int index)
        {
            var hmacField = Decoder.ReadBytes(buffer, ref index);
            var renewPeriodMsField = Decoder.ReadInt64(buffer, ref index);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, RenewDelegationTokenRequest message)
        {
            index = Encoder.WriteBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
            return index;
        }
        private static RenewDelegationTokenRequest ReadV01(byte[] buffer, ref int index)
        {
            var hmacField = Decoder.ReadBytes(buffer, ref index);
            var renewPeriodMsField = Decoder.ReadInt64(buffer, ref index);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, RenewDelegationTokenRequest message)
        {
            index = Encoder.WriteBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
            return index;
        }
        private static RenewDelegationTokenRequest ReadV02(byte[] buffer, ref int index)
        {
            var hmacField = Decoder.ReadCompactBytes(buffer, ref index);
            var renewPeriodMsField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, RenewDelegationTokenRequest message)
        {
            index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
            index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}