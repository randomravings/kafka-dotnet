using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReplicaState = Kafka.Client.Messages.DescribeQuorumResponse.ReplicaState;
using TopicData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData;
using PartitionData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeQuorumResponseSerde
    {
        private static readonly Func<Stream, DescribeQuorumResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, DescribeQuorumResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeQuorumResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeQuorumResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeQuorumResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeQuorumResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeQuorumResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, b => TopicDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeQuorumResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ReplicaStateSerde
        {
            public static ReplicaState ReadV00(Stream buffer)
            {
                var replicaIdField = Decoder.ReadInt32(buffer);
                var logEndOffsetField = Decoder.ReadInt64(buffer);
                var lastFetchTimestampField = default(long);
                var lastCaughtUpTimestampField = default(long);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    replicaIdField,
                    logEndOffsetField,
                    lastFetchTimestampField,
                    lastCaughtUpTimestampField
                );
            }
            public static void WriteV00(Stream buffer, ReplicaState message)
            {
                Encoder.WriteInt32(buffer, message.ReplicaIdField);
                Encoder.WriteInt64(buffer, message.LogEndOffsetField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static ReplicaState ReadV01(Stream buffer)
            {
                var replicaIdField = Decoder.ReadInt32(buffer);
                var logEndOffsetField = Decoder.ReadInt64(buffer);
                var lastFetchTimestampField = Decoder.ReadInt64(buffer);
                var lastCaughtUpTimestampField = Decoder.ReadInt64(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    replicaIdField,
                    logEndOffsetField,
                    lastFetchTimestampField,
                    lastCaughtUpTimestampField
                );
            }
            public static void WriteV01(Stream buffer, ReplicaState message)
            {
                Encoder.WriteInt32(buffer, message.ReplicaIdField);
                Encoder.WriteInt64(buffer, message.LogEndOffsetField);
                Encoder.WriteInt64(buffer, message.LastFetchTimestampField);
                Encoder.WriteInt64(buffer, message.LastCaughtUpTimestampField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
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
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var currentVotersField = Decoder.ReadCompactArray<ReplicaState>(buffer, b => ReplicaStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var observersField = Decoder.ReadCompactArray<ReplicaState>(buffer, b => ReplicaStateSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        highWatermarkField,
                        currentVotersField,
                        observersField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteCompactArray<ReplicaState>(buffer, message.CurrentVotersField, (b, i) => ReplicaStateSerde.WriteV00(b, i));
                    Encoder.WriteCompactArray<ReplicaState>(buffer, message.ObserversField, (b, i) => ReplicaStateSerde.WriteV00(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var leaderIdField = Decoder.ReadInt32(buffer);
                    var leaderEpochField = Decoder.ReadInt32(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var currentVotersField = Decoder.ReadCompactArray<ReplicaState>(buffer, b => ReplicaStateSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var observersField = Decoder.ReadCompactArray<ReplicaState>(buffer, b => ReplicaStateSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        leaderIdField,
                        leaderEpochField,
                        highWatermarkField,
                        currentVotersField,
                        observersField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt32(buffer, message.LeaderIdField);
                    Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteCompactArray<ReplicaState>(buffer, message.CurrentVotersField, (b, i) => ReplicaStateSerde.WriteV01(b, i));
                    Encoder.WriteCompactArray<ReplicaState>(buffer, message.ObserversField, (b, i) => ReplicaStateSerde.WriteV01(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}