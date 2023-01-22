using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeGroupsRequestSerde
   {
       private static readonly DecodeDelegate<DescribeGroupsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
       };
       private static readonly EncodeDelegate<DescribeGroupsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
};
       public static (int Offset, DescribeGroupsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeGroupsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeGroupsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           var includeAuthorizedOperationsField = default(bool);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, DescribeGroupsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           var includeAuthorizedOperationsField = default(bool);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, DescribeGroupsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           var includeAuthorizedOperationsField = default(bool);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, DescribeGroupsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, var includeAuthorizedOperationsField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeAuthorizedOperationsField);
           return index;
       }
       private static (int Offset, DescribeGroupsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, var includeAuthorizedOperationsField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeAuthorizedOperationsField);
           return index;
       }
       private static (int Offset, DescribeGroupsRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupsField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (groupsField == null)
               throw new NullReferenceException("Null not allowed for 'Groups'");
           (index, var includeAuthorizedOperationsField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupsField.Value,
               includeAuthorizedOperationsField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, DescribeGroupsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.GroupsField, Encoder.WriteCompactString);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeAuthorizedOperationsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}