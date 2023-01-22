using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OngoingTopicReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment;
using OngoingPartitionReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment.OngoingPartitionReassignment;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListPartitionReassignmentsResponseSerde
   {
       private static readonly DecodeDelegate<ListPartitionReassignmentsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<ListPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, ListPartitionReassignmentsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListPartitionReassignmentsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListPartitionReassignmentsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<OngoingTopicReassignment>(buffer, index, OngoingTopicReassignmentSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<OngoingTopicReassignment>(buffer, index, message.TopicsField, OngoingTopicReassignmentSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class OngoingTopicReassignmentSerde
       {
           public static (int Offset, OngoingTopicReassignment Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<OngoingPartitionReassignment>(buffer, index, OngoingPartitionReassignmentSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, OngoingTopicReassignment message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<OngoingPartitionReassignment>(buffer, index, message.PartitionsField, OngoingPartitionReassignmentSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class OngoingPartitionReassignmentSerde
           {
               public static (int Offset, OngoingPartitionReassignment Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicasField == null)
                       throw new NullReferenceException("Null not allowed for 'Replicas'");
                   (index, var addingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (addingReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                   (index, var removingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (removingReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       replicasField.Value,
                       addingReplicasField.Value,
                       removingReplicasField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OngoingPartitionReassignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}