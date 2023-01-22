using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult.PartitionResult;
using ReplicaElectionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ElectLeadersResponseSerde
   {
       private static readonly DecodeDelegate<ElectLeadersResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<ElectLeadersResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, ElectLeadersResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ElectLeadersResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ElectLeadersResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           (index, var replicaElectionResultsField) = Decoder.ReadArray<ReplicaElectionResult>(buffer, index, ReplicaElectionResultSerde.ReadV00);
           if (replicaElectionResultsField == null)
               throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               replicaElectionResultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ElectLeadersResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, ElectLeadersResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var replicaElectionResultsField) = Decoder.ReadArray<ReplicaElectionResult>(buffer, index, ReplicaElectionResultSerde.ReadV01);
           if (replicaElectionResultsField == null)
               throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               replicaElectionResultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ElectLeadersResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, ElectLeadersResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var replicaElectionResultsField) = Decoder.ReadCompactArray<ReplicaElectionResult>(buffer, index, ReplicaElectionResultSerde.ReadV02);
           if (replicaElectionResultsField == null)
               throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               replicaElectionResultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ElectLeadersResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ReplicaElectionResultSerde
       {
           public static (int Offset, ReplicaElectionResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionResultField) = Decoder.ReadArray<PartitionResult>(buffer, index, PartitionResultSerde.ReadV00);
               if (partitionResultField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResult'");
               return (index, new(
                   topicField,
                   partitionResultField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ReplicaElectionResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, ReplicaElectionResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionResultField) = Decoder.ReadArray<PartitionResult>(buffer, index, PartitionResultSerde.ReadV01);
               if (partitionResultField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResult'");
               return (index, new(
                   topicField,
                   partitionResultField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ReplicaElectionResult message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV01);
               return index;
           }
           public static (int Offset, ReplicaElectionResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionResultField) = Decoder.ReadCompactArray<PartitionResult>(buffer, index, PartitionResultSerde.ReadV02);
               if (partitionResultField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResult'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   partitionResultField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ReplicaElectionResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionResultSerde
           {
               public static (int Offset, PartitionResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIdField,
                       errorCodeField,
                       errorMessageField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                   return index;
               }
               public static (int Offset, PartitionResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       partitionIdField,
                       errorCodeField,
                       errorMessageField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                   return index;
               }
               public static (int Offset, PartitionResult Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIdField,
                       errorCodeField,
                       errorMessageField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, PartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}