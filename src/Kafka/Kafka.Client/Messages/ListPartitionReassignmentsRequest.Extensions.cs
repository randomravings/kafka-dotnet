using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListPartitionReassignmentsTopics = Kafka.Client.Messages.ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListPartitionReassignmentsRequestSerde
   {
       private static readonly DecodeDelegate<ListPartitionReassignmentsRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<ListPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, ListPartitionReassignmentsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListPartitionReassignmentsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListPartitionReassignmentsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ListPartitionReassignmentsTopics>(buffer, index, ListPartitionReassignmentsTopicsSerde.ReadV00);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               timeoutMsField,
               topicsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteCompactArray<ListPartitionReassignmentsTopics>(buffer, index, message.TopicsField, ListPartitionReassignmentsTopicsSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ListPartitionReassignmentsTopicsSerde
       {
           public static (int Offset, ListPartitionReassignmentsTopics Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionIndexesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionIndexesField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsTopics message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}