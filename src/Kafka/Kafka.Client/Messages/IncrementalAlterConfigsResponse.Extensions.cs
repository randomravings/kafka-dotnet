using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterConfigsResourceResponse = Kafka.Client.Messages.IncrementalAlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class IncrementalAlterConfigsResponseSerde
    {
        private static readonly DecodeDelegate<IncrementalAlterConfigsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<IncrementalAlterConfigsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static IncrementalAlterConfigsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, IncrementalAlterConfigsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static IncrementalAlterConfigsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<AlterConfigsResourceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterConfigsResourceResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, IncrementalAlterConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, message.ResponsesField, (b, i) => AlterConfigsResourceResponseSerde.WriteV00(b, i));
            return buffer;
        }
        private static IncrementalAlterConfigsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<AlterConfigsResourceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterConfigsResourceResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, IncrementalAlterConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AlterConfigsResourceResponse>(buffer, message.ResponsesField, (b, i) => AlterConfigsResourceResponseSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AlterConfigsResourceResponseSerde
        {
            public static AlterConfigsResourceResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AlterConfigsResourceResponse message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                return buffer;
            }
            public static AlterConfigsResourceResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AlterConfigsResourceResponse message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}