using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribedGroupMember = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup.DescribedGroupMember;
using DescribedGroup = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeGroupsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeGroupsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<DescribeGroupsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, DescribeGroupsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeGroupsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeGroupsResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var groupsField) = Decoder.ReadArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV00);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeGroupsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV01);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeGroupsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV02);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV02);
           return index;
       }
       private static (int Offset, DescribeGroupsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV03);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV03);
           return index;
       }
       private static (int Offset, DescribeGroupsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV04);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV04);
           return index;
       }
       private static (int Offset, DescribeGroupsResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var groupsField) = Decoder.ReadCompactArray<DescribedGroup>(buffer, index, DescribedGroupSerde.ReadV05);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               groupsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, DescribeGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribedGroupSerde
       {
           public static (int Offset, DescribedGroup Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var groupStateField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadString(buffer, index);
               (index, var membersField) = Decoder.ReadArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV00);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               var authorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.GroupStateField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV00);
               return index;
           }
           public static (int Offset, DescribedGroup Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var groupStateField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadString(buffer, index);
               (index, var membersField) = Decoder.ReadArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV01);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               var authorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.GroupStateField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV01);
               return index;
           }
           public static (int Offset, DescribedGroup Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var groupStateField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadString(buffer, index);
               (index, var membersField) = Decoder.ReadArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV02);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               var authorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.GroupStateField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV02);
               return index;
           }
           public static (int Offset, DescribedGroup Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var groupStateField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadString(buffer, index);
               (index, var membersField) = Decoder.ReadArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV03);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               (index, var authorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.GroupStateField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV03);
               index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
               return index;
           }
           public static (int Offset, DescribedGroup Value) ReadV04(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var groupStateField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadString(buffer, index);
               (index, var membersField) = Decoder.ReadArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV04);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               (index, var authorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.GroupStateField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV04);
               index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
               return index;
           }
           public static (int Offset, DescribedGroup Value) ReadV05(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupStateField) = Decoder.ReadCompactString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var protocolDataField) = Decoder.ReadCompactString(buffer, index);
               (index, var membersField) = Decoder.ReadCompactArray<DescribedGroupMember>(buffer, index, DescribedGroupMemberSerde.ReadV05);
               if (membersField == null)
                   throw new NullReferenceException("Null not allowed for 'Members'");
               (index, var authorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   groupIdField,
                   groupStateField,
                   protocolTypeField,
                   protocolDataField,
                   membersField.Value,
                   authorizedOperationsField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, DescribedGroup message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteCompactString(buffer, index, message.GroupStateField);
               index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ProtocolDataField);
               index = Encoder.WriteCompactArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV05);
               index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DescribedGroupMemberSerde
           {
               public static (int Offset, DescribedGroupMember Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadString(buffer, index);
                   var groupInstanceIdField = default(string?);
                   (index, var clientIdField) = Decoder.ReadString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadBytes(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                   return index;
               }
               public static (int Offset, DescribedGroupMember Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadString(buffer, index);
                   var groupInstanceIdField = default(string?);
                   (index, var clientIdField) = Decoder.ReadString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadBytes(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                   return index;
               }
               public static (int Offset, DescribedGroupMember Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadString(buffer, index);
                   var groupInstanceIdField = default(string?);
                   (index, var clientIdField) = Decoder.ReadString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadBytes(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                   return index;
               }
               public static (int Offset, DescribedGroupMember Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadString(buffer, index);
                   var groupInstanceIdField = default(string?);
                   (index, var clientIdField) = Decoder.ReadString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadBytes(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                   return index;
               }
               public static (int Offset, DescribedGroupMember Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadString(buffer, index);
                   (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
                   (index, var clientIdField) = Decoder.ReadString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadBytes(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                   return index;
               }
               public static (int Offset, DescribedGroupMember Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
                   (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var clientIdField) = Decoder.ReadCompactString(buffer, index);
                   (index, var clientHostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var memberMetadataField) = Decoder.ReadCompactBytes(buffer, index);
                   (index, var memberAssignmentField) = Decoder.ReadCompactBytes(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       memberIdField,
                       groupInstanceIdField,
                       clientIdField,
                       clientHostField,
                       memberMetadataField,
                       memberAssignmentField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, DescribedGroupMember message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                   index = Encoder.WriteCompactString(buffer, index, message.ClientIdField);
                   index = Encoder.WriteCompactString(buffer, index, message.ClientHostField);
                   index = Encoder.WriteCompactBytes(buffer, index, message.MemberMetadataField);
                   index = Encoder.WriteCompactBytes(buffer, index, message.MemberAssignmentField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}