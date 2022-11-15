using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenResponseSerde
    {
        private static readonly Func<Stream, ExpireDelegationTokenResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, ExpireDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ExpireDelegationTokenResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ExpireDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ExpireDelegationTokenResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static void WriteV00(Stream buffer, ExpireDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ExpireDelegationTokenResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static void WriteV01(Stream buffer, ExpireDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ExpireDelegationTokenResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer);
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static void WriteV02(Stream buffer, ExpireDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}