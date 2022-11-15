using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RenewDelegationTokenRequestSerde
    {
        private static readonly Func<Stream, RenewDelegationTokenRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, RenewDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static RenewDelegationTokenRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, RenewDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static RenewDelegationTokenRequest ReadV00(Stream buffer)
        {
            var hmacField = Decoder.ReadBytes(buffer);
            var renewPeriodMsField = Decoder.ReadInt64(buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static void WriteV00(Stream buffer, RenewDelegationTokenRequest message)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
        }
        private static RenewDelegationTokenRequest ReadV01(Stream buffer)
        {
            var hmacField = Decoder.ReadBytes(buffer);
            var renewPeriodMsField = Decoder.ReadInt64(buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static void WriteV01(Stream buffer, RenewDelegationTokenRequest message)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
        }
        private static RenewDelegationTokenRequest ReadV02(Stream buffer)
        {
            var hmacField = Decoder.ReadCompactBytes(buffer);
            var renewPeriodMsField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static void WriteV02(Stream buffer, RenewDelegationTokenRequest message)
        {
            Encoder.WriteCompactBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}