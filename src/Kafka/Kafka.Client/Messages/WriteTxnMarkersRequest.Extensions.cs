using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using WritableTxnMarker = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker;
using WritableTxnMarkerTopic = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker.WritableTxnMarkerTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class WriteTxnMarkersRequestSerde
   {
       private static readonly DecodeDelegate<WriteTxnMarkersRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<WriteTxnMarkersRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, WriteTxnMarkersRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, WriteTxnMarkersRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, WriteTxnMarkersRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var markersField) = Decoder.ReadArray<WritableTxnMarker>(buffer, index, WritableTxnMarkerSerde.ReadV00);
           if (markersField == null)
               throw new NullReferenceException("Null not allowed for 'Markers'");
           return (index, new(
               markersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, WriteTxnMarkersRequest message)
       {
           index = Encoder.WriteArray<WritableTxnMarker>(buffer, index, message.MarkersField, WritableTxnMarkerSerde.WriteV00);
           return index;
       }
       private static (int Offset, WriteTxnMarkersRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var markersField) = Decoder.ReadCompactArray<WritableTxnMarker>(buffer, index, WritableTxnMarkerSerde.ReadV01);
           if (markersField == null)
               throw new NullReferenceException("Null not allowed for 'Markers'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               markersField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, WriteTxnMarkersRequest message)
       {
           index = Encoder.WriteCompactArray<WritableTxnMarker>(buffer, index, message.MarkersField, WritableTxnMarkerSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class WritableTxnMarkerSerde
       {
           public static (int Offset, WritableTxnMarker Value) ReadV00(byte[] buffer, int index)
           {
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
               (index, var transactionResultField) = Decoder.ReadBoolean(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<WritableTxnMarkerTopic>(buffer, index, WritableTxnMarkerTopicSerde.ReadV00);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, var coordinatorEpochField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   producerIdField,
                   producerEpochField,
                   transactionResultField,
                   topicsField.Value,
                   coordinatorEpochField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, WritableTxnMarker message)
           {
               index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
               index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
               index = Encoder.WriteBoolean(buffer, index, message.TransactionResultField);
               index = Encoder.WriteArray<WritableTxnMarkerTopic>(buffer, index, message.TopicsField, WritableTxnMarkerTopicSerde.WriteV00);
               index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
               return index;
           }
           public static (int Offset, WritableTxnMarker Value) ReadV01(byte[] buffer, int index)
           {
               (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
               (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
               (index, var transactionResultField) = Decoder.ReadBoolean(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<WritableTxnMarkerTopic>(buffer, index, WritableTxnMarkerTopicSerde.ReadV01);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, var coordinatorEpochField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   producerIdField,
                   producerEpochField,
                   transactionResultField,
                   topicsField.Value,
                   coordinatorEpochField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, WritableTxnMarker message)
           {
               index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
               index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
               index = Encoder.WriteBoolean(buffer, index, message.TransactionResultField);
               index = Encoder.WriteCompactArray<WritableTxnMarkerTopic>(buffer, index, message.TopicsField, WritableTxnMarkerTopicSerde.WriteV01);
               index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class WritableTxnMarkerTopicSerde
           {
               public static (int Offset, WritableTxnMarkerTopic Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionIndexesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionIndexesField == null)
                       throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                   return (index, new(
                       nameField,
                       partitionIndexesField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerTopic message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, WritableTxnMarkerTopic Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionIndexesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionIndexesField == null)
                       throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionIndexesField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerTopic message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}