using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteTopicsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
        };
        private static readonly EncodeDelegate<DeleteTopicsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
        };
        public static DeleteTopicsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteTopicsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteTopicsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV00);
            return index;
        }
        private static DeleteTopicsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV01);
            return index;
        }
        private static DeleteTopicsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV02);
            return index;
        }
        private static DeleteTopicsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV03);
            return index;
        }
        private static DeleteTopicsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteTopicsResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV05(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteTopicsResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, ref index, DeletableTopicResultSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                responsesField
            );
        }
        private static int WriteV06(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeletableTopicResultSerde
        {
            public static DeletableTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = default(string?);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = default(string?);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = default(string?);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableTopicResult ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = default(string?);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableTopicResult ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = default(string?);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV04(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DeletableTopicResult ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV05(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DeletableTopicResult ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactNullableString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    TopicIdField,
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV06(byte[] buffer, int index, DeletableTopicResult message)
            {
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}