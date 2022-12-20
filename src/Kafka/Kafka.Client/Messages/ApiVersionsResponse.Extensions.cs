using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.FinalizedFeatureKey;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponse.ApiVersion;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.SupportedFeatureKey;

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
        public static ApiVersionsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ApiVersionsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ApiVersionsResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, ref index, ApiVersionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = default(int);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV00);
            return index;
        }
        private static ApiVersionsResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, ref index, ApiVersionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ApiVersionsResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, ref index, ApiVersionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ApiVersionsResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ApiVersion>(buffer, index, message.ApiKeysField, ApiVersionSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ApiVersionsResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var apiKeysField = Decoder.ReadCompactArray<ApiVersion>(buffer, ref index, ApiVersionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
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
        private static class FinalizedFeatureKeySerde
        {
            public static FinalizedFeatureKey ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var maxVersionLevelField = Decoder.ReadInt16(buffer, ref index);
                var minVersionLevelField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField
                );
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
        private static class ApiVersionSerde
        {
            public static ApiVersion ReadV00(byte[] buffer, ref int index)
            {
                var apiKeyField = Decoder.ReadInt16(buffer, ref index);
                var minVersionField = Decoder.ReadInt16(buffer, ref index);
                var maxVersionField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ApiVersion message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
                index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
                return index;
            }
            public static ApiVersion ReadV01(byte[] buffer, ref int index)
            {
                var apiKeyField = Decoder.ReadInt16(buffer, ref index);
                var minVersionField = Decoder.ReadInt16(buffer, ref index);
                var maxVersionField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ApiVersion message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
                index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
                return index;
            }
            public static ApiVersion ReadV02(byte[] buffer, ref int index)
            {
                var apiKeyField = Decoder.ReadInt16(buffer, ref index);
                var minVersionField = Decoder.ReadInt16(buffer, ref index);
                var maxVersionField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static int WriteV02(byte[] buffer, int index, ApiVersion message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ApiKeyField);
                index = Encoder.WriteInt16(buffer, index, message.MinVersionField);
                index = Encoder.WriteInt16(buffer, index, message.MaxVersionField);
                return index;
            }
            public static ApiVersion ReadV03(byte[] buffer, ref int index)
            {
                var apiKeyField = Decoder.ReadInt16(buffer, ref index);
                var minVersionField = Decoder.ReadInt16(buffer, ref index);
                var maxVersionField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
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
        private static class SupportedFeatureKeySerde
        {
            public static SupportedFeatureKey ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var minVersionField = Decoder.ReadInt16(buffer, ref index);
                var maxVersionField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    minVersionField,
                    maxVersionField
                );
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
    }
}