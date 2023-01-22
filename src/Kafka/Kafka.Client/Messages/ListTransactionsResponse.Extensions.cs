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
       public static (int Offset, ListTransactionsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListTransactionsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListTransactionsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var unknownStateFiltersField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (unknownStateFiltersField == null)
               throw new NullReferenceException("Null not allowed for 'UnknownStateFilters'");
           (index, var transactionStatesField) = Decoder.ReadCompactArray<TransactionState>(buffer, index, TransactionStateSerde.ReadV00);
           if (transactionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TransactionStates'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               unknownStateFiltersField.Value,
               transactionStatesField.Value
           ));
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
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TransactionStateSerde
       {
           public static (int Offset, TransactionState Value) ReadV00(byte[] buffer, int index)
           {
               (index, var transactionalIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var transactionStateField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   transactionalIdField,
                   producerIdField,
                   transactionStateField
               ));
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