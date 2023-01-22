using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterReplicaLogDirTopicResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult;
using AlterReplicaLogDirPartitionResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterReplicaLogDirsResponseSerde
   {
       private static readonly DecodeDelegate<AlterReplicaLogDirsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<AlterReplicaLogDirsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, AlterReplicaLogDirsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterReplicaLogDirsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterReplicaLogDirsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, index, AlterReplicaLogDirTopicResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, AlterReplicaLogDirsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, index, AlterReplicaLogDirTopicResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, AlterReplicaLogDirsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<AlterReplicaLogDirTopicResult>(buffer, index, AlterReplicaLogDirTopicResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AlterReplicaLogDirTopicResultSerde
       {
           public static (int Offset, AlterReplicaLogDirTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, index, AlterReplicaLogDirPartitionResultSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, AlterReplicaLogDirTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, index, AlterReplicaLogDirPartitionResultSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV01);
               return index;
           }
           public static (int Offset, AlterReplicaLogDirTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<AlterReplicaLogDirPartitionResult>(buffer, index, AlterReplicaLogDirPartitionResultSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class AlterReplicaLogDirPartitionResultSerde
           {
               public static (int Offset, AlterReplicaLogDirPartitionResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, AlterReplicaLogDirPartitionResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, AlterReplicaLogDirPartitionResult Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
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