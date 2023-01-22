using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.FinalizedFeatureKey;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.SupportedFeatureKey;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponse.ApiVersion;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ApiVersionsResponseSerde
   {
       private static readonly DecodeDelegate<ApiVersionsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<ApiVersionsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, ApiVersionsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ApiVersionsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ApiVersionsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var apiKeysField) = Decoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV00);
           if (apiKeysField == null)
               throw new NullReferenceException("Null not allowed for 'ApiKeys'");
           var throttleTimeMsField = default(int);
           var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
           var finalizedFeaturesEpochField = default(long);
           var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
           return (index, new(
               errorCodeField,
               apiKeysField.Value,
               throttleTimeMsField,
               supportedFeaturesField,
               finalizedFeaturesEpochField,
               finalizedFeaturesField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ApiVersionsResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV00);
           return index;
       }
       private static (int Offset, ApiVersionsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var apiKeysField) = Decoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV01);
           if (apiKeysField == null)
               throw new NullReferenceException("Null not allowed for 'ApiKeys'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
           var finalizedFeaturesEpochField = default(long);
           var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
           return (index, new(
               errorCodeField,
               apiKeysField.Value,
               throttleTimeMsField,
               supportedFeaturesField,
               finalizedFeaturesEpochField,
               finalizedFeaturesField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ApiVersionsResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ApiVersionsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var apiKeysField) = Decoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV02);
           if (apiKeysField == null)
               throw new NullReferenceException("Null not allowed for 'ApiKeys'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
           var finalizedFeaturesEpochField = default(long);
           var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
           return (index, new(
               errorCodeField,
               apiKeysField.Value,
               throttleTimeMsField,
               supportedFeaturesField,
               finalizedFeaturesEpochField,
               finalizedFeaturesField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ApiVersionsResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ApiVersionsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var apiKeysField) = Decoder.ReadCompactArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV03);
           if (apiKeysField == null)
               throw new NullReferenceException("Null not allowed for 'ApiKeys'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
           var finalizedFeaturesEpochField = default(long);
           var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               apiKeysField.Value,
               throttleTimeMsField,
               supportedFeaturesField,
               finalizedFeaturesEpochField,
               finalizedFeaturesField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ApiVersionsResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV03);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<SupportedFeatureKey>(buffer, index, message.SupportedFeaturesField, SupportedFeatureKeySerde.WriteV03);
           index = Encoder.WriteInt64(buffer, index, message.FinalizedFeaturesEpochField);
           index = Encoder.WriteCompactArray<FinalizedFeatureKey>(buffer, index, message.FinalizedFeaturesField, FinalizedFeatureKeySerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class FinalizedFeatureKeySerde
       {
           public static (int Offset, FinalizedFeatureKey Value) ReadV00(byte[] buffer, int index)
           {
               var nameField = "";
               var maxVersionLevelField = default(short);
               var minVersionLevelField = default(short);
               return (index, new(
                   nameField,
                   maxVersionLevelField,
                   minVersionLevelField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, FinalizedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, FinalizedFeatureKey Value) ReadV01(byte[] buffer, int index)
           {
               var nameField = "";
               var maxVersionLevelField = default(short);
               var minVersionLevelField = default(short);
               return (index, new(
                   nameField,
                   maxVersionLevelField,
                   minVersionLevelField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, FinalizedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, FinalizedFeatureKey Value) ReadV02(byte[] buffer, int index)
           {
               var nameField = "";
               var maxVersionLevelField = default(short);
               var minVersionLevelField = default(short);
               return (index, new(
                   nameField,
                   maxVersionLevelField,
                   minVersionLevelField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, FinalizedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, FinalizedFeatureKey Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var maxVersionLevelField) = Decoder.ReadInt16(buffer, index);
               (index, var minVersionLevelField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   maxVersionLevelField,
                   minVersionLevelField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, FinalizedFeatureKey message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionLevelField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class SupportedFeatureKeySerde
       {
           public static (int Offset, SupportedFeatureKey Value) ReadV00(byte[] buffer, int index)
           {
               var nameField = "";
               var minVersionField = default(short);
               var maxVersionField = default(short);
               return (index, new(
                   nameField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, SupportedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, SupportedFeatureKey Value) ReadV01(byte[] buffer, int index)
           {
               var nameField = "";
               var minVersionField = default(short);
               var maxVersionField = default(short);
               return (index, new(
                   nameField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, SupportedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, SupportedFeatureKey Value) ReadV02(byte[] buffer, int index)
           {
               var nameField = "";
               var minVersionField = default(short);
               var maxVersionField = default(short);
               return (index, new(
                   nameField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, SupportedFeatureKey message)
           {
               return index;
           }
           public static (int Offset, SupportedFeatureKey Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var minVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxVersionField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, SupportedFeatureKey message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ApiVersionSerde
       {
           public static (int Offset, ApiVersion Value) ReadV00(byte[] buffer, int index)
           {
               (index, var apiKeyField) = Decoder.ReadInt16(buffer, index);
               (index, var minVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxVersionField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   apiKeyField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ApiVersion message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
               return index;
           }
           public static (int Offset, ApiVersion Value) ReadV01(byte[] buffer, int index)
           {
               (index, var apiKeyField) = Decoder.ReadInt16(buffer, index);
               (index, var minVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxVersionField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   apiKeyField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ApiVersion message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
               return index;
           }
           public static (int Offset, ApiVersion Value) ReadV02(byte[] buffer, int index)
           {
               (index, var apiKeyField) = Decoder.ReadInt16(buffer, index);
               (index, var minVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxVersionField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   apiKeyField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ApiVersion message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
               return index;
           }
           public static (int Offset, ApiVersion Value) ReadV03(byte[] buffer, int index)
           {
               (index, var apiKeyField) = Decoder.ReadInt16(buffer, index);
               (index, var minVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxVersionField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   apiKeyField,
                   minVersionField,
                   maxVersionField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, ApiVersion message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
               index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}