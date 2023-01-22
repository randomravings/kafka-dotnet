using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateTopicsRequestSerde
   {
       private static readonly DecodeDelegate<CreateTopicsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<CreateTopicsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, CreateTopicsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateTopicsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateTopicsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           var validateOnlyField = default(bool);
           return (index, new(
               topicsField.Value,
               timeoutMsField,
               validateOnlyField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV00);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV01);
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
       private static int WriteV01(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV02);
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
       private static int WriteV02(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV03);
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
       private static int WriteV03(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV03);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV04);
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
       private static int WriteV04(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV04);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV05);
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
       private static int WriteV05(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV05);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV06);
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
       private static int WriteV06(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV06);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateTopicsRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV07);
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
       private static int WriteV07(byte[] buffer, int index, CreateTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV07);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CreatableTopicSerde
       {
           public static (int Offset, CreatableTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV00);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV00);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV00);
               index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV00);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV01);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV01);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV01);
               index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV01);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV02);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV02);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV02);
               index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV02);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV03);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV03);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV03);
               index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV03);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV04);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV04);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV04);
               index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV04);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV05);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV05);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV05);
               index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV05);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV06);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV06);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV06);
               index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatableTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var assignmentsField) = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV07);
               if (assignmentsField == null)
                   throw new NullReferenceException("Null not allowed for 'Assignments'");
               (index, var configsField) = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV07);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   numPartitionsField,
                   replicationFactorField,
                   assignmentsField.Value,
                   configsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, CreatableTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV07);
               index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class CreateableTopicConfigSerde
           {
               public static (int Offset, CreateableTopicConfig Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreateableTopicConfig Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, CreateableTopicConfig message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class CreatableReplicaAssignmentSerde
           {
               public static (int Offset, CreatableReplicaAssignment Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreatableReplicaAssignment Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var brokerIdsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (brokerIdsField == null)
                       throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       brokerIdsField.Value
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, CreatableReplicaAssignment message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}