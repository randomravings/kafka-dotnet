using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class InitProducerIdRequestSerde
    {
        private static readonly DecodeDelegate<InitProducerIdRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<InitProducerIdRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static InitProducerIdRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, InitProducerIdRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static InitProducerIdRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, InitProducerIdRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            return buffer;
        }
        private static InitProducerIdRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, InitProducerIdRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            return buffer;
        }
        private static InitProducerIdRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(ref buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var producerIdField = default(long);
            var producerEpochField = default(short);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, InitProducerIdRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static InitProducerIdRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(ref buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, InitProducerIdRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static InitProducerIdRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(ref buffer);
            var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                transactionTimeoutMsField,
                producerIdField,
                producerEpochField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, InitProducerIdRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}