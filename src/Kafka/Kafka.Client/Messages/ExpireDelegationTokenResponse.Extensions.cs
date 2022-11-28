using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<ExpireDelegationTokenResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<ExpireDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ExpireDelegationTokenResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ExpireDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ExpireDelegationTokenResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ExpireDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ExpireDelegationTokenResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ExpireDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ExpireDelegationTokenResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(ref buffer);
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ExpireDelegationTokenResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}