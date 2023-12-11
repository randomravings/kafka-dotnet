using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponseData.ApiVersion;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.FinalizedFeatureKey;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.SupportedFeatureKey;

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
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion) =>
            ResponseHeaderDecoder.ReadV0
        ;
        protected override DecodeValue<ApiVersionsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ApiVersionsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, apiKeysField) = BinaryDecoder.ReadArray<ApiVersion>(buffer, i, ApiVersionDecoder.ReadV0);
            if (apiKeysField.IsDefault)
                throw new InvalidDataException("apiKeysField was null");
;
            return new(i, new(
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
        private static DecodeResult<ApiVersionsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, apiKeysField) = BinaryDecoder.ReadArray<ApiVersion>(buffer, i, ApiVersionDecoder.ReadV1);
            if (apiKeysField.IsDefault)
                throw new InvalidDataException("apiKeysField was null");
;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
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
        private static DecodeResult<ApiVersionsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, apiKeysField) = BinaryDecoder.ReadArray<ApiVersion>(buffer, i, ApiVersionDecoder.ReadV2);
            if (apiKeysField.IsDefault)
                throw new InvalidDataException("apiKeysField was null");
;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
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
        private static DecodeResult<ApiVersionsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var zkMigrationReadyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, apiKeysField) = BinaryDecoder.ReadCompactArray<ApiVersion>(buffer, i, ApiVersionDecoder.ReadV3);
            if (apiKeysField.IsDefault)
                throw new InvalidDataException("apiKeysField was null");
;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    switch (tag)
                    {
                        case 0:
                            (i, supportedFeaturesField) = BinaryDecoder.ReadCompactArray<SupportedFeatureKey>(buffer, i, SupportedFeatureKeyDecoder.ReadV3);
                            if (supportedFeaturesField.IsDefault)
                                throw new InvalidDataException("supportedFeaturesField was null");
;
                            break;
                        case 1:
                            (i, finalizedFeaturesEpochField) = BinaryDecoder.ReadInt64(buffer, i);
                            break;
                        case 2:
                            (i, finalizedFeaturesField) = BinaryDecoder.ReadCompactArray<FinalizedFeatureKey>(buffer, i, FinalizedFeatureKeyDecoder.ReadV3);
                            if (finalizedFeaturesField.IsDefault)
                                throw new InvalidDataException("finalizedFeaturesField was null");
;
                            break;
                        case 3:
                            (i, zkMigrationReadyField) = BinaryDecoder.ReadBoolean(buffer, i);
                            break;
                        default:
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                    }
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
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
            public static DecodeResult<ApiVersion> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, apiKeyField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, minVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, maxVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, apiKeyField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, minVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, maxVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, apiKeyField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, minVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, maxVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<ApiVersion> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, apiKeyField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, minVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, maxVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
            public static DecodeResult<FinalizedFeatureKey> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static DecodeResult<FinalizedFeatureKey> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, maxVersionLevelField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, minVersionLevelField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
            public static DecodeResult<SupportedFeatureKey> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static DecodeResult<SupportedFeatureKey> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, minVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, maxVersionField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
        }
    }
}
