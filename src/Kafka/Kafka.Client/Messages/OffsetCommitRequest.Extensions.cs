using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetCommitRequestSerde
   {
       private static readonly DecodeDelegate<OffsetCommitRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
           ReadV08,
       };
       private static readonly EncodeDelegate<OffsetCommitRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
           WriteV08,
};
       public static (int Offset, OffsetCommitRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetCommitRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetCommitRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           var generationIdField = default(int);
           var memberIdField = "";
           var groupInstanceIdField = default(string?);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var retentionTimeMsField) = Decoder.ReadInt64(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var retentionTimeMsField) = Decoder.ReadInt64(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var retentionTimeMsField) = Decoder.ReadInt64(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV06);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV07);
           return index;
       }
       private static (int Offset, OffsetCommitRequest Value) ReadV08(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           var retentionTimeMsField = default(long);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV08);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               retentionTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, OffsetCommitRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV08);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetCommitRequestTopicSerde
       {
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV06);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV07);
               return index;
           }
           public static (int Offset, OffsetCommitRequestTopic Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV08);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetCommitRequestTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV08);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetCommitRequestPartitionSerde
           {
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var commitTimestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.CommitTimestampField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, OffsetCommitRequestPartition Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   var commitTimestampField = default(long);
                   (index, var committedMetadataField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       commitTimestampField,
                       committedMetadataField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, OffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}