using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TransactionState = Kafka.Client.Messages.ListTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsResponseSerde
    {
        private static readonly Func<Stream, ListTransactionsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, ListTransactionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListTransactionsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListTransactionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListTransactionsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var unknownStateFiltersField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'UnknownStateFilters'");
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(buffer, b => TransactionStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                unknownStateFiltersField,
                transactionStatesField
            );
        }
        private static void WriteV00(Stream buffer, ListTransactionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<string>(buffer, message.UnknownStateFiltersField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteCompactArray<TransactionState>(buffer, message.TransactionStatesField, (b, i) => TransactionStateSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(Stream buffer)
            {
                var transactionalIdField = Decoder.ReadCompactString(buffer);
                var producerIdField = Decoder.ReadInt64(buffer);
                var transactionStateField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    transactionalIdField,
                    producerIdField,
                    transactionStateField
                );
            }
            public static void WriteV00(Stream buffer, TransactionState message)
            {
                Encoder.WriteCompactString(buffer, message.TransactionalIdField);
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteCompactString(buffer, message.TransactionStateField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}