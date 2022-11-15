using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsResponseSerde
    {
        private static readonly Func<Stream, DeleteTopicsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
        };
        private static readonly Action<Stream, DeleteTopicsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static DeleteTopicsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteTopicsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteTopicsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV00(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV00(b, i));
        }
        private static DeleteTopicsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV01(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV01(b, i));
        }
        private static DeleteTopicsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV02(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV02(b, i));
        }
        private static DeleteTopicsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV03(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV03(b, i));
        }
        private static DeleteTopicsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV04(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteTopicsResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV05(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteTopicsResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, b => DeletableTopicResultSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static void WriteV06(Stream buffer, DeleteTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeletableTopicResult>(buffer, message.ResponsesField, (b, i) => DeletableTopicResultSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeletableTopicResultSerde
        {
            public static DeletableTopicResult ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV00(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableTopicResult ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV01(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableTopicResult ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV02(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableTopicResult ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = default(string?);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV03(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableTopicResult ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = default(string?);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV04(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DeletableTopicResult ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV05(Stream buffer, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DeletableTopicResult ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactNullableString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV06(Stream buffer, DeletableTopicResult message)
            {
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}