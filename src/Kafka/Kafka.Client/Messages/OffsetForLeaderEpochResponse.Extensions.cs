using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EpochEndOffset = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult.EpochEndOffset;
using OffsetForLeaderTopicResult = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetForLeaderEpochResponseSerde
   {
       private static readonly DecodeDelegate<OffsetForLeaderEpochResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<OffsetForLeaderEpochResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, OffsetForLeaderEpochResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetForLeaderEpochResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetForLeaderEpochResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, index, OffsetForLeaderTopicResultSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
       {
           index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, index, OffsetForLeaderTopicResultSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
       {
           index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, index, OffsetForLeaderTopicResultSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV02);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopicResult>(buffer, index, OffsetForLeaderTopicResultSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV03);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetForLeaderTopicResult>(buffer, index, OffsetForLeaderTopicResultSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetForLeaderEpochResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<OffsetForLeaderTopicResult>(buffer, index, message.TopicsField, OffsetForLeaderTopicResultSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetForLeaderTopicResultSerde
       {
           public static (int Offset, OffsetForLeaderTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<EpochEndOffset>(buffer, index, EpochEndOffsetSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetForLeaderTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV00);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<EpochEndOffset>(buffer, index, EpochEndOffsetSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetForLeaderTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV01);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<EpochEndOffset>(buffer, index, EpochEndOffsetSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetForLeaderTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV02);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopicResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<EpochEndOffset>(buffer, index, EpochEndOffsetSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetForLeaderTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV03);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopicResult Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<EpochEndOffset>(buffer, index, EpochEndOffsetSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetForLeaderTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<EpochEndOffset>(buffer, index, message.PartitionsField, EpochEndOffsetSerde.WriteV04);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class EpochEndOffsetSerde
           {
               public static (int Offset, EpochEndOffset Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionField,
                       leaderEpochField,
                       endOffsetField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, EpochEndOffset message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                   return index;
               }
               public static (int Offset, EpochEndOffset Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionField,
                       leaderEpochField,
                       endOffsetField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, EpochEndOffset message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                   return index;
               }
               public static (int Offset, EpochEndOffset Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionField,
                       leaderEpochField,
                       endOffsetField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, EpochEndOffset message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                   return index;
               }
               public static (int Offset, EpochEndOffset Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionField,
                       leaderEpochField,
                       endOffsetField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, EpochEndOffset message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                   return index;
               }
               public static (int Offset, EpochEndOffset Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionField,
                       leaderEpochField,
                       endOffsetField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, EpochEndOffset message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}