using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class LeaveGroupResponseSerde
   {
       private static readonly DecodeDelegate<LeaveGroupResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<LeaveGroupResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, LeaveGroupResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, LeaveGroupResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, LeaveGroupResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var membersField = ImmutableArray<MemberResponse>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, LeaveGroupResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var membersField = ImmutableArray<MemberResponse>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, LeaveGroupResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var membersField = ImmutableArray<MemberResponse>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           return index;
       }
       private static (int Offset, LeaveGroupResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var membersField) = Decoder.ReadArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV03);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV03);
           return index;
       }
       private static (int Offset, LeaveGroupResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV04);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaveGroupResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var membersField) = Decoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV05);
           if (membersField == null)
               throw new NullReferenceException("Null not allowed for 'Members'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               membersField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, LeaveGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class MemberResponseSerde
       {
           public static (int Offset, MemberResponse Value) ReadV00(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var errorCodeField = default(short);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, MemberResponse message)
           {
               return index;
           }
           public static (int Offset, MemberResponse Value) ReadV01(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var errorCodeField = default(short);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, MemberResponse message)
           {
               return index;
           }
           public static (int Offset, MemberResponse Value) ReadV02(byte[] buffer, int index)
           {
               var memberIdField = "";
               var groupInstanceIdField = default(string?);
               var errorCodeField = default(short);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, MemberResponse message)
           {
               return index;
           }
           public static (int Offset, MemberResponse Value) ReadV03(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, MemberResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.MemberIdField);
               index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, MemberResponse Value) ReadV04(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, MemberResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MemberResponse Value) ReadV05(byte[] buffer, int index)
           {
               (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   memberIdField,
                   groupInstanceIdField,
                   errorCodeField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, MemberResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}