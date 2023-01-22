using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteGroupsRequestSerde
   {
       private static readonly DecodeDelegate<DeleteGroupsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<DeleteGroupsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, DeleteGroupsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteGroupsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteGroupsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupsNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsNamesField == null)
               throw new NullReferenceException("Null not allowed for 'GroupsNames'");
           return (index, new(
               groupsNamesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, DeleteGroupsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupsNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsNamesField == null)
               throw new NullReferenceException("Null not allowed for 'GroupsNames'");
           return (index, new(
               groupsNamesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, DeleteGroupsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupsNamesField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsNamesField == null)
               throw new NullReferenceException("Null not allowed for 'GroupsNames'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupsNamesField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteGroupsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}