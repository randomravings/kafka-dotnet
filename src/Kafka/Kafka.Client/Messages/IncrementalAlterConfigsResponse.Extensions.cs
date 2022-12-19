using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterConfigsResourceResponse = Kafka.Client.Messages.IncrementalAlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class IncrementalAlterConfigsResponseSerde
    {
        private static readonly DecodeDelegate<IncrementalAlterConfigsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<IncrementalAlterConfigsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static IncrementalAlterConfigsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, IncrementalAlterConfigsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static IncrementalAlterConfigsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, ref index, AlterConfigsResourceResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, IncrementalAlterConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV00);
            return index;
        }
        private static IncrementalAlterConfigsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<AlterConfigsResourceResponse>(buffer, ref index, AlterConfigsResourceResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, IncrementalAlterConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterConfigsResourceResponseSerde
        {
            public static AlterConfigsResourceResponse ReadV00(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AlterConfigsResourceResponse message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                return index;
            }
            public static AlterConfigsResourceResponse ReadV01(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AlterConfigsResourceResponse message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}