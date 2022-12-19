using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UnregisterBrokerResponseSerde
    {
        private static readonly DecodeDelegate<UnregisterBrokerResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<UnregisterBrokerResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static UnregisterBrokerResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UnregisterBrokerResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UnregisterBrokerResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UnregisterBrokerResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}