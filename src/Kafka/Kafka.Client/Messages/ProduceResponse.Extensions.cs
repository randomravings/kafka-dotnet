using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceResponseSerde
    {
        private static readonly Func<Stream, ProduceResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
        };
        private static readonly Action<Stream, ProduceResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
        };
        public static ProduceResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ProduceResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ProduceResponse ReadV00(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = default(int);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV00(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV00(b, i));
        }
        private static ProduceResponse ReadV01(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV01(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV02(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV02(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV03(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV03(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV03(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV04(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV04(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV04(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV05(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV05(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV05(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV06(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV06(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV06(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV07(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV07(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV07(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV08(Stream buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV08(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV08(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
        private static ProduceResponse ReadV09(Stream buffer)
        {
            var responsesField = Decoder.ReadCompactArray<TopicProduceResponse>(buffer, b => TopicProduceResponseSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static void WriteV09(Stream buffer, ProduceResponse message)
        {
            Encoder.WriteCompactArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV09(b, i));
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicProduceResponseSerde
        {
            public static TopicProduceResponse ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV00(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV00(b, i));
            }
            public static TopicProduceResponse ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV01(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV01(b, i));
            }
            public static TopicProduceResponse ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV02(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV02(b, i));
            }
            public static TopicProduceResponse ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV03(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV03(b, i));
            }
            public static TopicProduceResponse ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV04(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV04(b, i));
            }
            public static TopicProduceResponse ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV05(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV05(b, i));
            }
            public static TopicProduceResponse ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV06(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV06(b, i));
            }
            public static TopicProduceResponse ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV07(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV07(b, i));
            }
            public static TopicProduceResponse ReadV08(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV08(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV08(b, i));
            }
            public static TopicProduceResponse ReadV09(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionResponsesField = Decoder.ReadCompactArray<PartitionProduceResponse>(buffer, b => PartitionProduceResponseSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static void WriteV09(Stream buffer, TopicProduceResponse message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV09(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionProduceResponseSerde
            {
                public static PartitionProduceResponse ReadV00(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                }
                public static PartitionProduceResponse ReadV01(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                }
                public static PartitionProduceResponse ReadV02(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                }
                public static PartitionProduceResponse ReadV03(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV03(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                }
                public static PartitionProduceResponse ReadV04(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV04(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                }
                public static PartitionProduceResponse ReadV05(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV05(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                }
                public static PartitionProduceResponse ReadV06(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV06(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                }
                public static PartitionProduceResponse ReadV07(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV07(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                }
                public static PartitionProduceResponse ReadV08(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var recordErrorsField = Decoder.ReadArray<BatchIndexAndErrorMessage>(buffer, b => BatchIndexAndErrorMessageSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadNullableString(buffer);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV08(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<BatchIndexAndErrorMessage>(buffer, message.RecordErrorsField, (b, i) => BatchIndexAndErrorMessageSerde.WriteV08(b, i));
                    Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                }
                public static PartitionProduceResponse ReadV09(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var baseOffsetField = Decoder.ReadInt64(buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var recordErrorsField = Decoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, b => BatchIndexAndErrorMessageSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField
                    );
                }
                public static void WriteV09(Stream buffer, PartitionProduceResponse message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteCompactArray<BatchIndexAndErrorMessage>(buffer, message.RecordErrorsField, (b, i) => BatchIndexAndErrorMessageSerde.WriteV09(b, i));
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class BatchIndexAndErrorMessageSerde
                {
                    public static BatchIndexAndErrorMessage ReadV08(Stream buffer)
                    {
                        var batchIndexField = Decoder.ReadInt32(buffer);
                        var batchIndexErrorMessageField = Decoder.ReadNullableString(buffer);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static void WriteV08(Stream buffer, BatchIndexAndErrorMessage message)
                    {
                        Encoder.WriteInt32(buffer, message.BatchIndexField);
                        Encoder.WriteNullableString(buffer, message.BatchIndexErrorMessageField);
                    }
                    public static BatchIndexAndErrorMessage ReadV09(Stream buffer)
                    {
                        var batchIndexField = Decoder.ReadInt32(buffer);
                        var batchIndexErrorMessageField = Decoder.ReadCompactNullableString(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static void WriteV09(Stream buffer, BatchIndexAndErrorMessage message)
                    {
                        Encoder.WriteInt32(buffer, message.BatchIndexField);
                        Encoder.WriteCompactNullableString(buffer, message.BatchIndexErrorMessageField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}