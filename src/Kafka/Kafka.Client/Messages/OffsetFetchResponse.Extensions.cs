using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetFetchResponseSerde
   {
       private static readonly DecodeDelegate<OffsetFetchResponse>[] READ_VERSIONS = {
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
       private static readonly EncodeDelegate<OffsetFetchResponse>[] WRITE_VERSIONS = {
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
       public static (int Offset, OffsetFetchResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetFetchResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetFetchResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var errorCodeField = default(short);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var errorCodeField = default(short);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV02(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV02);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV03);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV04);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV05);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV06);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value,
               errorCodeField,
               groupsField
           ));
       }
       private static int WriteV07(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV07);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, OffsetFetchResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
           var errorCodeField = default(short);
           (index, var groupsField) = Decoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, index, OffsetFetchResponseGroupSerde.ReadV08);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, OffsetFetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<OffsetFetchResponseGroup>(buffer, index, message.GroupsField, OffsetFetchResponseGroupSerde.WriteV08);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetFetchResponseGroupSerde
       {
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV00(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV01(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV02(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV03(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV04(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV05(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV06(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV07(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
               var errorCodeField = default(short);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField,
                   errorCodeField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchResponseGroup Value) ReadV08(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, index, OffsetFetchResponseTopicsSerde.ReadV08);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField.Value,
                   errorCodeField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetFetchResponseGroup message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteCompactArray<OffsetFetchResponseTopics>(buffer, index, message.TopicsField, OffsetFetchResponseTopicsSerde.WriteV08);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetFetchResponseTopicsSerde
           {
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV00(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV01(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV02(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV03(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV04(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV05(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV06(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV07(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchResponseTopics Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, index, OffsetFetchResponsePartitionsSerde.ReadV08);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, OffsetFetchResponseTopics message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<OffsetFetchResponsePartitions>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionsSerde.WriteV08);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class OffsetFetchResponsePartitionsSerde
               {
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV00(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV01(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV02(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV03(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV04(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV05(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV06(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV07(byte[] buffer, int index)
                   {
                       var partitionIndexField = default(int);
                       var committedOffsetField = default(long);
                       var committedLeaderEpochField = default(int);
                       var metadataField = default(string?);
                       var errorCodeField = default(short);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, OffsetFetchResponsePartitions Value) ReadV08(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, var metadataField) = Decoder.ReadCompactNullableString(buffer, index);
                       (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           committedOffsetField,
                           committedLeaderEpochField,
                           metadataField,
                           errorCodeField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                       index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                       index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetFetchResponseTopicSerde
       {
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchResponseTopic Value) ReadV08(byte[] buffer, int index)
           {
               var nameField = "";
               var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetFetchResponseTopic message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetFetchResponsePartitionSerde
           {
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var metadataField) = Decoder.ReadNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var metadataField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var metadataField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchResponsePartition Value) ReadV08(byte[] buffer, int index)
               {
                   var partitionIndexField = default(int);
                   var committedOffsetField = default(long);
                   var committedLeaderEpochField = default(int);
                   var metadataField = default(string?);
                   var errorCodeField = default(short);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       metadataField,
                       errorCodeField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, OffsetFetchResponsePartition message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}