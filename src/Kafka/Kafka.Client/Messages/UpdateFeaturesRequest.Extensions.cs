using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FeatureUpdateKey = Kafka.Client.Messages.UpdateFeaturesRequest.FeatureUpdateKey;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesRequestSerde
    {
        private static readonly Func<Stream, UpdateFeaturesRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, UpdateFeaturesRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static UpdateFeaturesRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UpdateFeaturesRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UpdateFeaturesRequest ReadV00(Stream buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, b => FeatureUpdateKeySerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = default(bool);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static void WriteV00(Stream buffer, UpdateFeaturesRequest message)
        {
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, message.FeatureUpdatesField, (b, i) => FeatureUpdateKeySerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static UpdateFeaturesRequest ReadV01(Stream buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, b => FeatureUpdateKeySerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static void WriteV01(Stream buffer, UpdateFeaturesRequest message)
        {
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, message.FeatureUpdatesField, (b, i) => FeatureUpdateKeySerde.WriteV01(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class FeatureUpdateKeySerde
        {
            public static FeatureUpdateKey ReadV00(Stream buffer)
            {
                var featureField = Decoder.ReadCompactString(buffer);
                var maxVersionLevelField = Decoder.ReadInt16(buffer);
                var allowDowngradeField = Decoder.ReadBoolean(buffer);
                var upgradeTypeField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    featureField,
                    maxVersionLevelField,
                    allowDowngradeField,
                    upgradeTypeField
                );
            }
            public static void WriteV00(Stream buffer, FeatureUpdateKey message)
            {
                Encoder.WriteCompactString(buffer, message.FeatureField);
                Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                Encoder.WriteBoolean(buffer, message.AllowDowngradeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static FeatureUpdateKey ReadV01(Stream buffer)
            {
                var featureField = Decoder.ReadCompactString(buffer);
                var maxVersionLevelField = Decoder.ReadInt16(buffer);
                var allowDowngradeField = default(bool);
                var upgradeTypeField = Decoder.ReadInt8(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    featureField,
                    maxVersionLevelField,
                    allowDowngradeField,
                    upgradeTypeField
                );
            }
            public static void WriteV01(Stream buffer, FeatureUpdateKey message)
            {
                Encoder.WriteCompactString(buffer, message.FeatureField);
                Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                Encoder.WriteInt8(buffer, message.UpgradeTypeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}