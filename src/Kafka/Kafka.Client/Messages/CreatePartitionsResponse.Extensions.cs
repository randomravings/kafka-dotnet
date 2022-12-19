using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatePartitionsTopicResult = Kafka.Client.Messages.CreatePartitionsResponse.CreatePartitionsTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsResponseSerde
    {
        private static readonly DecodeDelegate<CreatePartitionsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<CreatePartitionsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static CreatePartitionsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreatePartitionsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreatePartitionsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, ref index, CreatePartitionsTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreatePartitionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV00);
            return index;
        }
        private static CreatePartitionsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, ref index, CreatePartitionsTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreatePartitionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV01);
            return index;
        }
        private static CreatePartitionsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, ref index, CreatePartitionsTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreatePartitionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreatePartitionsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, ref index, CreatePartitionsTopicResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreatePartitionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CreatePartitionsTopicResultSerde
        {
            public static CreatePartitionsTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV00(byte[] buffer, int index, CreatePartitionsTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatePartitionsTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV01(byte[] buffer, int index, CreatePartitionsTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatePartitionsTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV02(byte[] buffer, int index, CreatePartitionsTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatePartitionsTopicResult ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV03(byte[] buffer, int index, CreatePartitionsTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}