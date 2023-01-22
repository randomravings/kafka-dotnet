using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TxnOffsetCommitResponseTopic = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic;
using TxnOffsetCommitResponsePartition = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic.TxnOffsetCommitResponsePartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class TxnOffsetCommitResponseSerde
   {
       private static readonly DecodeDelegate<TxnOffsetCommitResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<TxnOffsetCommitResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, TxnOffsetCommitResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, TxnOffsetCommitResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, TxnOffsetCommitResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, index, TxnOffsetCommitResponseTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, TxnOffsetCommitResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, index, TxnOffsetCommitResponseTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, TxnOffsetCommitResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, index, TxnOffsetCommitResponseTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, TxnOffsetCommitResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TxnOffsetCommitResponseTopic>(buffer, index, TxnOffsetCommitResponseTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TxnOffsetCommitResponseTopicSerde
       {
           public static (int Offset, TxnOffsetCommitResponseTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, index, TxnOffsetCommitResponsePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, TxnOffsetCommitResponseTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, index, TxnOffsetCommitResponsePartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, TxnOffsetCommitResponseTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, index, TxnOffsetCommitResponsePartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, TxnOffsetCommitResponseTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<TxnOffsetCommitResponsePartition>(buffer, index, TxnOffsetCommitResponsePartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class TxnOffsetCommitResponsePartitionSerde
           {
               public static (int Offset, TxnOffsetCommitResponsePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitResponsePartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitResponsePartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitResponsePartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
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