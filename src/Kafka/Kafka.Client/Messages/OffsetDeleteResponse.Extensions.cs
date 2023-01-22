using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetDeleteResponseTopic = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic;
using OffsetDeleteResponsePartition = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetDeleteResponseSerde
   {
       private static readonly DecodeDelegate<OffsetDeleteResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<OffsetDeleteResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, OffsetDeleteResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetDeleteResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetDeleteResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetDeleteResponseTopic>(buffer, index, OffsetDeleteResponseTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               errorCodeField,
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetDeleteResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<OffsetDeleteResponseTopic>(buffer, index, message.TopicsField, OffsetDeleteResponseTopicSerde.WriteV00);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetDeleteResponseTopicSerde
       {
           public static (int Offset, OffsetDeleteResponseTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetDeleteResponsePartition>(buffer, index, OffsetDeleteResponsePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetDeleteResponseTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetDeleteResponsePartition>(buffer, index, message.PartitionsField, OffsetDeleteResponsePartitionSerde.WriteV00);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetDeleteResponsePartitionSerde
           {
               public static (int Offset, OffsetDeleteResponsePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetDeleteResponsePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
           }
       }
   }
}