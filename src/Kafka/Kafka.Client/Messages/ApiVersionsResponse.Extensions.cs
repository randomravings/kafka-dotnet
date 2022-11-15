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
        private static readonly Func<Stream, ApiVersionsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, ApiVersionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ApiVersionsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ApiVersionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ApiVersionsResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, b => ApiVersionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
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
        private static void WriteV00(Stream buffer, ApiVersionsResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV00(b, i));
        }
        private static ApiVersionsResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, b => ApiVersionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
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
        private static void WriteV01(Stream buffer, ApiVersionsResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ApiVersionsResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(buffer, b => ApiVersionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
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
        private static void WriteV02(Stream buffer, ApiVersionsResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ApiVersionsResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var apiKeysField = Decoder.ReadCompactArray<ApiVersion>(buffer, b => ApiVersionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
        }
        private static void WriteV03(Stream buffer, ApiVersionsResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV03(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<SupportedFeatureKey>(buffer, message.SupportedFeaturesField, (b, i) => SupportedFeatureKeySerde.WriteV03(b, i));
            Encoder.WriteInt64(buffer, message.FinalizedFeaturesEpochField);
            Encoder.WriteCompactArray<FinalizedFeatureKey>(buffer, message.FinalizedFeaturesField, (b, i) => FinalizedFeatureKeySerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class FinalizedFeatureKeySerde
        {
            public static FinalizedFeatureKey ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var maxVersionLevelField = Decoder.ReadInt16(buffer);
                var minVersionLevelField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField
                );
            }
            public static void WriteV03(Stream buffer, FinalizedFeatureKey message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                Encoder.WriteInt16(buffer, message.MinVersionLevelField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class SupportedFeatureKeySerde
        {
            public static SupportedFeatureKey ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var minVersionField = Decoder.ReadInt16(buffer);
                var maxVersionField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static void WriteV03(Stream buffer, SupportedFeatureKey message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.MinVersionField);
                Encoder.WriteInt16(buffer, message.MaxVersionField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class ApiVersionSerde
        {
            public static ApiVersion ReadV00(Stream buffer)
            {
                var apiKeyField = Decoder.ReadInt16(buffer);
                var minVersionField = Decoder.ReadInt16(buffer);
                var maxVersionField = Decoder.ReadInt16(buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static void WriteV00(Stream buffer, ApiVersion message)
            {
                Encoder.WriteInt16(buffer, message.ApiKeyField);
                Encoder.WriteInt16(buffer, message.MinVersionField);
                Encoder.WriteInt16(buffer, message.MaxVersionField);
            }
            public static ApiVersion ReadV01(Stream buffer)
            {
                var apiKeyField = Decoder.ReadInt16(buffer);
                var minVersionField = Decoder.ReadInt16(buffer);
                var maxVersionField = Decoder.ReadInt16(buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static void WriteV01(Stream buffer, ApiVersion message)
            {
                Encoder.WriteInt16(buffer, message.ApiKeyField);
                Encoder.WriteInt16(buffer, message.MinVersionField);
                Encoder.WriteInt16(buffer, message.MaxVersionField);
            }
            public static ApiVersion ReadV02(Stream buffer)
            {
                var apiKeyField = Decoder.ReadInt16(buffer);
                var minVersionField = Decoder.ReadInt16(buffer);
                var maxVersionField = Decoder.ReadInt16(buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static void WriteV02(Stream buffer, ApiVersion message)
            {
                Encoder.WriteInt16(buffer, message.ApiKeyField);
                Encoder.WriteInt16(buffer, message.MinVersionField);
                Encoder.WriteInt16(buffer, message.MaxVersionField);
            }
            public static ApiVersion ReadV03(Stream buffer)
            {
                var apiKeyField = Decoder.ReadInt16(buffer);
                var minVersionField = Decoder.ReadInt16(buffer);
                var maxVersionField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static void WriteV03(Stream buffer, ApiVersion message)
            {
                Encoder.WriteInt16(buffer, message.ApiKeyField);
                Encoder.WriteInt16(buffer, message.MinVersionField);
                Encoder.WriteInt16(buffer, message.MaxVersionField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}