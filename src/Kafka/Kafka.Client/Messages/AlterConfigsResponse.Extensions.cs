using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterConfigsResourceResponse = Kafka.Client.Messages.AlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsResponseSerde
    {
        private static readonly DecodeDelegate<AlterConfigsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<AlterConfigsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static AlterConfigsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterConfigsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterConfigsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, ref index, AlterConfigsResourceResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV00);
            return index;
        }
        private static AlterConfigsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, ref index, AlterConfigsResourceResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV01);
            return index;
        }
        private static AlterConfigsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<AlterConfigsResourceResponse>(buffer, ref index, AlterConfigsResourceResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AlterConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterConfigsResourceResponseSerde
        {
            public static AlterConfigsResourceResponse ReadV00(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField
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
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AlterConfigsResourceResponse message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                return index;
            }
            public static AlterConfigsResourceResponse ReadV02(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AlterConfigsResourceResponse message)
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