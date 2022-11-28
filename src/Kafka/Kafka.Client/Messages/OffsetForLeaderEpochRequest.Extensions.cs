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
        private static readonly DecodeDelegate<OffsetForLeaderEpochRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<OffsetForLeaderEpochRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static OffsetForLeaderEpochRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetForLeaderEpochRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetForLeaderEpochRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetForLeaderEpochRequest message)
        {
            buffer = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetForLeaderEpochRequest message)
        {
            buffer = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetForLeaderEpochRequest message)
        {
            buffer = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetForLeaderEpochRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static OffsetForLeaderEpochRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetForLeaderEpochRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteCompactArray<OffsetForLeaderTopic>(buffer, message.TopicsField, (b, i) => OffsetForLeaderTopicSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetForLeaderTopicSerde
        {
            public static OffsetForLeaderTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetForLeaderTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetForLeaderTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetForLeaderTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetForLeaderTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static OffsetForLeaderTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetForLeaderPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetForLeaderPartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetForLeaderTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<OffsetForLeaderPartition>(buffer, message.PartitionsField, (b, i) => OffsetForLeaderPartitionSerde.WriteV04(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetForLeaderPartitionSerde
            {
                public static OffsetForLeaderPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetForLeaderPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static OffsetForLeaderPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetForLeaderPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static OffsetForLeaderPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetForLeaderPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static OffsetForLeaderPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetForLeaderPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    return buffer;
                }
                public static OffsetForLeaderPartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        leaderEpochField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetForLeaderPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}