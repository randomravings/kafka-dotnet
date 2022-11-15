using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndTxnRequestSerde
    {
        private static readonly Func<Stream, EndTxnRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, EndTxnRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static EndTxnRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, EndTxnRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static EndTxnRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var committedField = Decoder.ReadBoolean(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static void WriteV00(Stream buffer, EndTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteBoolean(buffer, message.CommittedField);
        }
        private static EndTxnRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var committedField = Decoder.ReadBoolean(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static void WriteV01(Stream buffer, EndTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteBoolean(buffer, message.CommittedField);
        }
        private static EndTxnRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var committedField = Decoder.ReadBoolean(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static void WriteV02(Stream buffer, EndTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteBoolean(buffer, message.CommittedField);
        }
        private static EndTxnRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var committedField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                committedField
            );
        }
        private static void WriteV03(Stream buffer, EndTxnRequest message)
        {
            Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteBoolean(buffer, message.CommittedField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}