using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponse.JoinGroupResponseMember;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class JoinGroupResponseSerde
   {
       private static readonly DecodeDelegate<JoinGroupResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
           ReadV08,
           ReadV09,
       };
       private static readonly EncodeDelegate<JoinGroupResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
           WriteV08,
           WriteV09,
};
       public static (int Offset, JoinGroupResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, JoinGroupResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, JoinGroupResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV00);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV00);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV01);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV01);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV02);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV02);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV03);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV03);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV04);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV04);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadString(buffer, index);
           (index, var leaderField) = Decoder.ReadString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var membersField) = Decoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV05);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteString(buffer, index, message.LeaderField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV05);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           var protocolTypeField = default(string?);
           (index, var protocolNameField) = Decoder.ReadCompactString(buffer, index);
           (index, var leaderField) = Decoder.ReadCompactString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV06);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           if (message.ProtocolNameField == null)
               throw new ArgumentNullException(nameof(message.ProtocolNameField));
           index = Encoder.WriteCompactString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var leaderField) = Decoder.ReadCompactString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV07);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var leaderField) = Decoder.ReadCompactString(buffer, index);
           var skipAssignmentField = default(bool);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV08);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV08);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, JoinGroupResponse Value) ReadV09(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var leaderField) = Decoder.ReadCompactString(buffer, index);
           (index, var skipAssignmentField) = Decoder.ReadBoolean(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV09);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               generationIdField,
               protocolTypeField,
               protocolNameField,
               leaderField,
               skipAssignmentField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV09(byte[] buffer, int index, JoinGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
           index = Encoder.WriteBoolean(buffer, index, message.SkipAssignmentField);
           index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
           index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV09);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class JoinGroupResponseMemberSerde
       {
           public static (int Offset, JoinGroupResponseMember Value) ReadV00(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               var groupInstanceIdField = default(string?);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV01(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               var groupInstanceIdField = default(string?);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV02(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               var groupInstanceIdField = default(string?);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV03(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               var groupInstanceIdField = default(string?);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV04(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               var groupInstanceIdField = default(string?);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV05(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV06(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV07(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV08(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupResponseMember Value) ReadV09(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   metadataField
               ));
           }
           public static int WriteV09(byte[] buffer, int index, JoinGroupResponseMember message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}