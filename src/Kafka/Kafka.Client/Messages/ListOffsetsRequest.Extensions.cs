using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListOffsetsRequestSerde
   {
       private static readonly DecodeDelegate<ListOffsetsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<ListOffsetsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, ListOffsetsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListOffsetsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListOffsetsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           var isolationLevelField = default(sbyte);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           var isolationLevelField = default(sbyte);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, ListOffsetsRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               replicaIdField,
               isolationLevelField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, ListOffsetsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ListOffsetsTopicSerde
       {
           public static (int Offset, ListOffsetsTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, ListOffsetsTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, ListOffsetsTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class ListOffsetsPartitionSerde
           {
               public static (int Offset, ListOffsetsPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var maxNumOffsetsField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt32(buffer, index, message.MaxNumOffsetsField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, ListOffsetsPartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   var maxNumOffsetsField = default(int);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       currentLeaderEpochField,
                       timestampField,
                       maxNumOffsetsField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, ListOffsetsPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}