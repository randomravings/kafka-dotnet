using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdatableFeatureResult = Kafka.Client.Messages.UpdateFeaturesResponse.UpdatableFeatureResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesResponseSerde
    {
        private static readonly DecodeDelegate<UpdateFeaturesResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<UpdateFeaturesResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static UpdateFeaturesResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, UpdateFeaturesResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static UpdateFeaturesResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdatableFeatureResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, UpdateFeaturesResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, message.ResultsField, (b, i) => UpdatableFeatureResultSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static UpdateFeaturesResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => UpdatableFeatureResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, UpdateFeaturesResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, message.ResultsField, (b, i) => UpdatableFeatureResultSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class UpdatableFeatureResultSerde
        {
            public static UpdatableFeatureResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var featureField = Decoder.ReadCompactString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    featureField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, UpdatableFeatureResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.FeatureField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static UpdatableFeatureResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var featureField = Decoder.ReadCompactString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    featureField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, UpdatableFeatureResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.FeatureField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}