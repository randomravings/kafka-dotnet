using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicRequest = Kafka.Client.Messages.DescribeProducersRequest.TopicRequest;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeProducersRequestSerde
    {
        private static readonly Func<Stream, DescribeProducersRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeProducersRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeProducersRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeProducersRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeProducersRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<TopicRequest>(buffer, b => TopicRequestSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeProducersRequest message)
        {
            Encoder.WriteCompactArray<TopicRequest>(buffer, message.TopicsField, (b, i) => TopicRequestSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicRequestSerde
        {
            public static TopicRequest ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV00(Stream buffer, TopicRequest message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}