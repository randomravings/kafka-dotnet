using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse;
using ProducerState = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse.ProducerState;
using PartitionResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeProducersResponseSerde
    {
        private static readonly DecodeDelegate<DescribeProducersResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeProducersResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeProducersResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeProducersResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeProducersResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicResponse>(buffer, ref index, TopicResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeProducersResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<TopicResponse>(buffer, index, message.TopicsField, TopicResponseSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicResponseSerde
        {
            public static TopicResponse ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<PartitionResponse>(buffer, ref index, PartitionResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<PartitionResponse>(buffer, index, message.PartitionsField, PartitionResponseSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionResponseSerde
            {
                public static PartitionResponse ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var activeProducersField = Decoder.ReadCompactArray<ProducerState>(buffer, ref index, ProducerStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'ActiveProducers'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField,
                        activeProducersField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteCompactArray<ProducerState>(buffer, index, message.ActiveProducersField, ProducerStateSerde.WriteV00);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class ProducerStateSerde
                {
                    public static ProducerState ReadV00(byte[] buffer, ref int index)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer, ref index);
                        var producerEpochField = Decoder.ReadInt32(buffer, ref index);
                        var lastSequenceField = Decoder.ReadInt32(buffer, ref index);
                        var lastTimestampField = Decoder.ReadInt64(buffer, ref index);
                        var coordinatorEpochField = Decoder.ReadInt32(buffer, ref index);
                        var currentTxnStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            producerIdField,
                            producerEpochField,
                            lastSequenceField,
                            lastTimestampField,
                            coordinatorEpochField,
                            currentTxnStartOffsetField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, ProducerState message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt32(buffer, index, message.ProducerEpochField);
                        index = Encoder.WriteInt32(buffer, index, message.LastSequenceField);
                        index = Encoder.WriteInt64(buffer, index, message.LastTimestampField);
                        index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
                        index = Encoder.WriteInt64(buffer, index, message.CurrentTxnStartOffsetField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}