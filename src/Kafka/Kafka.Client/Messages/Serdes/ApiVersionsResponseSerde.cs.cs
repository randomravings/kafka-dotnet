using ApiVersion = Kafka.Client.Messages.ApiVersionsResponse.ApiVersion;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.FinalizedFeatureKey;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.SupportedFeatureKey;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(18);
        private static readonly VersionRange API_VERSIONS = new(0, 3);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (3, 32767);
        public static IEncoder<ResponseHeader, ApiVersionsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, ApiVersionsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, ApiVersionsResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV0);
            return index;
        }
        private static (int Offset, ApiVersionsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV0);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            return (index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ApiVersionsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV1);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV2);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ApiVersionsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV2);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV3);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            var taggedFieldsCount = 3u;
            var previousTagged = 2;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactArray<SupportedFeatureKey>(buffer, index, message.SupportedFeaturesField, SupportedFeatureKeySerde.WriteV3);
            }
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 1);
                index = BinaryEncoder.WriteInt64(buffer, index, message.FinalizedFeaturesEpochField);
            }
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 2);
                index = BinaryEncoder.WriteCompactArray<FinalizedFeatureKey>(buffer, index, message.FinalizedFeaturesField, FinalizedFeatureKeySerde.WriteV3);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 2");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, ApiVersionsResponse Value) ReadV3(byte[] buffer, int index)
        {
            var errorCodeField = default(short);
            var apiKeysField = ImmutableArray<ApiVersion>.Empty;
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _apiKeysField_) = BinaryDecoder.ReadCompactArray<ApiVersion>(buffer, index, ApiVersionSerde.ReadV3);
            if (_apiKeysField_ == null)
                throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            else
                apiKeysField = _apiKeysField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    switch (tag)
                    {
                        case 0:
                            (index, var _supportedFeaturesField_) = BinaryDecoder.ReadCompactArray<SupportedFeatureKey>(buffer, index, SupportedFeatureKeySerde.ReadV3);
                            if (_supportedFeaturesField_ == null)
                                throw new NullReferenceException("Null not allowed for 'SupportedFeatures'");
                            else
                                supportedFeaturesField = _supportedFeaturesField_.Value;
                            break;
                        case 1:
                            (index, finalizedFeaturesEpochField) = BinaryDecoder.ReadInt64(buffer, index);
                            break;
                        case 2:
                            (index, var _finalizedFeaturesField_) = BinaryDecoder.ReadCompactArray<FinalizedFeatureKey>(buffer, index, FinalizedFeatureKeySerde.ReadV3);
                            if (_finalizedFeaturesField_ == null)
                                throw new NullReferenceException("Null not allowed for 'FinalizedFeatures'");
                            else
                                finalizedFeaturesField = _finalizedFeaturesField_.Value;
                            break;
                        default:
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                        break;
                    }
                    taggedFieldsCount--;
                }
            }
            return (index, new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class ApiVersionSerde
        {
            public static int WriteV0(byte[] buffer, int index, ApiVersion message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ApiVersion Value) ReadV0(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, ApiVersion message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ApiVersion Value) ReadV1(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, ApiVersion message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ApiVersion Value) ReadV2(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, ApiVersion message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ApiVersion Value) ReadV3(byte[] buffer, int index)
            {
                var apiKeyField = default(short);
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, apiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class FinalizedFeatureKeySerde
        {
            public static int WriteV0(byte[] buffer, int index, FinalizedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FinalizedFeatureKey Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, FinalizedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FinalizedFeatureKey Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, FinalizedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FinalizedFeatureKey Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, FinalizedFeatureKey message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionLevelField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FinalizedFeatureKey Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var maxVersionLevelField = default(short);
                var minVersionLevelField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, maxVersionLevelField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, minVersionLevelField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField,
                    taggedFields
                ));
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class SupportedFeatureKeySerde
        {
            public static int WriteV0(byte[] buffer, int index, SupportedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SupportedFeatureKey Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, SupportedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SupportedFeatureKey Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, SupportedFeatureKey message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SupportedFeatureKey Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, SupportedFeatureKey message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MinVersionField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.MaxVersionField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SupportedFeatureKey Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var minVersionField = default(short);
                var maxVersionField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, minVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, maxVersionField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    nameField,
                    minVersionField,
                    maxVersionField,
                    taggedFields
                ));
            }
        }
    }
}