using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class InitProducerIdRequestSerde
    {
        private static readonly DecodeDelegate<InitProducerIdRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<InitProducerIdRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static InitProducerIdRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, InitProducerIdRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static InitProducerIdRequest ReadV00(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static int WriteV00(byte[] buffer, int index, InitProducerIdRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
            return index;
        }
        private static InitProducerIdRequest ReadV01(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static int WriteV01(byte[] buffer, int index, InitProducerIdRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
            return index;
        }
        private static InitProducerIdRequest ReadV02(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static int WriteV02(byte[] buffer, int index, InitProducerIdRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static InitProducerIdRequest ReadV03(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static int WriteV03(byte[] buffer, int index, InitProducerIdRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static InitProducerIdRequest ReadV04(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static int WriteV04(byte[] buffer, int index, InitProducerIdRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}