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
        private static readonly DecodeDelegate<ProduceResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
        };
        private static readonly EncodeDelegate<ProduceResponse>[] WRITE_VERSIONS = {
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
        public static ProduceResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ProduceResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ProduceResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = default(int);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV00(b, i));
            return buffer;
        }
        private static ProduceResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV04(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV05(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV06(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV07(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV08(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            return buffer;
        }
        private static ProduceResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var responsesField = Decoder.ReadCompactArray<TopicProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceResponseSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                responsesField,
                throttleTimeMsField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, ProduceResponse message)
        {
            buffer = Encoder.WriteCompactArray<TopicProduceResponse>(buffer, message.ResponsesField, (b, i) => TopicProduceResponseSerde.WriteV09(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicProduceResponseSerde
        {
            public static TopicProduceResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV00(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV01(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV02(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV03(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV04(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV05(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV06(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV07(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionResponsesField = Decoder.ReadArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV08(b, i));
                return buffer;
            }
            public static TopicProduceResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionResponsesField = Decoder.ReadCompactArray<PartitionProduceResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceResponseSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionResponsesField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, TopicProduceResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<PartitionProduceResponse>(buffer, message.PartitionResponsesField, (b, i) => PartitionProduceResponseSerde.WriteV09(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionProduceResponseSerde
            {
                public static PartitionProduceResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV02(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV03(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV04(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV05(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV06(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
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
                public static Memory<byte> WriteV07(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var recordErrorsField = Decoder.ReadArray<BatchIndexAndErrorMessage>(ref buffer, (ref ReadOnlyMemory<byte> b) => BatchIndexAndErrorMessageSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadNullableString(ref buffer);
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
                public static Memory<byte> WriteV08(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<BatchIndexAndErrorMessage>(buffer, message.RecordErrorsField, (b, i) => BatchIndexAndErrorMessageSerde.WriteV08(b, i));
                    buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    return buffer;
                }
                public static PartitionProduceResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var baseOffsetField = Decoder.ReadInt64(ref buffer);
                    var logAppendTimeMsField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var recordErrorsField = Decoder.ReadCompactArray<BatchIndexAndErrorMessage>(ref buffer, (ref ReadOnlyMemory<byte> b) => BatchIndexAndErrorMessageSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV09(Memory<byte> buffer, PartitionProduceResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.BaseOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogAppendTimeMsField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteCompactArray<BatchIndexAndErrorMessage>(buffer, message.RecordErrorsField, (b, i) => BatchIndexAndErrorMessageSerde.WriteV09(b, i));
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class BatchIndexAndErrorMessageSerde
                {
                    public static BatchIndexAndErrorMessage ReadV08(ref ReadOnlyMemory<byte> buffer)
                    {
                        var batchIndexField = Decoder.ReadInt32(ref buffer);
                        var batchIndexErrorMessageField = Decoder.ReadNullableString(ref buffer);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static Memory<byte> WriteV08(Memory<byte> buffer, BatchIndexAndErrorMessage message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.BatchIndexField);
                        buffer = Encoder.WriteNullableString(buffer, message.BatchIndexErrorMessageField);
                        return buffer;
                    }
                    public static BatchIndexAndErrorMessage ReadV09(ref ReadOnlyMemory<byte> buffer)
                    {
                        var batchIndexField = Decoder.ReadInt32(ref buffer);
                        var batchIndexErrorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            batchIndexField,
                            batchIndexErrorMessageField
                        );
                    }
                    public static Memory<byte> WriteV09(Memory<byte> buffer, BatchIndexAndErrorMessage message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.BatchIndexField);
                        buffer = Encoder.WriteCompactNullableString(buffer, message.BatchIndexErrorMessageField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}