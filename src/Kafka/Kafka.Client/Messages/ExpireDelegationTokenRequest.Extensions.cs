using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<ExpireDelegationTokenRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<ExpireDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ExpireDelegationTokenRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ExpireDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ExpireDelegationTokenRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadBytes(ref buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(ref buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ExpireDelegationTokenRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
            return buffer;
        }
        private static ExpireDelegationTokenRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadBytes(ref buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(ref buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ExpireDelegationTokenRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
            return buffer;
        }
        private static ExpireDelegationTokenRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadCompactBytes(ref buffer);
            var expiryTimePeriodMsField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                hmacField,
                expiryTimePeriodMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ExpireDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}