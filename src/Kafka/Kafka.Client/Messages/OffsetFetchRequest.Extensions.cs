using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetFetchRequestSerde
   {
       private static readonly DecodeDelegate<OffsetFetchRequest>[] READ_VERSIONS = {
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
       private static readonly EncodeDelegate<OffsetFetchRequest>[] WRITE_VERSIONS = {
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
       public static (int Offset, OffsetFetchRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetFetchRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetFetchRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           if (message.TopicsField == null)
               throw new ArgumentNullException(nameof(message.TopicsField));
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           if (message.TopicsField == null)
               throw new ArgumentNullException(nameof(message.TopicsField));
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV02);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV03);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV04);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV05);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV06);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           var requireStableField = default(bool);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV07);
           var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
           (index, var requireStableField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField,
               requireStableField
           ));
       }
       private static int WriteV07(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV07);
           index = Encoder.WriteBoolean(buffer, index, message.RequireStableField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, OffsetFetchRequest Value) ReadV08(byte[] buffer, int index)
       {
           var groupIdField = "";
           var topicsField = ImmutableArray<OffsetFetchRequestTopic>.Empty;
           (index, var groupsField) = Decoder.ReadCompactArray<OffsetFetchRequestGroup>(buffer, index, OffsetFetchRequestGroupSerde.ReadV08);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, var requireStableField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               topicsField,
               groupsField.Value,
               requireStableField
           ));
       }
       private static int WriteV08(byte[] buffer, int index, OffsetFetchRequest message)
       {
           index = Encoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, index, message.GroupsField, OffsetFetchRequestGroupSerde.WriteV08);
           index = Encoder.WriteBoolean(buffer, index, message.RequireStableField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetFetchRequestTopicSerde
       {
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV00(byte[] buffer, int index)
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
           public static int WriteV00(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV01(byte[] buffer, int index)
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
           public static int WriteV01(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV02(byte[] buffer, int index)
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
           public static int WriteV02(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV03(byte[] buffer, int index)
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
           public static int WriteV03(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV04(byte[] buffer, int index)
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
           public static int WriteV04(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV05(byte[] buffer, int index)
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
           public static int WriteV05(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV06(byte[] buffer, int index)
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
           public static int WriteV06(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV07(byte[] buffer, int index)
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
           public static int WriteV07(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchRequestTopic Value) ReadV08(byte[] buffer, int index)
           {
               var nameField = "";
               var partitionIndexesField = ImmutableArray<int>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionIndexesField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetFetchRequestTopic message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetFetchRequestGroupSerde
       {
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV00(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV01(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV02(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV03(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV04(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV05(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV06(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV07(byte[] buffer, int index)
           {
               var groupIdField = "";
               var topicsField = ImmutableArray<OffsetFetchRequestTopics>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, OffsetFetchRequestGroup Value) ReadV08(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<OffsetFetchRequestTopics>(buffer, index, OffsetFetchRequestTopicsSerde.ReadV08);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   topicsField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetFetchRequestGroup message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, index, message.TopicsField, OffsetFetchRequestTopicsSerde.WriteV08);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetFetchRequestTopicsSerde
           {
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV00(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV01(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV02(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV03(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV04(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV05(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV06(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV07(byte[] buffer, int index)
               {
                   var nameField = "";
                   var partitionIndexesField = ImmutableArray<int>.Empty;
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionIndexesField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, OffsetFetchRequestTopics message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, OffsetFetchRequestTopics Value) ReadV08(byte[] buffer, int index)
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
               public static int WriteV08(byte[] buffer, int index, OffsetFetchRequestTopics message)
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