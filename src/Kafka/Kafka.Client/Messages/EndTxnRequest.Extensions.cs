using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndTxnRequestSerde
    {
        private static readonly DecodeDelegate<EndTxnRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<EndTxnRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static EndTxnRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, EndTxnRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static EndTxnRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var committedField = Decoder.ReadBoolean(ref buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, EndTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.CommittedField);
            return buffer;
        }
        private static EndTxnRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var committedField = Decoder.ReadBoolean(ref buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, EndTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.CommittedField);
            return buffer;
        }
        private static EndTxnRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var committedField = Decoder.ReadBoolean(ref buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, EndTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.CommittedField);
            return buffer;
        }
        private static EndTxnRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var committedField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, EndTxnRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteBoolean(buffer, message.CommittedField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}