using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData;
using ReplicaState = Kafka.Client.Messages.DescribeQuorumResponse.ReplicaState;
using PartitionData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeQuorumResponseSerde
    {
        private static readonly DecodeDelegate<DescribeQuorumResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<DescribeQuorumResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeQuorumResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeQuorumResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeQuorumResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeQuorumResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeQuorumResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeQuorumResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<TopicData>(buffer, message.TopicsField, (b, i) => TopicDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static TopicData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var currentVotersField = Decoder.ReadCompactArray<ReplicaState>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var observersField = Decoder.ReadCompactArray<ReplicaState>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaStateSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteCompactArray<ReplicaState>(buffer, message.CurrentVotersField, (b, i) => ReplicaStateSerde.WriteV00(b, i));
                    buffer = Encoder.WriteCompactArray<ReplicaState>(buffer, message.ObserversField, (b, i) => ReplicaStateSerde.WriteV00(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static PartitionData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var leaderIdField = Decoder.ReadInt32(ref buffer);
                    var leaderEpochField = Decoder.ReadInt32(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var currentVotersField = Decoder.ReadCompactArray<ReplicaState>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaStateSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var observersField = Decoder.ReadCompactArray<ReplicaState>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaStateSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                    buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteCompactArray<ReplicaState>(buffer, message.CurrentVotersField, (b, i) => ReplicaStateSerde.WriteV01(b, i));
                    buffer = Encoder.WriteCompactArray<ReplicaState>(buffer, message.ObserversField, (b, i) => ReplicaStateSerde.WriteV01(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
        private static class ReplicaStateSerde
        {
            public static ReplicaState ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var replicaIdField = Decoder.ReadInt32(ref buffer);
                var logEndOffsetField = Decoder.ReadInt64(ref buffer);
                var lastFetchTimestampField = default(long);
                var lastCaughtUpTimestampField = default(long);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    replicaIdField,
                    logEndOffsetField,
                    lastFetchTimestampField,
                    lastCaughtUpTimestampField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ReplicaState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
                buffer = Encoder.WriteInt64(buffer, message.LogEndOffsetField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static ReplicaState ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var replicaIdField = Decoder.ReadInt32(ref buffer);
                var logEndOffsetField = Decoder.ReadInt64(ref buffer);
                var lastFetchTimestampField = Decoder.ReadInt64(ref buffer);
                var lastCaughtUpTimestampField = Decoder.ReadInt64(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    replicaIdField,
                    logEndOffsetField,
                    lastFetchTimestampField,
                    lastCaughtUpTimestampField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ReplicaState message)
            {
                buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
                buffer = Encoder.WriteInt64(buffer, message.LogEndOffsetField);
                buffer = Encoder.WriteInt64(buffer, message.LastFetchTimestampField);
                buffer = Encoder.WriteInt64(buffer, message.LastCaughtUpTimestampField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}