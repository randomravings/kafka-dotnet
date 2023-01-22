using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListGroupsResponseSerde
   {
       private static readonly DecodeDelegate<ListGroupsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<ListGroupsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, ListGroupsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListGroupsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListGroupsResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV00);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListGroupsResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV00);
           return index;
       }
       private static (int Offset, ListGroupsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV01);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ListGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV01);
           return index;
       }
       private static (int Offset, ListGroupsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var groupsField) = Decoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV02);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ListGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV02);
           return index;
       }
       private static (int Offset, ListGroupsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var groupsField) = Decoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV03);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ListGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, ListGroupsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var groupsField) = Decoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV04);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               groupsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ListGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ListedGroupSerde
       {
           public static (int Offset, ListedGroup Value) ReadV00(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               var groupStateField = "";
               return (index, new(
                   groupIdField,
                   protocolTypeField,
                   groupStateField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ListedGroup message)
           {
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               return index;
           }
           public static (int Offset, ListedGroup Value) ReadV01(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               var groupStateField = "";
               return (index, new(
                   groupIdField,
                   protocolTypeField,
                   groupStateField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ListedGroup message)
           {
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               return index;
           }
           public static (int Offset, ListedGroup Value) ReadV02(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
               var groupStateField = "";
               return (index, new(
                   groupIdField,
                   protocolTypeField,
                   groupStateField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ListedGroup message)
           {
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
               return index;
           }
           public static (int Offset, ListedGroup Value) ReadV03(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
               var groupStateField = "";
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   protocolTypeField,
                   groupStateField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, ListedGroup message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, ListedGroup Value) ReadV04(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var groupStateField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   protocolTypeField,
                   groupStateField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, ListedGroup message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.GroupStateField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}