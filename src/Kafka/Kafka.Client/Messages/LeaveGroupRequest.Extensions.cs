using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberIdentity = Kafka.Client.Messages.LeaveGroupRequest.MemberIdentity;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class LeaveGroupRequestSerde
   {
       private static readonly DecodeDelegate<LeaveGroupRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<LeaveGroupRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, LeaveGroupRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, LeaveGroupRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, LeaveGroupRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var membersField = ImmutableArray<MemberIdentity>.Empty;
           return (index, new(
               groupIdField,
               memberIdField,
               membersField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           return index;
       }
       private static (int Offset, LeaveGroupRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var membersField = ImmutableArray<MemberIdentity>.Empty;
           return (index, new(
               groupIdField,
               memberIdField,
               membersField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           return index;
       }
       private static (int Offset, LeaveGroupRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var membersField = ImmutableArray<MemberIdentity>.Empty;
           return (index, new(
               groupIdField,
               memberIdField,
               membersField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteString(buffer, index, message.MemberIdField);
           return index;
       }
       private static (int Offset, LeaveGroupRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           var memberIdField = "";
           (index, var membersField) = Decoder.ReadArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV03);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               groupIdField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.GroupIdField);
           index = Encoder.WriteArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV03);
           return index;
       }
       private static (int Offset, LeaveGroupRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           var memberIdField = "";
           (index, var membersField) = Decoder.ReadCompactArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV04);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaveGroupRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           var memberIdField = "";
           (index, var membersField) = Decoder.ReadCompactArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV05);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               memberIdField,
               membersField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, LeaveGroupRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
           index = Encoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class MemberIdentitySerde
       {
           public static (int Offset, MemberIdentity Value) ReadV00(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var reasonField = default(string?);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, MemberIdentity message)
           {
               return index;
           }
           public static (int Offset, MemberIdentity Value) ReadV01(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var reasonField = default(string?);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, MemberIdentity message)
           {
               return index;
           }
           public static (int Offset, MemberIdentity Value) ReadV02(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var reasonField = default(string?);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, MemberIdentity message)
           {
               return index;
           }
           public static (int Offset, MemberIdentity Value) ReadV03(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
               var reasonField = default(string?);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, MemberIdentity message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
               return index;
           }
           public static (int Offset, MemberIdentity Value) ReadV04(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               var reasonField = default(string?);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, MemberIdentity message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MemberIdentity Value) ReadV05(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var reasonField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   reasonField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, MemberIdentity message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ReasonField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}