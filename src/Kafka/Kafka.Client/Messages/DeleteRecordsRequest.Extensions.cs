using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteRecordsRequestSerde
   {
       private static readonly DecodeDelegate<DeleteRecordsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<DeleteRecordsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, DeleteRecordsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteRecordsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteRecordsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<DeleteRecordsTopic>(buffer, index, DeleteRecordsTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteRecordsRequest message)
       {
           index = Encoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV00);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteRecordsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<DeleteRecordsTopic>(buffer, index, DeleteRecordsTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteRecordsRequest message)
       {
           index = Encoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteRecordsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<DeleteRecordsTopic>(buffer, index, DeleteRecordsTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteRecordsRequest message)
       {
           index = Encoder.WriteCompactArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeleteRecordsTopicSerde
       {
           public static (int Offset, DeleteRecordsTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<DeleteRecordsPartition>(buffer, index, DeleteRecordsPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeleteRecordsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, DeleteRecordsTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<DeleteRecordsPartition>(buffer, index, DeleteRecordsPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeleteRecordsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, DeleteRecordsTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<DeleteRecordsPartition>(buffer, index, DeleteRecordsPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeleteRecordsTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DeleteRecordsPartitionSerde
           {
               public static (int Offset, DeleteRecordsPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       offsetField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DeleteRecordsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   return index;
               }
               public static (int Offset, DeleteRecordsPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       offsetField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DeleteRecordsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   return index;
               }
               public static (int Offset, DeleteRecordsPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       offsetField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DeleteRecordsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}