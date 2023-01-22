using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult;
using DescribeConfigsResourceResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult;
using DescribeConfigsSynonym = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeConfigsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeConfigsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<DescribeConfigsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, DescribeConfigsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeConfigsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeConfigsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DescribeConfigsResult>(buffer, index, DescribeConfigsResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeConfigsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DescribeConfigsResult>(buffer, index, DescribeConfigsResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeConfigsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DescribeConfigsResult>(buffer, index, DescribeConfigsResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV02);
           return index;
       }
       private static (int Offset, DescribeConfigsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<DescribeConfigsResult>(buffer, index, DescribeConfigsResultSerde.ReadV03);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV03);
           return index;
       }
       private static (int Offset, DescribeConfigsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<DescribeConfigsResult>(buffer, index, DescribeConfigsResultSerde.ReadV04);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeConfigsResultSerde
       {
           public static (int Offset, DescribeConfigsResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, index, DescribeConfigsResourceResultSerde.ReadV00);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeConfigsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, DescribeConfigsResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, index, DescribeConfigsResourceResultSerde.ReadV01);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribeConfigsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV01);
               return index;
           }
           public static (int Offset, DescribeConfigsResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, index, DescribeConfigsResourceResultSerde.ReadV02);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribeConfigsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV02);
               return index;
           }
           public static (int Offset, DescribeConfigsResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var configsField) = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, index, DescribeConfigsResourceResultSerde.ReadV03);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribeConfigsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV03);
               return index;
           }
           public static (int Offset, DescribeConfigsResult Value) ReadV04(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var configsField) = Decoder.ReadCompactArray<DescribeConfigsResourceResult>(buffer, index, DescribeConfigsResourceResultSerde.ReadV04);
               if (configsField == null)
                   throw new NullReferenceException("Null not allowed for 'Configs'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField,
                   configsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DescribeConfigsResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteCompactArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV04);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DescribeConfigsResourceResultSerde
           {
               public static (int Offset, DescribeConfigsResourceResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   (index, var isDefaultField) = Decoder.ReadBoolean(buffer, index);
                   var configSourceField = default(sbyte);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   var synonymsField = ImmutableArray<DescribeConfigsSynonym>.Empty;
                   var configTypeField = default(sbyte);
                   var documentationField = default(string?);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       isDefaultField,
                       configSourceField,
                       isSensitiveField,
                       synonymsField,
                       configTypeField,
                       documentationField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DescribeConfigsResourceResult message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsDefaultField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   return index;
               }
               public static (int Offset, DescribeConfigsResourceResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   var isDefaultField = default(bool);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, var synonymsField) = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, index, DescribeConfigsSynonymSerde.ReadV01);
                   if (synonymsField == null)
                       throw new NullReferenceException("Null not allowed for 'Synonyms'");
                   var configTypeField = default(sbyte);
                   var documentationField = default(string?);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       isDefaultField,
                       configSourceField,
                       isSensitiveField,
                       synonymsField.Value,
                       configTypeField,
                       documentationField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DescribeConfigsResourceResult message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV01);
                   return index;
               }
               public static (int Offset, DescribeConfigsResourceResult Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   var isDefaultField = default(bool);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, var synonymsField) = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, index, DescribeConfigsSynonymSerde.ReadV02);
                   if (synonymsField == null)
                       throw new NullReferenceException("Null not allowed for 'Synonyms'");
                   var configTypeField = default(sbyte);
                   var documentationField = default(string?);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       isDefaultField,
                       configSourceField,
                       isSensitiveField,
                       synonymsField.Value,
                       configTypeField,
                       documentationField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DescribeConfigsResourceResult message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV02);
                   return index;
               }
               public static (int Offset, DescribeConfigsResourceResult Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   var isDefaultField = default(bool);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, var synonymsField) = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, index, DescribeConfigsSynonymSerde.ReadV03);
                   if (synonymsField == null)
                       throw new NullReferenceException("Null not allowed for 'Synonyms'");
                   (index, var configTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var documentationField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       isDefaultField,
                       configSourceField,
                       isSensitiveField,
                       synonymsField.Value,
                       configTypeField,
                       documentationField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, DescribeConfigsResourceResult message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV03);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigTypeField);
                   index = Encoder.WriteNullableString(buffer, index, message.DocumentationField);
                   return index;
               }
               public static (int Offset, DescribeConfigsResourceResult Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   var isDefaultField = default(bool);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, var synonymsField) = Decoder.ReadCompactArray<DescribeConfigsSynonym>(buffer, index, DescribeConfigsSynonymSerde.ReadV04);
                   if (synonymsField == null)
                       throw new NullReferenceException("Null not allowed for 'Synonyms'");
                   (index, var configTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var documentationField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       isDefaultField,
                       configSourceField,
                       isSensitiveField,
                       synonymsField.Value,
                       configTypeField,
                       documentationField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, DescribeConfigsResourceResult message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteCompactArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV04);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigTypeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.DocumentationField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class DescribeConfigsSynonymSerde
               {
                   public static (int Offset, DescribeConfigsSynonym Value) ReadV00(byte[] buffer, int index)
                   {
                       var nameField = "";
                       var valueField = default(string?);
                       var sourceField = default(sbyte);
                       return (index, new(
                           nameField,
                           valueField,
                           sourceField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, DescribeConfigsSynonym message)
                   {
                       return index;
                   }
                   public static (int Offset, DescribeConfigsSynonym Value) ReadV01(byte[] buffer, int index)
                   {
                       (index, var nameField) = Decoder.ReadString(buffer, index);
                       (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                       (index, var sourceField) = Decoder.ReadInt8(buffer, index);
                       return (index, new(
                           nameField,
                           valueField,
                           sourceField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, DescribeConfigsSynonym message)
                   {
                       index = Encoder.WriteString(buffer, index, message.NameField);
                       index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                       index = Encoder.WriteInt8(buffer, index, message.SourceField);
                       return index;
                   }
                   public static (int Offset, DescribeConfigsSynonym Value) ReadV02(byte[] buffer, int index)
                   {
                       (index, var nameField) = Decoder.ReadString(buffer, index);
                       (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                       (index, var sourceField) = Decoder.ReadInt8(buffer, index);
                       return (index, new(
                           nameField,
                           valueField,
                           sourceField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, DescribeConfigsSynonym message)
                   {
                       index = Encoder.WriteString(buffer, index, message.NameField);
                       index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                       index = Encoder.WriteInt8(buffer, index, message.SourceField);
                       return index;
                   }
                   public static (int Offset, DescribeConfigsSynonym Value) ReadV03(byte[] buffer, int index)
                   {
                       (index, var nameField) = Decoder.ReadString(buffer, index);
                       (index, var valueField) = Decoder.ReadNullableString(buffer, index);
                       (index, var sourceField) = Decoder.ReadInt8(buffer, index);
                       return (index, new(
                           nameField,
                           valueField,
                           sourceField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, DescribeConfigsSynonym message)
                   {
                       index = Encoder.WriteString(buffer, index, message.NameField);
                       index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                       index = Encoder.WriteInt8(buffer, index, message.SourceField);
                       return index;
                   }
                   public static (int Offset, DescribeConfigsSynonym Value) ReadV04(byte[] buffer, int index)
                   {
                       (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                       (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                       (index, var sourceField) = Decoder.ReadInt8(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           nameField,
                           valueField,
                           sourceField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, DescribeConfigsSynonym message)
                   {
                       index = Encoder.WriteCompactString(buffer, index, message.NameField);
                       index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                       index = Encoder.WriteInt8(buffer, index, message.SourceField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}