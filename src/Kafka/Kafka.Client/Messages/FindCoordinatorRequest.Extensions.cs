using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FindCoordinatorRequestSerde
   {
       private static readonly DecodeDelegate<FindCoordinatorRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<FindCoordinatorRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, FindCoordinatorRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FindCoordinatorRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FindCoordinatorRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var keyField) = Decoder.ReadString(buffer, index);
           var keyTypeField = default(sbyte);
           var coordinatorKeysField = ImmutableArray<string>.Empty;
           return (index, new(
               keyField,
               keyTypeField,
               coordinatorKeysField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FindCoordinatorRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.KeyField);
           return index;
       }
       private static (int Offset, FindCoordinatorRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var keyField) = Decoder.ReadString(buffer, index);
           (index, var keyTypeField) = Decoder.ReadInt8(buffer, index);
           var coordinatorKeysField = ImmutableArray<string>.Empty;
           return (index, new(
               keyField,
               keyTypeField,
               coordinatorKeysField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, FindCoordinatorRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.KeyField);
           index = Encoder.WriteInt8(buffer, index, message.KeyTypeField);
           return index;
       }
       private static (int Offset, FindCoordinatorRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var keyField) = Decoder.ReadString(buffer, index);
           (index, var keyTypeField) = Decoder.ReadInt8(buffer, index);
           var coordinatorKeysField = ImmutableArray<string>.Empty;
           return (index, new(
               keyField,
               keyTypeField,
               coordinatorKeysField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, FindCoordinatorRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.KeyField);
           index = Encoder.WriteInt8(buffer, index, message.KeyTypeField);
           return index;
       }
       private static (int Offset, FindCoordinatorRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var keyField) = Decoder.ReadCompactString(buffer, index);
           (index, var keyTypeField) = Decoder.ReadInt8(buffer, index);
           var coordinatorKeysField = ImmutableArray<string>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               keyField,
               keyTypeField,
               coordinatorKeysField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, FindCoordinatorRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.KeyField);
           index = Encoder.WriteInt8(buffer, index, message.KeyTypeField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, FindCoordinatorRequest Value) ReadV04(byte[] buffer, int index)
       {
           var keyField = "";
           (index, var keyTypeField) = Decoder.ReadInt8(buffer, index);
           (index, var coordinatorKeysField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (coordinatorKeysField == null)
               throw new NullReferenceException("Null not allowed for 'CoordinatorKeys'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               keyField,
               keyTypeField,
               coordinatorKeysField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, FindCoordinatorRequest message)
       {
           index = Encoder.WriteInt8(buffer, index, message.KeyTypeField);
           index = Encoder.WriteCompactArray<string>(buffer, index, message.CoordinatorKeysField, Encoder.WriteCompactString);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}