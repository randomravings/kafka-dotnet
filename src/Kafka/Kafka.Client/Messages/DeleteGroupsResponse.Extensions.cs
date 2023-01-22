using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponse.DeletableGroupResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteGroupsResponseSerde
   {
       private static readonly DecodeDelegate<DeleteGroupsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<DeleteGroupsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, DeleteGroupsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteGroupsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteGroupsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DeletableGroupResult>(buffer, index, DeletableGroupResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DeleteGroupsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DeletableGroupResult>(buffer, index, DeletableGroupResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DeleteGroupsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<DeletableGroupResult>(buffer, index, DeletableGroupResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteGroupsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeletableGroupResultSerde
       {
           public static (int Offset, DeletableGroupResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   groupIdField,
                   errorCodeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeletableGroupResult message)
           {
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableGroupResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   groupIdField,
                   errorCodeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeletableGroupResult message)
           {
               index = Encoder.WriteString(buffer, index, message.GroupIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableGroupResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   groupIdField,
                   errorCodeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeletableGroupResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}