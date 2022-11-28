using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FeatureUpdateKey = Kafka.Client.Messages.UpdateFeaturesRequest.FeatureUpdateKey;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesRequestSerde
    {
        private static readonly DecodeDelegate<UpdateFeaturesRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<UpdateFeaturesRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static UpdateFeaturesRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, UpdateFeaturesRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static UpdateFeaturesRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(ref buffer, (ref ReadOnlyMemory<byte> b) => FeatureUpdateKeySerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = default(bool);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, UpdateFeaturesRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, message.FeatureUpdatesField, (b, i) => FeatureUpdateKeySerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static UpdateFeaturesRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(ref buffer, (ref ReadOnlyMemory<byte> b) => FeatureUpdateKeySerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, UpdateFeaturesRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, message.FeatureUpdatesField, (b, i) => FeatureUpdateKeySerde.WriteV01(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class FeatureUpdateKeySerde
        {
            public static FeatureUpdateKey ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var featureField = Decoder.ReadCompactString(ref buffer);
                var maxVersionLevelField = Decoder.ReadInt16(ref buffer);
                var allowDowngradeField = Decoder.ReadBoolean(ref buffer);
                var upgradeTypeField = default(sbyte);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    featureField,
                    maxVersionLevelField,
                    allowDowngradeField,
                    upgradeTypeField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, FeatureUpdateKey message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.FeatureField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                buffer = Encoder.WriteBoolean(buffer, message.AllowDowngradeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static FeatureUpdateKey ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var featureField = Decoder.ReadCompactString(ref buffer);
                var maxVersionLevelField = Decoder.ReadInt16(ref buffer);
                var allowDowngradeField = default(bool);
                var upgradeTypeField = Decoder.ReadInt8(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    featureField,
                    maxVersionLevelField,
                    allowDowngradeField,
                    upgradeTypeField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, FeatureUpdateKey message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.FeatureField);
                buffer = Encoder.WriteInt16(buffer, message.MaxVersionLevelField);
                buffer = Encoder.WriteInt8(buffer, message.UpgradeTypeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}