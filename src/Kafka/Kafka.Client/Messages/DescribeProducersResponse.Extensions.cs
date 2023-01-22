using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ProducerState = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse.ProducerState;
using TopicResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse;
using PartitionResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeProducersResponseSerde
   {
       private static readonly DecodeDelegate<DescribeProducersResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<DescribeProducersResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, DescribeProducersResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeProducersResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeProducersResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicResponse>(buffer, index, TopicResponseSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeProducersResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<TopicResponse>(buffer, index, message.TopicsField, TopicResponseSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicResponseSerde
       {
           public static (int Offset, TopicResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionResponse>(buffer, index, PartitionResponseSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<PartitionResponse>(buffer, index, message.PartitionsField, PartitionResponseSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionResponseSerde
           {
               public static (int Offset, PartitionResponse Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var activeProducersField) = Decoder.ReadCompactArray<ProducerState>(buffer, index, ProducerStateSerde.ReadV00);
                   if (activeProducersField == null)
                       throw new NullReferenceException("Null not allowed for 'ActiveProducers'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       errorMessageField,
                       activeProducersField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteCompactArray<ProducerState>(buffer, index, message.ActiveProducersField, ProducerStateSerde.WriteV00);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class ProducerStateSerde
               {
                   public static (int Offset, ProducerState Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var producerEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, var lastSequenceField) = Decoder.ReadInt32(buffer, index);
                       (index, var lastTimestampField) = Decoder.ReadInt64(buffer, index);
                       (index, var coordinatorEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, var currentTxnStartOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           producerIdField,
                           producerEpochField,
                           lastSequenceField,
                           lastTimestampField,
                           coordinatorEpochField,
                           currentTxnStartOffsetField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, ProducerState message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt32(buffer, index, message.ProducerEpochField);
                       index = Encoder.WriteInt32(buffer, index, message.LastSequenceField);
                       index = Encoder.WriteInt64(buffer, index, message.LastTimestampField);
                       index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
                       index = Encoder.WriteInt64(buffer, index, message.CurrentTxnStartOffsetField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}