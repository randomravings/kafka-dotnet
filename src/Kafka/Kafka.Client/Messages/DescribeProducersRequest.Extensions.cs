using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicRequest = Kafka.Client.Messages.DescribeProducersRequest.TopicRequest;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeProducersRequestSerde
    {
        private static readonly DecodeDelegate<DescribeProducersRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeProducersRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeProducersRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeProducersRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeProducersRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<TopicRequest>(buffer, ref index, TopicRequestSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeProducersRequest message)
        {
            index = Encoder.WriteCompactArray<TopicRequest>(buffer, index, message.TopicsField, TopicRequestSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicRequestSerde
        {
            public static TopicRequest ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionIndexesField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicRequest message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}