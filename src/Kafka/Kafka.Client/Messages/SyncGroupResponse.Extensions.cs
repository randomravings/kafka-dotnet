using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SyncGroupResponseSerde
   {
       private static readonly DecodeDelegate<SyncGroupResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<SyncGroupResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, SyncGroupResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SyncGroupResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SyncGroupResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
           return index;
       }
       private static (int Offset, SyncGroupResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
           return index;
       }
       private static (int Offset, SyncGroupResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
           return index;
       }
       private static (int Offset, SyncGroupResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
           return index;
       }
       private static (int Offset, SyncGroupResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var protocolTypeField = default(string?);
           var protocolNameField = default(string?);
           (index, var assignmentField) = Decoder.ReadCompactBytes(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, SyncGroupResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var assignmentField) = Decoder.ReadCompactBytes(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               protocolTypeField,
               protocolNameField,
               assignmentField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, SyncGroupResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
           index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}