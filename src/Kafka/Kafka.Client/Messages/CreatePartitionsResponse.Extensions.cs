using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatePartitionsTopicResult = Kafka.Client.Messages.CreatePartitionsResponse.CreatePartitionsTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsResponseSerde
    {
        private static readonly Func<Stream, CreatePartitionsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreatePartitionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreatePartitionsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreatePartitionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreatePartitionsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, b => CreatePartitionsTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, CreatePartitionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, message.ResultsField, (b, i) => CreatePartitionsTopicResultSerde.WriteV00(b, i));
        }
        private static CreatePartitionsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, b => CreatePartitionsTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, CreatePartitionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, message.ResultsField, (b, i) => CreatePartitionsTopicResultSerde.WriteV01(b, i));
        }
        private static CreatePartitionsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, b => CreatePartitionsTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, CreatePartitionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, message.ResultsField, (b, i) => CreatePartitionsTopicResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreatePartitionsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, b => CreatePartitionsTopicResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV03(Stream buffer, CreatePartitionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, message.ResultsField, (b, i) => CreatePartitionsTopicResultSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CreatePartitionsTopicResultSerde
        {
            public static CreatePartitionsTopicResult ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV00(Stream buffer, CreatePartitionsTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatePartitionsTopicResult ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV01(Stream buffer, CreatePartitionsTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatePartitionsTopicResult ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV02(Stream buffer, CreatePartitionsTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatePartitionsTopicResult ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV03(Stream buffer, CreatePartitionsTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}