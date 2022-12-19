using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationResponseSerde
    {
        private static readonly DecodeDelegate<BrokerRegistrationResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<BrokerRegistrationResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static BrokerRegistrationResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, BrokerRegistrationResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static BrokerRegistrationResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                brokerEpochField
            );
        }
        private static int WriteV00(byte[] buffer, int index, BrokerRegistrationResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}