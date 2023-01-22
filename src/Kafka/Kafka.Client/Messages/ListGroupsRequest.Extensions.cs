using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListGroupsRequestSerde
   {
       private static readonly DecodeDelegate<ListGroupsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<ListGroupsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, ListGroupsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListGroupsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListGroupsRequest Value) ReadV00(byte[] buffer, int index)
       {
           var statesFilterField = ImmutableArray<string>.Empty;
           return (index, new(
               statesFilterField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListGroupsRequest message)
       {
           return index;
       }
       private static (int Offset, ListGroupsRequest Value) ReadV01(byte[] buffer, int index)
       {
           var statesFilterField = ImmutableArray<string>.Empty;
           return (index, new(
               statesFilterField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ListGroupsRequest message)
       {
           return index;
       }
       private static (int Offset, ListGroupsRequest Value) ReadV02(byte[] buffer, int index)
       {
           var statesFilterField = ImmutableArray<string>.Empty;
           return (index, new(
               statesFilterField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ListGroupsRequest message)
       {
           return index;
       }
       private static (int Offset, ListGroupsRequest Value) ReadV03(byte[] buffer, int index)
       {
           var statesFilterField = ImmutableArray<string>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               statesFilterField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ListGroupsRequest message)
       {
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, ListGroupsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var statesFilterField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (statesFilterField == null)
               throw new NullReferenceException("Null not allowed for 'StatesFilter'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               statesFilterField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ListGroupsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.StatesFilterField, Encoder.WriteCompactString);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}