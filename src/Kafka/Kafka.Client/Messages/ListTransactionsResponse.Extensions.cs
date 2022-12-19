using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TransactionState = Kafka.Client.Messages.ListTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsResponseSerde
    {
        private static readonly DecodeDelegate<ListTransactionsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<ListTransactionsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static ListTransactionsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListTransactionsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListTransactionsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var unknownStateFiltersField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'UnknownStateFilters'");
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(buffer, ref index, TransactionStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                unknownStateFiltersField,
                transactionStatesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListTransactionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<string>(buffer, index, message.UnknownStateFiltersField, Encoder.WriteCompactString);
            index = Encoder.WriteCompactArray<TransactionState>(buffer, index, message.TransactionStatesField, TransactionStateSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(byte[] buffer, ref int index)
            {
                var transactionalIdField = Decoder.ReadCompactString(buffer, ref index);
                var producerIdField = Decoder.ReadInt64(buffer, ref index);
                var transactionStateField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    transactionalIdField,
                    producerIdField,
                    transactionStateField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TransactionState message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.TransactionStateField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}