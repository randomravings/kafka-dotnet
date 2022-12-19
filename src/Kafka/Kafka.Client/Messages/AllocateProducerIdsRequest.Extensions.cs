using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsRequestSerde
    {
        private static readonly DecodeDelegate<AllocateProducerIdsRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<AllocateProducerIdsRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static AllocateProducerIdsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AllocateProducerIdsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AllocateProducerIdsRequest ReadV00(byte[] buffer, ref int index)
        {
            var brokerIdField = Decoder.ReadInt32(buffer, ref index);
            var brokerEpochField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AllocateProducerIdsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
            index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}