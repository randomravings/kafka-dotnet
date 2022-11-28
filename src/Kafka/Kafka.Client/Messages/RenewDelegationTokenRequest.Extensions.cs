using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RenewDelegationTokenRequestSerde
    {
        private static readonly DecodeDelegate<RenewDelegationTokenRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<RenewDelegationTokenRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static RenewDelegationTokenRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, RenewDelegationTokenRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static RenewDelegationTokenRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadBytes(ref buffer);
            var renewPeriodMsField = Decoder.ReadInt64(ref buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, RenewDelegationTokenRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
            return buffer;
        }
        private static RenewDelegationTokenRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadBytes(ref buffer);
            var renewPeriodMsField = Decoder.ReadInt64(ref buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, RenewDelegationTokenRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
            return buffer;
        }
        private static RenewDelegationTokenRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var hmacField = Decoder.ReadCompactBytes(ref buffer);
            var renewPeriodMsField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                hmacField,
                renewPeriodMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, RenewDelegationTokenRequest message)
        {
            buffer = Encoder.WriteCompactBytes(buffer, message.HmacField);
            buffer = Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}