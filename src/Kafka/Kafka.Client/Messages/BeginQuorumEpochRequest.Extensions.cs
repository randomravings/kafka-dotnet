using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class BeginQuorumEpochRequestSerde
   {
       private static readonly DecodeDelegate<BeginQuorumEpochRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<BeginQuorumEpochRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, BeginQuorumEpochRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, BeginQuorumEpochRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, BeginQuorumEpochRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<TopicData>(buffer, index, TopicDataSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               clusterIdField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, BeginQuorumEpochRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicDataSerde
       {
           public static (int Offset, TopicData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionDataSerde
           {
               public static (int Offset, PartitionData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
           }
       }
   }
}