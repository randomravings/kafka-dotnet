using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData;
using PartitionData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeQuorumRequestSerde
    {
        private static readonly Func<Stream, DescribeQuorumRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, DescribeQuorumRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeQuorumRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeQuorumRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeQuorumRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeQuorumRequest message)
        {
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeQuorumRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeQuorumRequest message)
        {
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicData message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static TopicData ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TopicData message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}