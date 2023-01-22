using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using WritableTxnMarkerPartitionResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult;
using WritableTxnMarkerResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult;
using WritableTxnMarkerTopicResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class WriteTxnMarkersResponseSerde
   {
       private static readonly DecodeDelegate<WriteTxnMarkersResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<WriteTxnMarkersResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, WriteTxnMarkersResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, WriteTxnMarkersResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, WriteTxnMarkersResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var markersField) = Decoder.ReadArray<WritableTxnMarkerResult>(buffer, index, WritableTxnMarkerResultSerde.ReadV00);
           if (markersField == null)
               throw new NullReferenceException("Null not allowed for 'Markers'");
           return (index, new(
               markersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, WriteTxnMarkersResponse message)
       {
           index = Encoder.WriteArray<WritableTxnMarkerResult>(buffer, index, message.MarkersField, WritableTxnMarkerResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, WriteTxnMarkersResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var markersField) = Decoder.ReadCompactArray<WritableTxnMarkerResult>(buffer, index, WritableTxnMarkerResultSerde.ReadV01);
           if (markersField == null)
               throw new NullReferenceException("Null not allowed for 'Markers'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               markersField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, WriteTxnMarkersResponse message)
       {
           index = Encoder.WriteCompactArray<WritableTxnMarkerResult>(buffer, index, message.MarkersField, WritableTxnMarkerResultSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class WritableTxnMarkerResultSerde
       {
           public static (int Offset, WritableTxnMarkerResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<WritableTxnMarkerTopicResult>(buffer, index, WritableTxnMarkerTopicResultSerde.ReadV00);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               return (index, new(
                   producerIdField,
                   topicsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerResult message)
           {
               index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
               index = Encoder.WriteArray<WritableTxnMarkerTopicResult>(buffer, index, message.TopicsField, WritableTxnMarkerTopicResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, WritableTxnMarkerResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<WritableTxnMarkerTopicResult>(buffer, index, WritableTxnMarkerTopicResultSerde.ReadV01);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   producerIdField,
                   topicsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerResult message)
           {
               index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
               index = Encoder.WriteCompactArray<WritableTxnMarkerTopicResult>(buffer, index, message.TopicsField, WritableTxnMarkerTopicResultSerde.WriteV01);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class WritableTxnMarkerTopicResultSerde
           {
               public static (int Offset, WritableTxnMarkerTopicResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadArray<WritableTxnMarkerPartitionResult>(buffer, index, WritableTxnMarkerPartitionResultSerde.ReadV00);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerTopicResult message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<WritableTxnMarkerPartitionResult>(buffer, index, message.PartitionsField, WritableTxnMarkerPartitionResultSerde.WriteV00);
                   return index;
               }
               public static (int Offset, WritableTxnMarkerTopicResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<WritableTxnMarkerPartitionResult>(buffer, index, WritableTxnMarkerPartitionResultSerde.ReadV01);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerTopicResult message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<WritableTxnMarkerPartitionResult>(buffer, index, message.PartitionsField, WritableTxnMarkerPartitionResultSerde.WriteV01);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class WritableTxnMarkerPartitionResultSerde
               {
                   public static (int Offset, WritableTxnMarkerPartitionResult Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerPartitionResult message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                       return index;
                   }
                   public static (int Offset, WritableTxnMarkerPartitionResult Value) ReadV01(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerPartitionResult message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}