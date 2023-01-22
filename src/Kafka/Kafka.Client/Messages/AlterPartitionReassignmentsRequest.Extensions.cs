using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ReassignableTopic = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic;
using ReassignablePartition = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterPartitionReassignmentsRequestSerde
   {
       private static readonly DecodeDelegate<AlterPartitionReassignmentsRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<AlterPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, AlterPartitionReassignmentsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterPartitionReassignmentsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterPartitionReassignmentsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ReassignableTopic>(buffer, index, ReassignableTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               timeoutMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterPartitionReassignmentsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteCompactArray<ReassignableTopic>(buffer, index, message.TopicsField, ReassignableTopicSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ReassignableTopicSerde
       {
           public static (int Offset, ReassignableTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ReassignablePartition>(buffer, index, ReassignablePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ReassignableTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ReassignablePartition>(buffer, index, message.PartitionsField, ReassignablePartitionSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class ReassignablePartitionSerde
           {
               public static (int Offset, ReassignablePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       replicasField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, ReassignablePartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}