using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RenewDelegationTokenResponseSerde
    {
        private static readonly Func<Stream, RenewDelegationTokenResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, RenewDelegationTokenResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static RenewDelegationTokenResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, RenewDelegationTokenResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static RenewDelegationTokenResponse ReadV00(Stream buffer)
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
        private static void WriteV00(Stream buffer, RenewDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static RenewDelegationTokenResponse ReadV01(Stream buffer)
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
        private static void WriteV01(Stream buffer, RenewDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static RenewDelegationTokenResponse ReadV02(Stream buffer)
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
        private static void WriteV02(Stream buffer, RenewDelegationTokenResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}