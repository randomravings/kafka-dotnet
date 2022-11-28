using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TransactionState = Kafka.Client.Messages.ListTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsResponseSerde
    {
        private static readonly DecodeDelegate<ListTransactionsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<ListTransactionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListTransactionsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListTransactionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListTransactionsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var unknownStateFiltersField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'UnknownStateFilters'");
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => TransactionStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                unknownStateFiltersField,
                transactionStatesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListTransactionsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<string>(buffer, message.UnknownStateFiltersField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteCompactArray<TransactionState>(buffer, message.TransactionStatesField, (b, i) => TransactionStateSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var transactionalIdField = Decoder.ReadCompactString(ref buffer);
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var transactionStateField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    transactionalIdField,
                    producerIdField,
                    transactionStateField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TransactionState message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TransactionalIdField);
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteCompactString(buffer, message.TransactionStateField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}