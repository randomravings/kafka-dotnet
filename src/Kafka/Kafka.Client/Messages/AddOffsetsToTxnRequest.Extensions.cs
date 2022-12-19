using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddOffsetsToTxnRequestSerde
    {
        private static readonly DecodeDelegate<AddOffsetsToTxnRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<AddOffsetsToTxnRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static AddOffsetsToTxnRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AddOffsetsToTxnRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AddOffsetsToTxnRequest ReadV00(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AddOffsetsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            return index;
        }
        private static AddOffsetsToTxnRequest ReadV01(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AddOffsetsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            return index;
        }
        private static AddOffsetsToTxnRequest ReadV02(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AddOffsetsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            return index;
        }
        private static AddOffsetsToTxnRequest ReadV03(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                groupIdField
            );
        }
        private static int WriteV03(byte[] buffer, int index, AddOffsetsToTxnRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}