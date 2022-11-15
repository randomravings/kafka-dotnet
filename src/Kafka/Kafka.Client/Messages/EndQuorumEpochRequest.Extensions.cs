using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.EndQuorumEpochRequest.TopicData;
using PartitionData = Kafka.Client.Messages.EndQuorumEpochRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndQuorumEpochRequestSerde
    {
        private static readonly Func<Stream, EndQuorumEpochRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, EndQuorumEpochRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static EndQuorumEpochRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, EndQuorumEpochRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static EndQuorumEpochRequest ReadV00(Stream buffer)
        {
            var clusterIdField = Decoder.ReadNullableString(buffer);
            var topicsField = Decoder.ReadArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                clusterIdField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, EndQuorumEpochRequest message)
        {
            Encoder.WriteNullableString(buffer, message.ClusterIdField);
            Encoder.WriteArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicData message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var preferredSuccessorsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PreferredSuccessors'");
                    return new(
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        preferredSuccessorsField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteArray<int>(buffer, message.PreferredSuccessorsField, (b, i) => Encoder.WriteInt32(b, i));
                }
            }
        }
    }
}