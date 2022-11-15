using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class InitProducerIdRequestSerde
    {
        private static readonly Func<Stream, InitProducerIdRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, InitProducerIdRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static InitProducerIdRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, InitProducerIdRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static InitProducerIdRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static void WriteV00(Stream buffer, InitProducerIdRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
        }
        private static InitProducerIdRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static void WriteV01(Stream buffer, InitProducerIdRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
        }
        private static InitProducerIdRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static void WriteV02(Stream buffer, InitProducerIdRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static InitProducerIdRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static void WriteV03(Stream buffer, InitProducerIdRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static InitProducerIdRequest ReadV04(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static void WriteV04(Stream buffer, InitProducerIdRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}