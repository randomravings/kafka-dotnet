using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeTransactionsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeTransactionsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeTransactionsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeTransactionsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeTransactionsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var transactionStatesField = Decoder.ReadCompactArray<TransactionState>(ref buffer, (ref ReadOnlyMemory<byte> b) => TransactionStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionStates'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                transactionStatesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeTransactionsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<TransactionState>(buffer, message.TransactionStatesField, (b, i) => TransactionStateSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TransactionStateSerde
        {
            public static TransactionState ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var transactionalIdField = Decoder.ReadCompactString(ref buffer);
                var transactionStateField = Decoder.ReadCompactString(ref buffer);
                var transactionTimeoutMsField = Decoder.ReadInt32(ref buffer);
                var transactionStartTimeMsField = Decoder.ReadInt64(ref buffer);
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var producerEpochField = Decoder.ReadInt16(ref buffer);
                var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV00(Memory<byte> buffer, TransactionState message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactString(buffer, message.TransactionalIdField);
                buffer = Encoder.WriteCompactString(buffer, message.TransactionStateField);
                buffer = Encoder.WriteInt32(buffer, message.TransactionTimeoutMsField);
                buffer = Encoder.WriteInt64(buffer, message.TransactionStartTimeMsField);
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
                buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class TopicDataSerde
            {
                public static TopicData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var topicField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        topicField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, TopicData message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}