using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteTopicsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
        };
        private static readonly EncodeDelegate<DeleteTopicsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static DeleteTopicsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteTopicsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteTopicsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static DeleteTopicsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static DeleteTopicsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV02(b, i));
            return buffer;
        }
        private static DeleteTopicsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV03(b, i));
            return buffer;
        }
        private static DeleteTopicsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DeleteTopicsResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DeleteTopicsResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableTopicResultSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, DeleteTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DeletableTopicResultSerde
        {
            public static DeletableTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableTopicResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableTopicResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableTopicResult ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = default(string?);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DeletableTopicResult ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DeletableTopicResult ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, DeletableTopicResult message)
            {
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}