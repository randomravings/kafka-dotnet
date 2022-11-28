using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ProducerState = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse.ProducerState;
using TopicResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse;
using PartitionResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeProducersResponseSerde
    {
        private static readonly DecodeDelegate<DescribeProducersResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeProducersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeProducersResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeProducersResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeProducersResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeProducersResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<TopicResponse>(buffer, message.TopicsField, (b, i) => TopicResponseSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicResponseSerde
        {
            public static TopicResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<PartitionResponse>(buffer, message.PartitionsField, (b, i) => PartitionResponseSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionResponseSerde
            {
                public static PartitionResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    var activeProducersField = Decoder.ReadCompactArray<ProducerState>(ref buffer, (ref ReadOnlyMemory<byte> b) => ProducerStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ActiveProducers'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField,
                        activeProducersField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteCompactArray<ProducerState>(buffer, message.ActiveProducersField, (b, i) => ProducerStateSerde.WriteV00(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class ProducerStateSerde
                {
                    public static ProducerState ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var producerEpochField = Decoder.ReadInt32(ref buffer);
                        var lastSequenceField = Decoder.ReadInt32(ref buffer);
                        var lastTimestampField = Decoder.ReadInt64(ref buffer);
                        var coordinatorEpochField = Decoder.ReadInt32(ref buffer);
                        var currentTxnStartOffsetField = Decoder.ReadInt64(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            producerIdField,
                            producerEpochField,
                            lastSequenceField,
                            lastTimestampField,
                            coordinatorEpochField,
                            currentTxnStartOffsetField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, ProducerState message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt32(buffer, message.ProducerEpochField);
                        buffer = Encoder.WriteInt32(buffer, message.LastSequenceField);
                        buffer = Encoder.WriteInt64(buffer, message.LastTimestampField);
                        buffer = Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
                        buffer = Encoder.WriteInt64(buffer, message.CurrentTxnStartOffsetField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}