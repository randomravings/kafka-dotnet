using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UnregisterBrokerRequestSerde
    {
        private static readonly DecodeDelegate<UnregisterBrokerRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<UnregisterBrokerRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static UnregisterBrokerRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UnregisterBrokerRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UnregisterBrokerRequest ReadV00(byte[] buffer, ref int index)
        {
            var brokerIdField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                brokerIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UnregisterBrokerRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}