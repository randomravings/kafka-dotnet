using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsRequestSerde
    {
        private static readonly DecodeDelegate<AllocateProducerIdsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AllocateProducerIdsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AllocateProducerIdsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AllocateProducerIdsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AllocateProducerIdsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AllocateProducerIdsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}