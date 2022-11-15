using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterConfigsResourceResponse = Kafka.Client.Messages.AlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsResponseSerde
    {
        private static readonly Func<Stream, AlterConfigsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterConfigsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterConfigsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterConfigsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterConfigsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, b => AlterConfigsResourceResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV00(Stream buffer, AlterConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, message.ResponsesField, (b, i) => AlterConfigsResourceResponseSerde.WriteV00(b, i));
        }
        private static AlterConfigsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, b => AlterConfigsResourceResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV01(Stream buffer, AlterConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, message.ResponsesField, (b, i) => AlterConfigsResourceResponseSerde.WriteV01(b, i));
        }
        private static AlterConfigsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<AlterConfigsResourceResponse>(buffer, b => AlterConfigsResourceResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV02(Stream buffer, AlterConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AlterConfigsResourceResponse>(buffer, message.ResponsesField, (b, i) => AlterConfigsResourceResponseSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AlterConfigsResourceResponseSerde
        {
            public static AlterConfigsResourceResponse ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static void WriteV00(Stream buffer, AlterConfigsResourceResponse message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
            }
            public static AlterConfigsResourceResponse ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static void WriteV01(Stream buffer, AlterConfigsResourceResponse message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
            }
            public static AlterConfigsResourceResponse ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static void WriteV02(Stream buffer, AlterConfigsResourceResponse message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}