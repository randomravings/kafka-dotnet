using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsResponseSerde
    {
        private static readonly Func<Stream, AllocateProducerIdsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AllocateProducerIdsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AllocateProducerIdsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AllocateProducerIdsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AllocateProducerIdsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var producerIdStartField = Decoder.ReadInt64(buffer);
            var producerIdLenField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdStartField,
                producerIdLenField
            );
        }
        private static void WriteV00(Stream buffer, AllocateProducerIdsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ProducerIdStartField);
            Encoder.WriteInt32(buffer, message.ProducerIdLenField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}