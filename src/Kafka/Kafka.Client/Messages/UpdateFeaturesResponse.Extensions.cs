using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using UpdatableFeatureResult = Kafka.Client.Messages.UpdateFeaturesResponse.UpdatableFeatureResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesResponseSerde
    {
        private static readonly DecodeDelegate<UpdateFeaturesResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<UpdateFeaturesResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static UpdateFeaturesResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UpdateFeaturesResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UpdateFeaturesResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, ref index, UpdatableFeatureResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UpdateFeaturesResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, index, message.ResultsField, UpdatableFeatureResultSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateFeaturesResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, ref index, UpdatableFeatureResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, UpdateFeaturesResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, index, message.ResultsField, UpdatableFeatureResultSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class UpdatableFeatureResultSerde
        {
            public static UpdatableFeatureResult ReadV00(byte[] buffer, ref int index)
            {
                var FeatureField = Decoder.ReadCompactString(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    FeatureField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV00(byte[] buffer, int index, UpdatableFeatureResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static UpdatableFeatureResult ReadV01(byte[] buffer, ref int index)
            {
                var FeatureField = Decoder.ReadCompactString(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    FeatureField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV01(byte[] buffer, int index, UpdatableFeatureResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}