using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsResponseSerde
    {
        private static readonly Func<Stream, DescribeTransactionsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeTransactionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeTransactionsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeTransactionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeTransactionsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(buffer, b => TransactionStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                transactionStatesField
            );
        }
        private static void WriteV00(Stream buffer, DescribeTransactionsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<TransactionState>(buffer, message.TransactionStatesField, (b, i) => TransactionStateSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var transactionalIdField = Decoder.ReadCompactString(buffer);
                var transactionStateField = Decoder.ReadCompactString(buffer);
                var transactionTimeoutMsField = Decoder.ReadInt32(buffer);
                var transactionStartTimeMsField = Decoder.ReadInt64(buffer);
                var producerIdField = Decoder.ReadInt64(buffer);
                var producerEpochField = Decoder.ReadInt16(buffer);
                var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    transactionalIdField,
                    transactionStateField,
                    transactionTimeoutMsField,
                    transactionStartTimeMsField,
                    producerIdField,
                    producerEpochField,
                    topicsField
                );
            }
            public static void WriteV00(Stream buffer, TransactionState message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactString(buffer, message.TransactionalIdField);
                Encoder.WriteCompactString(buffer, message.TransactionStateField);
                Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
                Encoder.WriteInt64(buffer, message.TransactionStartTimeMsField);
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteInt16(buffer, message.ProducerEpochField);
                Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class TopicDataSerde
            {
                public static TopicData ReadV00(Stream buffer)
                {
                    var topicField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        topicField,
                        partitionsField
                    );
                }
                public static void WriteV00(Stream buffer, TopicData message)
                {
                    Encoder.WriteCompactString(buffer, message.TopicField);
                    Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}