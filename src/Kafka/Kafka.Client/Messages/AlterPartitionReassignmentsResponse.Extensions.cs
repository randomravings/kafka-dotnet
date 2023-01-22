using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ReassignablePartitionResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse;
using ReassignableTopicResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterPartitionReassignmentsResponseSerde
   {
       private static readonly DecodeDelegate<AlterPartitionReassignmentsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<AlterPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, AlterPartitionReassignmentsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterPartitionReassignmentsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterPartitionReassignmentsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<ReassignableTopicResponse>(buffer, index, ReassignableTopicResponseSerde.ReadV00);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               responsesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterPartitionReassignmentsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<ReassignableTopicResponse>(buffer, index, message.ResponsesField, ReassignableTopicResponseSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ReassignableTopicResponseSerde
       {
           public static (int Offset, ReassignableTopicResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ReassignablePartitionResponse>(buffer, index, ReassignablePartitionResponseSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ReassignableTopicResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ReassignablePartitionResponse>(buffer, index, message.PartitionsField, ReassignablePartitionResponseSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class ReassignablePartitionResponseSerde
           {
               public static (int Offset, ReassignablePartitionResponse Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       errorMessageField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, ReassignablePartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}