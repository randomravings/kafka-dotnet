using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetForLeaderTopic = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic;
using OffsetForLeaderPartition = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic.OffsetForLeaderPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochRequestSerde
    {
        private static readonly Func<Stream, OffsetForLeaderEpochRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, OffsetForLeaderEpochRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static OffsetForLeaderEpochRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetForLeaderEpochRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetForLeaderEpochRequest ReadV00(Stream buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, b => OffsetForLeaderTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetForLeaderEpochRequest message)
        {
            Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV00(b, i));
        }
        private static OffsetForLeaderEpochRequest ReadV01(Stream buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, b => OffsetForLeaderTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, OffsetForLeaderEpochRequest message)
        {
            Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV01(b, i));
        }
        private static OffsetForLeaderEpochRequest ReadV02(Stream buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, b => OffsetForLeaderTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, OffsetForLeaderEpochRequest message)
        {
            Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV02(b, i));
        }
        private static OffsetForLeaderEpochRequest ReadV03(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, b => OffsetForLeaderTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, OffsetForLeaderEpochRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV03(b, i));
        }
        private static OffsetForLeaderEpochRequest ReadV04(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopic>(buffer, b => OffsetForLeaderTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, OffsetForLeaderEpochRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteCompactArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetForLeaderTopicSerde
        {
            public static OffsetForLeaderTopic ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, b => OffsetForLeaderPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetForLeaderTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV00(b, i));
            }
            public static OffsetForLeaderTopic ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, b => OffsetForLeaderPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, OffsetForLeaderTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV01(b, i));
            }
            public static OffsetForLeaderTopic ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, b => OffsetForLeaderPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, OffsetForLeaderTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV02(b, i));
            }
            public static OffsetForLeaderTopic ReadV03(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, b => OffsetForLeaderPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, OffsetForLeaderTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV03(b, i));
            }
            public static OffsetForLeaderTopic ReadV04(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetForLeaderPartition>(buffer, b => OffsetForLeaderPartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, OffsetForLeaderTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV04(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetForLeaderPartitionSerde
            {
                public static OffsetForLeaderPartition ReadV00(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetForLeaderPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static OffsetForLeaderPartition ReadV01(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static void WriteV01(Stream buffer, OffsetForLeaderPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static OffsetForLeaderPartition ReadV02(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static void WriteV02(Stream buffer, OffsetForLeaderPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static OffsetForLeaderPartition ReadV03(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static void WriteV03(Stream buffer, OffsetForLeaderPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                }
                public static OffsetForLeaderPartition ReadV04(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static void WriteV04(Stream buffer, OffsetForLeaderPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}