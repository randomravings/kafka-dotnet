using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeTransactionsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeTransactionsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<DescribeTransactionsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, DescribeTransactionsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeTransactionsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeTransactionsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var transactionStatesField) = Decoder.ReadCompactArray<TransactionState>(buffer, index, TransactionStateSerde.ReadV00);
           if (transactionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TransactionStates'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               transactionStatesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeTransactionsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<TransactionState>(buffer, index, message.TransactionStatesField, TransactionStateSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TransactionStateSerde
       {
           public static (int Offset, TransactionState Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var transactionalIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var transactionStateField) = Decoder.ReadCompactString(buffer, index);
               (index, var transactionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
               (index, var transactionStartTimeMsField) = Decoder.ReadInt64(buffer, index);
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV00);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   transactionalIdField,
                   transactionStateField,
                   transactionTimeoutMsField,
                   transactionStartTimeMsField,
                   producerIdField,
                   producerEpochField,
                   topicsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TransactionState message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
               index = Encoder.WriteCompactString(buffer, index, message.TransactionStateField);
               index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
               index = Encoder.WriteInt64(buffer, index, message.TransactionStartTimeMsField);
               index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
               index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
               index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class TopicDataSerde
           {
               public static (int Offset, TopicData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var topicField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       topicField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, TopicData message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}