using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsResponseSerde
    {
        private static readonly DecodeDelegate<AllocateProducerIdsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AllocateProducerIdsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AllocateProducerIdsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AllocateProducerIdsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AllocateProducerIdsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdStartField = Decoder.ReadInt64(ref buffer);
            var producerIdLenField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdStartField,
                producerIdLenField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AllocateProducerIdsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdStartField);
            buffer = Encoder.WriteInt32(buffer, message.ProducerIdLenField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}