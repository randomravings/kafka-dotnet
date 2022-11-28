using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class InitProducerIdResponseSerde
    {
        private static readonly DecodeDelegate<InitProducerIdResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<InitProducerIdResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static InitProducerIdResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, InitProducerIdResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static InitProducerIdResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, InitProducerIdResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            return buffer;
        }
        private static InitProducerIdResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, InitProducerIdResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            return buffer;
        }
        private static InitProducerIdResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, InitProducerIdResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static InitProducerIdResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, InitProducerIdResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static InitProducerIdResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, InitProducerIdResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}