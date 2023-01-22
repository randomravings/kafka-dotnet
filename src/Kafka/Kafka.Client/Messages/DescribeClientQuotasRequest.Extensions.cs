using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ComponentData = Kafka.Client.Messages.DescribeClientQuotasRequest.ComponentData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeClientQuotasRequestSerde
   {
       private static readonly DecodeDelegate<DescribeClientQuotasRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<DescribeClientQuotasRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, DescribeClientQuotasRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeClientQuotasRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeClientQuotasRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var componentsField) = Decoder.ReadArray<ComponentData>(buffer, index, ComponentDataSerde.ReadV00);
           if (componentsField == null)
               throw new NullReferenceException("Null not allowed for 'Components'");
           (index, var strictField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               componentsField.Value,
               strictField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeClientQuotasRequest message)
       {
           index = Encoder.WriteArray<ComponentData>(buffer, index, message.ComponentsField, ComponentDataSerde.WriteV00);
           index = Encoder.WriteBoolean(buffer, index, message.StrictField);
           return index;
       }
       private static (int Offset, DescribeClientQuotasRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var componentsField) = Decoder.ReadCompactArray<ComponentData>(buffer, index, ComponentDataSerde.ReadV01);
           if (componentsField == null)
               throw new NullReferenceException("Null not allowed for 'Components'");
           (index, var strictField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               componentsField.Value,
               strictField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeClientQuotasRequest message)
       {
           index = Encoder.WriteCompactArray<ComponentData>(buffer, index, message.ComponentsField, ComponentDataSerde.WriteV01);
           index = Encoder.WriteBoolean(buffer, index, message.StrictField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ComponentDataSerde
       {
           public static (int Offset, ComponentData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var entityTypeField) = Decoder.ReadString(buffer, index);
               (index, var matchTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var matchField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   entityTypeField,
                   matchTypeField,
                   matchField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ComponentData message)
           {
               index = Encoder.WriteString(buffer, index, message.EntityTypeField);
               index = Encoder.WriteInt8(buffer, index, message.MatchTypeField);
               index = Encoder.WriteNullableString(buffer, index, message.MatchField);
               return index;
           }
           public static (int Offset, ComponentData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var entityTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var matchTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var matchField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   entityTypeField,
                   matchTypeField,
                   matchField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ComponentData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.EntityTypeField);
               index = Encoder.WriteInt8(buffer, index, message.MatchTypeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.MatchField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}