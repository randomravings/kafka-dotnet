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
        private static readonly Func<Stream, DescribeProducersResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeProducersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeProducersResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeProducersResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeProducersResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicResponse>(buffer, b => TopicResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeProducersResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<TopicResponse>(buffer, message.TopicsField, (b, i) => TopicResponseSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicResponseSerde
        {
            public static TopicResponse ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionResponse>(buffer, b => PartitionResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicResponse message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<PartitionResponse>(buffer, message.PartitionsField, (b, i) => PartitionResponseSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionResponseSerde
            {
                public static PartitionResponse ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    var activeProducersField = Decoder.ReadCompactArray<ProducerState>(buffer, b => ProducerStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'ActiveProducers'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField,
                        activeProducersField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteCompactArray<ProducerState>(buffer, message.ActiveProducersField, (b, i) => ProducerStateSerde.WriteV00(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class ProducerStateSerde
                {
                    public static ProducerState ReadV00(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var producerEpochField = Decoder.ReadInt32(buffer);
                        var lastSequenceField = Decoder.ReadInt32(buffer);
                        var lastTimestampField = Decoder.ReadInt64(buffer);
                        var coordinatorEpochField = Decoder.ReadInt32(buffer);
                        var currentTxnStartOffsetField = Decoder.ReadInt64(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            producerIdField,
                            producerEpochField,
                            lastSequenceField,
                            lastTimestampField,
                            coordinatorEpochField,
                            currentTxnStartOffsetField
                        );
                    }
                    public static void WriteV00(Stream buffer, ProducerState message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt32(buffer, message.ProducerEpochField);
                        Encoder.WriteInt32(buffer, message.LastSequenceField);
                        Encoder.WriteInt64(buffer, message.LastTimestampField);
                        Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
                        Encoder.WriteInt64(buffer, message.CurrentTxnStartOffsetField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}