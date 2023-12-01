using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.SupportedFeatureKey;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponseData.ApiVersion;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.FinalizedFeatureKey;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ApiVersionsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ApiVersionsResponseData>
    {
        internal ApiVersionsResponseDecoder() :
            base(
                ApiKey.ApiVersions,
                new(0, 3),
                new(3, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion) =>
            ResponseHeaderDecoder.ReadV0
        ;
        protected override DecodeDelegate<ApiVersionsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ApiVersionsResponseData> ReadV0(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionDecoder.ReadV0);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            return new(index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                zkMigrationReadyField,
                taggedFields
            ));
        }
        private static DecodeResult<ApiVersionsResponseData> ReadV1(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionDecoder.ReadV1);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                zkMigrationReadyField,
                taggedFields
            ));
        }
        private static DecodeResult<ApiVersionsResponseData> ReadV2(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionDecoder.ReadV2);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                zkMigrationReadyField,
                taggedFields
            ));
        }
        private static DecodeResult<ApiVersionsResponseData> ReadV3(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadCompactArray<ApiVersion>(buffer, index, ApiVersionDecoder.ReadV3);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    switch (tag)
                    {
                        case 0:
                            (index, var _supportedFeaturesField_) = BinaryDecoder.ReadCompactArray<SupportedFeatureKey>(buffer, index, SupportedFeatureKeyDecoder.ReadV3);
                            if (_supportedFeaturesField_ == null)
                                throw new NullReferenceException("Null not allowed for 'SupportedFeatures'");
                            else
                                supportedFeaturesField = _supportedFeaturesField_.Value;
                            break;
                        case 1:
                            (index, finalizedFeaturesEpochField) = BinaryDecoder.ReadInt64(buffer, index);
                            break;
                        case 2:
                            (index, var _finalizedFeaturesField_) = BinaryDecoder.ReadCompactArray<FinalizedFeatureKey>(buffer, index, FinalizedFeatureKeyDecoder.ReadV3);
                            if (_finalizedFeaturesField_ == null)
                                throw new NullReferenceException("Null not allowed for 'FinalizedFeatures'");
                            else
                                finalizedFeaturesField = _finalizedFeaturesField_.Value;
                            break;
                        case 3:
                            (index, zkMigrationReadyField) = BinaryDecoder.ReadBoolean(buffer, index);
                            break;
                        default:
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                    }
                    taggedFieldsCount--;
                }
            }
            return new(index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                zkMigrationReadyField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ApiVersionDecoder
        {
            public static DecodeResult<ApiVersion> ReadV0(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV1(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV2(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV3(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class FinalizedFeatureKeyDecoder
        {
            public static DecodeResult<FinalizedFeatureKey> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, maxVersionLevelField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionLevelField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class SupportedFeatureKeyDecoder
        {
            public static DecodeResult<SupportedFeatureKey> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
        }
    }
}
