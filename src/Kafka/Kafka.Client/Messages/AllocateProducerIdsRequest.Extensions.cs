using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsRequestSerde
    {
        private static readonly Func<Stream, AllocateProducerIdsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AllocateProducerIdsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AllocateProducerIdsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AllocateProducerIdsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AllocateProducerIdsRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static void WriteV00(Stream buffer, AllocateProducerIdsRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}