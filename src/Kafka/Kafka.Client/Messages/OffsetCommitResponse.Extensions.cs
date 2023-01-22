using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetCommitResponseTopic = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic;
using OffsetCommitResponsePartition = Kafka.Client.Messages.OffsetCommitResponse.OffsetCommitResponseTopic.OffsetCommitResponsePartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetCommitResponseSerde
   {
       private static readonly DecodeDelegate<OffsetCommitResponse>[] READ_VERSIONS = {
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
       private static readonly EncodeDelegate<OffsetCommitResponse>[] WRITE_VERSIONS = {
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
       public static (int Offset, OffsetCommitResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetCommitResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetCommitResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV02(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV06);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV07);
           return index;
       }
       private static (int Offset, OffsetCommitResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OffsetCommitResponseTopic>(buffer, index, OffsetCommitResponseTopicSerde.ReadV08);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, OffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<OffsetCommitResponseTopic>(buffer, index, message.TopicsField, OffsetCommitResponseTopicSerde.WriteV08);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetCommitResponseTopicSerde
       {
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV06);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV07);
               return index;
           }
           public static (int Offset, OffsetCommitResponseTopic Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OffsetCommitResponsePartition>(buffer, index, OffsetCommitResponsePartitionSerde.ReadV08);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, OffsetCommitResponseTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<OffsetCommitResponsePartition>(buffer, index, message.PartitionsField, OffsetCommitResponsePartitionSerde.WriteV08);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetCommitResponsePartitionSerde
           {
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, OffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, OffsetCommitResponsePartition Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, OffsetCommitResponsePartition message)
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