using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SyncGroupRequestSerde
   {
       private static readonly DecodeDelegate<SyncGroupRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<SyncGroupRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, SyncGroupRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SyncGroupRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SyncGroupRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentsField) = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV00);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV00);
           return index;
       }
       private static (int Offset, SyncGroupRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentsField) = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV01);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV01);
           return index;
       }
       private static (int Offset, SyncGroupRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentsField) = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV02);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV02);
           return index;
       }
       private static (int Offset, SyncGroupRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentsField) = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV03);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV03);
           return index;
       }
       private static (int Offset, SyncGroupRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentsField) = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV04);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, SyncGroupRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var assignmentsField) = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV05);
           if (assignmentsField == null)
               throw new NullReferenceException("Null not allowed for 'Assignments'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               generationIdField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolNameField,
               assignmentsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, SyncGroupRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class SyncGroupRequestAssignmentSerde
       {
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV00(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
               return index;
           }
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV01(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
               return index;
           }
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV02(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
               return index;
           }
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV03(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
               return index;
           }
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV04(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var assignmentField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, SyncGroupRequestAssignment Value) ReadV05(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var assignmentField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   assignmentField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, SyncGroupRequestAssignment message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}