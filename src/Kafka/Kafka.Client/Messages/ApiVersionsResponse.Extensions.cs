using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponse.ApiVersion;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.SupportedFeatureKey;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.FinalizedFeatureKey;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsResponseSerde
    {
        private static readonly DecodeDelegate<ApiVersionsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<ApiVersionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ApiVersionsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ApiVersionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ApiVersionsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ApiVersionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, ApiVersionsResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV00(b, i));
            return buffer;
        }
        private static ApiVersionsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ApiVersionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, ApiVersionsResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ApiVersionsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var apiKeysField = Decoder.ReadArray<ApiVersion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ApiVersionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, ApiVersionsResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ApiVersionsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var apiKeysField = Decoder.ReadCompactArray<ApiVersion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ApiVersionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ApiKeys'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var supportedFeaturesField = ImmutableArray<SupportedFeatureKey>.Empty;
            var finalizedFeaturesEpochField = default(long);
            var finalizedFeaturesField = ImmutableArray<FinalizedFeatureKey>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                apiKeysField,
                throttleTimeMsField,
                supportedFeaturesField,
                finalizedFeaturesEpochField,
                finalizedFeaturesField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ApiVersionsResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<ApiVersion>(buffer, message.ApiKeysField, (b, i) => ApiVersionSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<SupportedFeatureKey>(buffer, message.SupportedFeaturesField, (b, i) => SupportedFeatureKeySerde.WriteV03(b, i));
            buffer = Encoder.WriteInt64(buffer, message.FinalizedFeaturesEpochField);
            buffer = Encoder.WriteCompactArray<FinalizedFeatureKey>(buffer, message.FinalizedFeaturesField, (b, i) => FinalizedFeatureKeySerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ApiVersionSerde
        {
            public static ApiVersion ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var apiKeyField = Decoder.ReadInt16(ref buffer);
                var minVersionField = Decoder.ReadInt16(ref buffer);
                var maxVersionField = Decoder.ReadInt16(ref buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ApiVersion message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ApiKeyField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionField);
                return buffer;
            }
            public static ApiVersion ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var apiKeyField = Decoder.ReadInt16(ref buffer);
                var minVersionField = Decoder.ReadInt16(ref buffer);
                var maxVersionField = Decoder.ReadInt16(ref buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ApiVersion message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ApiKeyField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionField);
                return buffer;
            }
            public static ApiVersion ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var apiKeyField = Decoder.ReadInt16(ref buffer);
                var minVersionField = Decoder.ReadInt16(ref buffer);
                var maxVersionField = Decoder.ReadInt16(ref buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, ApiVersion message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ApiKeyField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionField);
                return buffer;
            }
            public static ApiVersion ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var apiKeyField = Decoder.ReadInt16(ref buffer);
                var minVersionField = Decoder.ReadInt16(ref buffer);
                var maxVersionField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    apiKeyField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, ApiVersion message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ApiKeyField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class SupportedFeatureKeySerde
        {
            public static SupportedFeatureKey ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var minVersionField = Decoder.ReadInt16(ref buffer);
                var maxVersionField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    minVersionField,
                    maxVersionField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, SupportedFeatureKey message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class FinalizedFeatureKeySerde
        {
            public static FinalizedFeatureKey ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var maxVersionLevelField = Decoder.ReadInt16(ref buffer);
                var minVersionLevelField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    maxVersionLevelField,
                    minVersionLevelField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, FinalizedFeatureKey message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                buffer = Encoder.WriteInt16(buffer, message.MinVersionLevelField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}