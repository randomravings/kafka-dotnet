using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteRecordsResponseSerde
   {
       private static readonly DecodeDelegate<DeleteRecordsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<DeleteRecordsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, DeleteRecordsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteRecordsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteRecordsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteRecordsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DeleteRecordsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteRecordsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DeleteRecordsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteRecordsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeleteRecordsTopicResultSerde
       {
           public static (int Offset, DeleteRecordsTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeleteRecordsTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, DeleteRecordsTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeleteRecordsTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV01);
               return index;
           }
           public static (int Offset, DeleteRecordsTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeleteRecordsTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DeleteRecordsPartitionResultSerde
           {
               public static (int Offset, DeleteRecordsPartitionResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var lowWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       lowWatermarkField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DeleteRecordsPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.LowWatermarkField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, DeleteRecordsPartitionResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var lowWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       lowWatermarkField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DeleteRecordsPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.LowWatermarkField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, DeleteRecordsPartitionResult Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var lowWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       lowWatermarkField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DeleteRecordsPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.LowWatermarkField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}