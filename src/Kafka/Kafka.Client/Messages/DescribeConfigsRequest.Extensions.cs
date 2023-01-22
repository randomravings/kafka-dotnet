using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeConfigsResource = Kafka.Client.Messages.DescribeConfigsRequest.DescribeConfigsResource;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeConfigsRequestSerde
   {
       private static readonly DecodeDelegate<DescribeConfigsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<DescribeConfigsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, DescribeConfigsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeConfigsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeConfigsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<DescribeConfigsResource>(buffer, index, DescribeConfigsResourceSerde.ReadV00);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           var includeSynonymsField = default(bool);
           var includeDocumentationField = default(bool);
           return (index, new(
               resourcesField.Value,
               includeSynonymsField,
               includeDocumentationField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeConfigsRequest message)
       {
           index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeConfigsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<DescribeConfigsResource>(buffer, index, DescribeConfigsResourceSerde.ReadV01);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var includeSynonymsField) = Decoder.ReadBoolean(buffer, index);
           var includeDocumentationField = default(bool);
           return (index, new(
               resourcesField.Value,
               includeSynonymsField,
               includeDocumentationField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeConfigsRequest message)
       {
           index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV01);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
           return index;
       }
       private static (int Offset, DescribeConfigsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<DescribeConfigsResource>(buffer, index, DescribeConfigsResourceSerde.ReadV02);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var includeSynonymsField) = Decoder.ReadBoolean(buffer, index);
           var includeDocumentationField = default(bool);
           return (index, new(
               resourcesField.Value,
               includeSynonymsField,
               includeDocumentationField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeConfigsRequest message)
       {
           index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV02);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
           return index;
       }
       private static (int Offset, DescribeConfigsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadArray<DescribeConfigsResource>(buffer, index, DescribeConfigsResourceSerde.ReadV03);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var includeSynonymsField) = Decoder.ReadBoolean(buffer, index);
           (index, var includeDocumentationField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               resourcesField.Value,
               includeSynonymsField,
               includeDocumentationField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeConfigsRequest message)
       {
           index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV03);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeDocumentationField);
           return index;
       }
       private static (int Offset, DescribeConfigsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var resourcesField) = Decoder.ReadCompactArray<DescribeConfigsResource>(buffer, index, DescribeConfigsResourceSerde.ReadV04);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, var includeSynonymsField) = Decoder.ReadBoolean(buffer, index);
           (index, var includeDocumentationField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               resourcesField.Value,
               includeSynonymsField,
               includeDocumentationField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeConfigsRequest message)
       {
           index = Encoder.WriteCompactArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV04);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
           index = Encoder.WriteBoolean(buffer, index, message.IncludeDocumentationField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeConfigsResourceSerde
       {
           public static (int Offset, DescribeConfigsResource Value) ReadV00(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configurationKeysField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configurationKeysField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
               return index;
           }
           public static (int Offset, DescribeConfigsResource Value) ReadV01(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configurationKeysField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configurationKeysField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribeConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
               return index;
           }
           public static (int Offset, DescribeConfigsResource Value) ReadV02(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configurationKeysField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configurationKeysField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribeConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
               return index;
           }
           public static (int Offset, DescribeConfigsResource Value) ReadV03(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configurationKeysField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configurationKeysField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribeConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
               return index;
           }
           public static (int Offset, DescribeConfigsResource Value) ReadV04(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var configurationKeysField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   configurationKeysField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DescribeConfigsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteCompactArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}