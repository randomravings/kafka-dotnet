using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatePartitionsAssignment = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment;
using CreatePartitionsTopic = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreatePartitionsRequestSerde
   {
       private static readonly DecodeDelegate<CreatePartitionsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreatePartitionsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreatePartitionsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreatePartitionsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreatePartitionsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatePartitionsTopic>(buffer, index, CreatePartitionsTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField,
               validateOnlyField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreatePartitionsRequest message)
       {
           index = Encoder.WriteArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV00);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreatePartitionsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatePartitionsTopic>(buffer, index, CreatePartitionsTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField,
               validateOnlyField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreatePartitionsRequest message)
       {
           index = Encoder.WriteArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreatePartitionsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, index, CreatePartitionsTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField,
               validateOnlyField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreatePartitionsRequest message)
       {
           index = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreatePartitionsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, index, CreatePartitionsTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               timeoutMsField,
               validateOnlyField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreatePartitionsRequest message)
       {
           index = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV03);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CreatePartitionsTopicSerde
       {
           public static (int Offset, CreatePartitionsTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var countField) = Decoder.ReadInt32(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, index, CreatePartitionsAssignmentSerde.ReadV00);
               return (index, new(
                   nameField,
                   countField,
                   assignmentsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, CreatePartitionsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.CountField);
               index = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV00);
               return index;
           }
           public static (int Offset, CreatePartitionsTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var countField) = Decoder.ReadInt32(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, index, CreatePartitionsAssignmentSerde.ReadV01);
               return (index, new(
                   nameField,
                   countField,
                   assignmentsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, CreatePartitionsTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.CountField);
               index = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV01);
               return index;
           }
           public static (int Offset, CreatePartitionsTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var countField) = Decoder.ReadInt32(buffer, index);
               (index, var assignmentsField) = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, index, CreatePartitionsAssignmentSerde.ReadV02);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   countField,
                   assignmentsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, CreatePartitionsTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.CountField);
               index = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatePartitionsTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var countField) = Decoder.ReadInt32(buffer, index);
               (index, var assignmentsField) = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, index, CreatePartitionsAssignmentSerde.ReadV03);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   countField,
                   assignmentsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, CreatePartitionsTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.CountField);
               index = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class CreatePartitionsAssignmentSerde
           {
               public static (int Offset, CreatePartitionsAssignment Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, CreatePartitionsAssignment message)
               {
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatePartitionsAssignment Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, CreatePartitionsAssignment message)
               {
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatePartitionsAssignment Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var brokerIdsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, CreatePartitionsAssignment message)
               {
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreatePartitionsAssignment Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var brokerIdsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, CreatePartitionsAssignment message)
               {
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}