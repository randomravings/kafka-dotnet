using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceResponseSerde
    {
        private static readonly DecodeDelegate<ProduceResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
        };
        private static readonly EncodeDelegate<ProduceResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
        };
        public static ProduceResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ProduceResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ProduceResponse ReadV00(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = default(int);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV00);
            return index;
        }
        private static ProduceResponse ReadV01(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV02(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV03(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV03);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV04(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV04);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV05(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV05);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV06(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV06);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV07(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV07);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV08(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV08);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static ProduceResponse ReadV09(byte[] buffer, ref int index)
        {
            var responsesField = Decoder.ReadCompactArray<TopicProduceResponse>(buffer, ref index, TopicProduceResponseSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static int WriteV09(byte[] buffer, int index, ProduceResponse message)
        {
            index = Encoder.WriteCompactArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV09);
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicProduceResponseSerde
        {
            public static TopicProduceResponse ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV00);
                return index;
            }
            public static TopicProduceResponse ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV01);
                return index;
            }
            public static TopicProduceResponse ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV02);
                return index;
            }
            public static TopicProduceResponse ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV03(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV03);
                return index;
            }
            public static TopicProduceResponse ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV04(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV04);
                return index;
            }
            public static TopicProduceResponse ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV05(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV05);
                return index;
            }
            public static TopicProduceResponse ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV06(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV06);
                return index;
            }
            public static TopicProduceResponse ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV07(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV07);
                return index;
            }
            public static TopicProduceResponse ReadV08(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV08(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV08);
                return index;
            }
            public static TopicProduceResponse ReadV09(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionResponsesField = Decoder.ReadCompactArray<PartitionProduceResponse>(buffer, ref index, PartitionProduceResponseSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static int WriteV09(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV09);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionProduceResponseSerde
            {
                public static PartitionProduceResponse ReadV00(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV00(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    return index;
                }
                public static PartitionProduceResponse ReadV01(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV01(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    return index;
                }
                public static PartitionProduceResponse ReadV02(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV02(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    return index;
                }
                public static PartitionProduceResponse ReadV03(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV03(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    return index;
                }
                public static PartitionProduceResponse ReadV04(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV04(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    return index;
                }
                public static PartitionProduceResponse ReadV05(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV05(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    return index;
                }
                public static PartitionProduceResponse ReadV06(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV06(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    return index;
                }
                public static PartitionProduceResponse ReadV07(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
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
                public static int WriteV07(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    return index;
                }
                public static PartitionProduceResponse ReadV08(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var recordErrorsField = Decoder.ReadArray<BatchIndexAndErrorMessage>(buffer, ref index, BatchIndexAndErrorMessageSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
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
                public static int WriteV08(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV08);
                    index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                    return index;
                }
                public static PartitionProduceResponse ReadV09(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var baseOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var logAppendTimeMsField = Decoder.ReadInt64(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var recordErrorsField = Decoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, ref index, BatchIndexAndErrorMessageSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV09(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteCompactArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV09);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class BatchIndexAndErrorMessageSerde
                {
                    public static BatchIndexAndErrorMessage ReadV08(byte[] buffer, ref int index)
                    {
                        var batchIndexField = Decoder.ReadInt32(buffer, ref index);
                        var batchIndexErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static int WriteV08(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.BatchIndexField);
                        index = Encoder.WriteNullableString(buffer, index, message.BatchIndexErrorMessageField);
                        return index;
                    }
                    public static BatchIndexAndErrorMessage ReadV09(byte[] buffer, ref int index)
                    {
                        var batchIndexField = Decoder.ReadInt32(buffer, ref index);
                        var batchIndexErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static int WriteV09(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.BatchIndexField);
                        index = Encoder.WriteCompactNullableString(buffer, index, message.BatchIndexErrorMessageField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}