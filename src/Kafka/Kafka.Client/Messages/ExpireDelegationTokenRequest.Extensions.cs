using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenRequestSerde
    {
        private static readonly Func<Stream, ExpireDelegationTokenRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, ExpireDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ExpireDelegationTokenRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ExpireDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ExpireDelegationTokenRequest ReadV00(Stream buffer)
        {
            var hmacField = Decoder.ReadBytes(buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static void WriteV00(Stream buffer, ExpireDelegationTokenRequest message)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
        }
        private static ExpireDelegationTokenRequest ReadV01(Stream buffer)
        {
            var hmacField = Decoder.ReadBytes(buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static void WriteV01(Stream buffer, ExpireDelegationTokenRequest message)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
        }
        private static ExpireDelegationTokenRequest ReadV02(Stream buffer)
        {
            var hmacField = Decoder.ReadCompactBytes(buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static void WriteV02(Stream buffer, ExpireDelegationTokenRequest message)
        {
            Encoder.WriteCompactBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}