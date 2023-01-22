using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetForLeaderPartition = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic.OffsetForLeaderPartition;
using OffsetForLeaderTopic = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetForLeaderEpochRequestSerde
   {
       private static readonly DecodeDelegate<OffsetForLeaderEpochRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<OffsetForLeaderEpochRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, OffsetForLeaderEpochRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetForLeaderEpochRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetForLeaderEpochRequest Value) ReadV00(byte[] buffer, int index)
       {
           var replicaIdField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, index, OffsetForLeaderTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
       {
           index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochRequest Value) ReadV01(byte[] buffer, int index)
       {
           var replicaIdField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, index, OffsetForLeaderTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
       {
           index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochRequest Value) ReadV02(byte[] buffer, int index)
       {
           var replicaIdField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, index, OffsetForLeaderTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
       {
           index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, index, OffsetForLeaderTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, OffsetForLeaderEpochRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetForLeaderTopic>(buffer, index, OffsetForLeaderTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               replicaIdField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteCompactArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetForLeaderTopicSerde
       {
           public static (int Offset, OffsetForLeaderTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, index, OffsetForLeaderPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetForLeaderTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, index, OffsetForLeaderPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetForLeaderTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, index, OffsetForLeaderPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetForLeaderTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, index, OffsetForLeaderPartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetForLeaderTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, OffsetForLeaderTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OffsetForLeaderPartition>(buffer, index, OffsetForLeaderPartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetForLeaderTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV04);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetForLeaderPartitionSerde
           {
               public static (int Offset, OffsetForLeaderPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       leaderEpochField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetForLeaderPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, OffsetForLeaderPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       leaderEpochField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetForLeaderPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, OffsetForLeaderPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       leaderEpochField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetForLeaderPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, OffsetForLeaderPartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       leaderEpochField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetForLeaderPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, OffsetForLeaderPartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       leaderEpochField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetForLeaderPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}