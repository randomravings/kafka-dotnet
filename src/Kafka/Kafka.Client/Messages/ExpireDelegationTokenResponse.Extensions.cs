using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenResponseSerde
    {
        private static readonly DecodeDelegate<ExpireDelegationTokenResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<ExpireDelegationTokenResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static ExpireDelegationTokenResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ExpireDelegationTokenResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ExpireDelegationTokenResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ExpireDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ExpireDelegationTokenResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ExpireDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ExpireDelegationTokenResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var expiryTimestampMsField = Decoder.ReadInt64(buffer, ref index);
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                expiryTimestampMsField,
                throttleTimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ExpireDelegationTokenResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}