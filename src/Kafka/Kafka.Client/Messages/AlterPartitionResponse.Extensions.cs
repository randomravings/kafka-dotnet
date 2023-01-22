using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.AlterPartitionResponse.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.AlterPartitionResponse.TopicData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterPartitionResponseSerde
   {
       private static readonly DecodeDelegate<AlterPartitionResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<AlterPartitionResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, AlterPartitionResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterPartitionResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterPartitionResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterPartitionResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, AlterPartitionResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterPartitionResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, AlterPartitionResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AlterPartitionResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicDataSerde
       {
           public static (int Offset, TopicData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, TopicData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, TopicData Value) ReadV02(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionDataSerde
           {
               public static (int Offset, PartitionData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrField == null)
                       throw new NullReferenceException("Null not allowed for 'Isr'");
                   var leaderRecoveryStateField = default(sbyte);
                   (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       leaderIdField,
                       leaderEpochField,
                       isrField.Value,
                       leaderRecoveryStateField,
                       partitionEpochField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrField == null)
                       throw new NullReferenceException("Null not allowed for 'Isr'");
                   (index, var leaderRecoveryStateField) = Decoder.ReadInt8(buffer, index);
                   (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       leaderIdField,
                       leaderEpochField,
                       isrField.Value,
                       leaderRecoveryStateField,
                       partitionEpochField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                   index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrField == null)
                       throw new NullReferenceException("Null not allowed for 'Isr'");
                   (index, var leaderRecoveryStateField) = Decoder.ReadInt8(buffer, index);
                   (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       leaderIdField,
                       leaderEpochField,
                       isrField.Value,
                       leaderRecoveryStateField,
                       partitionEpochField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
                   index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}