using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetDeleteRequestTopic = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic;
using OffsetDeleteRequestPartition = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic.OffsetDeleteRequestPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class OffsetDeleteRequestSerde
   {
       private static readonly DecodeDelegate<OffsetDeleteRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<OffsetDeleteRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, OffsetDeleteRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, OffsetDeleteRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, OffsetDeleteRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<OffsetDeleteRequestTopic>(buffer, index, OffsetDeleteRequestTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               groupIdField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, OffsetDeleteRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<OffsetDeleteRequestTopic>(buffer, index, message.TopicsField, OffsetDeleteRequestTopicSerde.WriteV00);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OffsetDeleteRequestTopicSerde
       {
           public static (int Offset, OffsetDeleteRequestTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<OffsetDeleteRequestPartition>(buffer, index, OffsetDeleteRequestPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OffsetDeleteRequestTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<OffsetDeleteRequestPartition>(buffer, index, message.PartitionsField, OffsetDeleteRequestPartitionSerde.WriteV00);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OffsetDeleteRequestPartitionSerde
           {
               public static (int Offset, OffsetDeleteRequestPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionIndexField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OffsetDeleteRequestPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   return index;
               }
           }
       }
   }
}