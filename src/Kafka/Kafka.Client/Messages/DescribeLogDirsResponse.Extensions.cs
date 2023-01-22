using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeLogDirsPartition = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition;
using DescribeLogDirsResult = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult;
using DescribeLogDirsTopic = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeLogDirsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeLogDirsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<DescribeLogDirsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, DescribeLogDirsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeLogDirsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeLogDirsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           (index, var resultsField) = Decoder.ReadArray<DescribeLogDirsResult>(buffer, index, DescribeLogDirsResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeLogDirsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           (index, var resultsField) = Decoder.ReadArray<DescribeLogDirsResult>(buffer, index, DescribeLogDirsResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeLogDirsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           (index, var resultsField) = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, index, DescribeLogDirsResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeLogDirsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, index, DescribeLogDirsResultSerde.ReadV03);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               resultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeLogDirsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<DescribeLogDirsResult>(buffer, index, DescribeLogDirsResultSerde.ReadV04);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               resultsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeLogDirsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<DescribeLogDirsResult>(buffer, index, message.ResultsField, DescribeLogDirsResultSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeLogDirsResultSerde
       {
           public static (int Offset, DescribeLogDirsResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var logDirField) = Decoder.ReadString(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, index, DescribeLogDirsTopicSerde.ReadV00);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               var totalBytesField = default(long);
               var usableBytesField = default(long);
               return (index, new(
                   errorCodeField,
                   logDirField,
                   topicsField.Value,
                   totalBytesField,
                   usableBytesField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeLogDirsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.LogDirField);
               index = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV00);
               return index;
           }
           public static (int Offset, DescribeLogDirsResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var logDirField) = Decoder.ReadString(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<DescribeLogDirsTopic>(buffer, index, DescribeLogDirsTopicSerde.ReadV01);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               var totalBytesField = default(long);
               var usableBytesField = default(long);
               return (index, new(
                   errorCodeField,
                   logDirField,
                   topicsField.Value,
                   totalBytesField,
                   usableBytesField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribeLogDirsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.LogDirField);
               index = Encoder.WriteArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV01);
               return index;
           }
           public static (int Offset, DescribeLogDirsResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var logDirField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, index, DescribeLogDirsTopicSerde.ReadV02);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               var totalBytesField = default(long);
               var usableBytesField = default(long);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   logDirField,
                   topicsField.Value,
                   totalBytesField,
                   usableBytesField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribeLogDirsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
               index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribeLogDirsResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var logDirField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, index, DescribeLogDirsTopicSerde.ReadV03);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               var totalBytesField = default(long);
               var usableBytesField = default(long);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   logDirField,
                   topicsField.Value,
                   totalBytesField,
                   usableBytesField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribeLogDirsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
               index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribeLogDirsResult Value) ReadV04(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var logDirField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<DescribeLogDirsTopic>(buffer, index, DescribeLogDirsTopicSerde.ReadV04);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, var totalBytesField) = Decoder.ReadInt64(buffer, index);
               (index, var usableBytesField) = Decoder.ReadInt64(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   logDirField,
                   topicsField.Value,
                   totalBytesField,
                   usableBytesField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DescribeLogDirsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactString(buffer, index, message.LogDirField);
               index = Encoder.WriteCompactArray<DescribeLogDirsTopic>(buffer, index, message.TopicsField, DescribeLogDirsTopicSerde.WriteV04);
               index = Encoder.WriteInt64(buffer, index, message.TotalBytesField);
               index = Encoder.WriteInt64(buffer, index, message.UsableBytesField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DescribeLogDirsTopicSerde
           {
               public static (int Offset, DescribeLogDirsTopic Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, index, DescribeLogDirsPartitionSerde.ReadV00);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DescribeLogDirsTopic message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV00);
                   return index;
               }
               public static (int Offset, DescribeLogDirsTopic Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadArray<DescribeLogDirsPartition>(buffer, index, DescribeLogDirsPartitionSerde.ReadV01);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DescribeLogDirsTopic message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV01);
                   return index;
               }
               public static (int Offset, DescribeLogDirsTopic Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, index, DescribeLogDirsPartitionSerde.ReadV02);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DescribeLogDirsTopic message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV02);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, DescribeLogDirsTopic Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, index, DescribeLogDirsPartitionSerde.ReadV03);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, DescribeLogDirsTopic message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV03);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, DescribeLogDirsTopic Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<DescribeLogDirsPartition>(buffer, index, DescribeLogDirsPartitionSerde.ReadV04);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, DescribeLogDirsTopic message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<DescribeLogDirsPartition>(buffer, index, message.PartitionsField, DescribeLogDirsPartitionSerde.WriteV04);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class DescribeLogDirsPartitionSerde
               {
                   public static (int Offset, DescribeLogDirsPartition Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var partitionSizeField) = Decoder.ReadInt64(buffer, index);
                       (index, var offsetLagField) = Decoder.ReadInt64(buffer, index);
                       (index, var isFutureKeyField) = Decoder.ReadBoolean(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           partitionSizeField,
                           offsetLagField,
                           isFutureKeyField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, DescribeLogDirsPartition message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                       index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                       index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                       return index;
                   }
                   public static (int Offset, DescribeLogDirsPartition Value) ReadV01(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var partitionSizeField) = Decoder.ReadInt64(buffer, index);
                       (index, var offsetLagField) = Decoder.ReadInt64(buffer, index);
                       (index, var isFutureKeyField) = Decoder.ReadBoolean(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           partitionSizeField,
                           offsetLagField,
                           isFutureKeyField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, DescribeLogDirsPartition message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                       index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                       index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                       return index;
                   }
                   public static (int Offset, DescribeLogDirsPartition Value) ReadV02(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var partitionSizeField) = Decoder.ReadInt64(buffer, index);
                       (index, var offsetLagField) = Decoder.ReadInt64(buffer, index);
                       (index, var isFutureKeyField) = Decoder.ReadBoolean(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           partitionSizeField,
                           offsetLagField,
                           isFutureKeyField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, DescribeLogDirsPartition message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                       index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                       index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, DescribeLogDirsPartition Value) ReadV03(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var partitionSizeField) = Decoder.ReadInt64(buffer, index);
                       (index, var offsetLagField) = Decoder.ReadInt64(buffer, index);
                       (index, var isFutureKeyField) = Decoder.ReadBoolean(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           partitionSizeField,
                           offsetLagField,
                           isFutureKeyField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, DescribeLogDirsPartition message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                       index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                       index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, DescribeLogDirsPartition Value) ReadV04(byte[] buffer, int index)
                   {
                       (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var partitionSizeField) = Decoder.ReadInt64(buffer, index);
                       (index, var offsetLagField) = Decoder.ReadInt64(buffer, index);
                       (index, var isFutureKeyField) = Decoder.ReadBoolean(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           partitionIndexField,
                           partitionSizeField,
                           offsetLagField,
                           isFutureKeyField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, DescribeLogDirsPartition message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                       index = Encoder.WriteInt64(buffer, index, message.PartitionSizeField);
                       index = Encoder.WriteInt64(buffer, index, message.OffsetLagField);
                       index = Encoder.WriteBoolean(buffer, index, message.IsFutureKeyField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}