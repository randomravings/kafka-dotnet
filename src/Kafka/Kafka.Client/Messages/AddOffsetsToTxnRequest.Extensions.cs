using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddOffsetsToTxnRequestSerde
    {
        private static readonly Func<Stream, AddOffsetsToTxnRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, AddOffsetsToTxnRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static AddOffsetsToTxnRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AddOffsetsToTxnRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AddOffsetsToTxnRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static void WriteV00(Stream buffer, AddOffsetsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteString(buffer, message.GroupIdField);
        }
        private static AddOffsetsToTxnRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static void WriteV01(Stream buffer, AddOffsetsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteString(buffer, message.GroupIdField);
        }
        private static AddOffsetsToTxnRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static void WriteV02(Stream buffer, AddOffsetsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteString(buffer, message.GroupIdField);
        }
        private static AddOffsetsToTxnRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var groupIdField = Decoder.ReadCompactString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static void WriteV03(Stream buffer, AddOffsetsToTxnRequest message)
        {
            Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}