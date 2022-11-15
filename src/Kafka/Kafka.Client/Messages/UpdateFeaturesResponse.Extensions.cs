using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdatableFeatureResult = Kafka.Client.Messages.UpdateFeaturesResponse.UpdatableFeatureResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesResponseSerde
    {
        private static readonly Func<Stream, UpdateFeaturesResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, UpdateFeaturesResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static UpdateFeaturesResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UpdateFeaturesResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UpdateFeaturesResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, b => UpdatableFeatureResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, UpdateFeaturesResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, message.ResultsField, (b, i) => UpdatableFeatureResultSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static UpdateFeaturesResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, b => UpdatableFeatureResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, UpdateFeaturesResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, message.ResultsField, (b, i) => UpdatableFeatureResultSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class UpdatableFeatureResultSerde
        {
            public static UpdatableFeatureResult ReadV00(Stream buffer)
            {
                var featureField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    featureField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV00(Stream buffer, UpdatableFeatureResult message)
            {
                Encoder.WriteCompactString(buffer, message.FeatureField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static UpdatableFeatureResult ReadV01(Stream buffer)
            {
                var featureField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    featureField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV01(Stream buffer, UpdatableFeatureResult message)
            {
                Encoder.WriteCompactString(buffer, message.FeatureField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}