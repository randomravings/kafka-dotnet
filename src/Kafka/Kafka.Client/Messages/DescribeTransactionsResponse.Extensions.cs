using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;

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
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var TransactionalIdField = Decoder.ReadCompactString(buffer, ref index);
                var TransactionStateField = Decoder.ReadCompactString(buffer, ref index);
                var TransactionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
                var TransactionStartTimeMsField = Decoder.ReadInt64(buffer, ref index);
                var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                var ProducerEpochField = Decoder.ReadInt16(buffer, ref index);
                var TopicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    TransactionalIdField,
                    TransactionStateField,
                    TransactionTimeoutMsField,
                    TransactionStartTimeMsField,
                    ProducerIdField,
                    ProducerEpochField,
                    TopicsField
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
                    var TopicField = Decoder.ReadCompactString(buffer, ref index);
                    var PartitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        TopicField,
                        PartitionsField
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