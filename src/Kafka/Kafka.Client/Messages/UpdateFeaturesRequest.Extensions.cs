using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using FeatureUpdateKey = Kafka.Client.Messages.UpdateFeaturesRequest.FeatureUpdateKey;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesRequestSerde
    {
        private static readonly DecodeDelegate<UpdateFeaturesRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<UpdateFeaturesRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static UpdateFeaturesRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UpdateFeaturesRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UpdateFeaturesRequest ReadV00(byte[] buffer, ref int index)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, ref index, FeatureUpdateKeySerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = default(bool);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UpdateFeaturesRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, index, message.FeatureUpdatesField, FeatureUpdateKeySerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateFeaturesRequest ReadV01(byte[] buffer, ref int index)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var featureUpdatesField = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, ref index, FeatureUpdateKeySerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                timeoutMsField,
                featureUpdatesField,
                validateOnlyField
            );
        }
        private static int WriteV01(byte[] buffer, int index, UpdateFeaturesRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, index, message.FeatureUpdatesField, FeatureUpdateKeySerde.WriteV01);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class FeatureUpdateKeySerde
        {
            public static FeatureUpdateKey ReadV00(byte[] buffer, ref int index)
            {
                var FeatureField = Decoder.ReadCompactString(buffer, ref index);
                var MaxVersionLevelField = Decoder.ReadInt16(buffer, ref index);
                var AllowDowngradeField = Decoder.ReadBoolean(buffer, ref index);
                var UpgradeTypeField = default(sbyte);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    FeatureField,
                    MaxVersionLevelField,
                    AllowDowngradeField,
                    UpgradeTypeField
                );
            }
            public static int WriteV00(byte[] buffer, int index, FeatureUpdateKey message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
                index = Encoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
                index = Encoder.WriteBoolean(buffer, index, message.AllowDowngradeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static FeatureUpdateKey ReadV01(byte[] buffer, ref int index)
            {
                var FeatureField = Decoder.ReadCompactString(buffer, ref index);
                var MaxVersionLevelField = Decoder.ReadInt16(buffer, ref index);
                var AllowDowngradeField = default(bool);
                var UpgradeTypeField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    FeatureField,
                    MaxVersionLevelField,
                    AllowDowngradeField,
                    UpgradeTypeField
                );
            }
            public static int WriteV01(byte[] buffer, int index, FeatureUpdateKey message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
                index = Encoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
                index = Encoder.WriteInt8(buffer, index, message.UpgradeTypeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}