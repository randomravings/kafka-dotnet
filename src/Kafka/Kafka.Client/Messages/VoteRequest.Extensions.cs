using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.VoteRequest.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.VoteRequest.TopicData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class VoteRequestSerde
   {
       private static readonly DecodeDelegate<VoteRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<VoteRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, VoteRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, VoteRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, VoteRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var clusterIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               clusterIdField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, VoteRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicDataSerde
       {
           public static (int Offset, TopicData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionDataSerde
           {
               public static (int Offset, PartitionData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var candidateEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var candidateIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var lastOffsetEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var lastOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       candidateEpochField,
                       candidateIdField,
                       lastOffsetEpochField,
                       lastOffsetField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.CandidateEpochField);
                   index = Encoder.WriteInt32(buffer, index, message.CandidateIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LastOffsetEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.LastOffsetField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}