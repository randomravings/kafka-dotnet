using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterableConfig = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource.AlterableConfig;
using AlterConfigsResource = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterConfigsRequestSerde
   {
       private static readonly DecodeDelegate<AlterConfigsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<AlterConfigsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, AlterConfigsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterConfigsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterConfigsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<AlterConfigsResource>(buffer, index, AlterConfigsResourceSerde.ReadV00);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               resourcesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterConfigsRequest message)
       {
           index = Encoder.WriteArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV00);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, AlterConfigsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<AlterConfigsResource>(buffer, index, AlterConfigsResourceSerde.ReadV01);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               resourcesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterConfigsRequest message)
       {
           index = Encoder.WriteArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV01);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, AlterConfigsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadCompactArray<AlterConfigsResource>(buffer, index, AlterConfigsResourceSerde.ReadV02);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               resourcesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AlterConfigsRequest message)
       {
           index = Encoder.WriteCompactArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV02);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AlterConfigsResourceSerde
       {
           public static (int Offset, AlterConfigsResource Value) ReadV00(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<AlterableConfig>(buffer, index, AlterableConfigSerde.ReadV00);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AlterConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV00);
               return index;
           }
           public static (int Offset, AlterConfigsResource Value) ReadV01(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<AlterableConfig>(buffer, index, AlterableConfigSerde.ReadV01);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AlterConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV01);
               return index;
           }
           public static (int Offset, AlterConfigsResource Value) ReadV02(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var configsField) = Decoder.ReadCompactArray<AlterableConfig>(buffer, index, AlterableConfigSerde.ReadV02);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AlterConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteCompactArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class AlterableConfigSerde
           {
               public static (int Offset, AlterableConfig Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, AlterableConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, AlterableConfig Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, AlterableConfig message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, AlterableConfig Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, AlterableConfig message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}