using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TxnOffsetCommitRequestPartition = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition;
using TxnOffsetCommitRequestTopic = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class TxnOffsetCommitRequestSerde
   {
       private static readonly DecodeDelegate<TxnOffsetCommitRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<TxnOffsetCommitRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, TxnOffsetCommitRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, TxnOffsetCommitRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, TxnOffsetCommitRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           var generationIdField = default(int);
           var memberIdField = "";
           var groupInstanceIdField = default(string?);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, index, TxnOffsetCommitRequestTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               groupIdField,
               producerIdField,
               producerEpochField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, TxnOffsetCommitRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           var generationIdField = default(int);
           var memberIdField = "";
           var groupInstanceIdField = default(string?);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, index, TxnOffsetCommitRequestTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               groupIdField,
               producerIdField,
               producerEpochField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, TxnOffsetCommitRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           var generationIdField = default(int);
           var memberIdField = "";
           var groupInstanceIdField = default(string?);
           (index, var topicsField) = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, index, TxnOffsetCommitRequestTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               groupIdField,
               producerIdField,
               producerEpochField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, TxnOffsetCommitRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TxnOffsetCommitRequestTopic>(buffer, index, TxnOffsetCommitRequestTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               transactionalIdField,
               groupIdField,
               producerIdField,
               producerEpochField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteCompactArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TxnOffsetCommitRequestTopicSerde
       {
           public static (int Offset, TxnOffsetCommitRequestTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, index, TxnOffsetCommitRequestPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, TxnOffsetCommitRequestTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, index, TxnOffsetCommitRequestPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, TxnOffsetCommitRequestTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, index, TxnOffsetCommitRequestPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, TxnOffsetCommitRequestTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<TxnOffsetCommitRequestPartition>(buffer, index, TxnOffsetCommitRequestPartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class TxnOffsetCommitRequestPartitionSerde
           {
               public static (int Offset, TxnOffsetCommitRequestPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       committedMetadataField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitRequestPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   var committedLeaderEpochField = default(int);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       committedMetadataField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitRequestPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedMetadataField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       committedMetadataField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                   index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                   return index;
               }
               public static (int Offset, TxnOffsetCommitRequestPartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var committedLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var committedMetadataField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       committedOffsetField,
                       committedLeaderEpochField,
                       committedMetadataField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
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