using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeTransactionsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeTransactionsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeTransactionsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeTransactionsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeTransactionsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(buffer, ref index, TransactionStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                transactionStatesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeTransactionsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<TransactionState>(buffer, index, message.TransactionStatesField, TransactionStateSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var transactionalIdField = Decoder.ReadCompactString(buffer, ref index);
                var transactionStateField = Decoder.ReadCompactString(buffer, ref index);
                var transactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
                var transactionStartTimeMsField = Decoder.ReadInt64(buffer, ref index);
                var producerIdField = Decoder.ReadInt64(buffer, ref index);
                var producerEpochField = Decoder.ReadInt16(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
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
            public static int WriteV00(byte[] buffer, int index, TransactionState message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
                index = Encoder.WriteCompactString(buffer, index, message.TransactionStateField);
                index = Encoder.WriteInt32(buffer, index, message.TransactionTimeoutMsField);
                index = Encoder.WriteInt64(buffer, index, message.TransactionStartTimeMsField);
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
                index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class TopicDataSerde
            {
                public static TopicData ReadV00(byte[] buffer, ref int index)
                {
                    var topicField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        topicField,
                        partitionsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, TopicData message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}