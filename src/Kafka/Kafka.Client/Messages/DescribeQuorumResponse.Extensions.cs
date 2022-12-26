using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData.PartitionData;
using ReplicaState = Kafka.Client.Messages.DescribeQuorumResponse.ReplicaState;
using TopicData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeQuorumResponseSerde
    {
        private static readonly DecodeDelegate<DescribeQuorumResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<DescribeQuorumResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static DescribeQuorumResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeQuorumResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeQuorumResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeQuorumResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeQuorumResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicData>(buffer, ref index, TopicDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeQuorumResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ReplicaStateSerde
        {
            public static ReplicaState ReadV00(byte[] buffer, ref int index)
            {
                var ReplicaIdField = Decoder.ReadInt32(buffer, ref index);
                var LogEndOffsetField = Decoder.ReadInt64(buffer, ref index);
                var LastFetchTimestampField = default(long);
                var LastCaughtUpTimestampField = default(long);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ReplicaIdField,
                    LogEndOffsetField,
                    LastFetchTimestampField,
                    LastCaughtUpTimestampField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ReplicaState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
                index = Encoder.WriteInt64(buffer, index, message.LogEndOffsetField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static ReplicaState ReadV01(byte[] buffer, ref int index)
            {
                var ReplicaIdField = Decoder.ReadInt32(buffer, ref index);
                var LogEndOffsetField = Decoder.ReadInt64(buffer, ref index);
                var LastFetchTimestampField = Decoder.ReadInt64(buffer, ref index);
                var LastCaughtUpTimestampField = Decoder.ReadInt64(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ReplicaIdField,
                    LogEndOffsetField,
                    LastFetchTimestampField,
                    LastCaughtUpTimestampField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ReplicaState message)
            {
                index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
                index = Encoder.WriteInt64(buffer, index, message.LogEndOffsetField);
                index = Encoder.WriteInt64(buffer, index, message.LastFetchTimestampField);
                index = Encoder.WriteInt64(buffer, index, message.LastCaughtUpTimestampField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class TopicDataSerde
        {
            public static TopicData ReadV00(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static TopicData ReadV01(byte[] buffer, ref int index)
            {
                var TopicNameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicNameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var CurrentVotersField = Decoder.ReadCompactArray<ReplicaState>(buffer, ref index, ReplicaStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var ObserversField = Decoder.ReadCompactArray<ReplicaState>(buffer, ref index, ReplicaStateSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        LeaderIdField,
                        LeaderEpochField,
                        HighWatermarkField,
                        CurrentVotersField,
                        ObserversField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.CurrentVotersField, ReplicaStateSerde.WriteV00);
                    index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.ObserversField, ReplicaStateSerde.WriteV00);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static PartitionData ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var CurrentVotersField = Decoder.ReadCompactArray<ReplicaState>(buffer, ref index, ReplicaStateSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                    var ObserversField = Decoder.ReadCompactArray<ReplicaState>(buffer, ref index, ReplicaStateSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Observers'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        LeaderIdField,
                        LeaderEpochField,
                        HighWatermarkField,
                        CurrentVotersField,
                        ObserversField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.CurrentVotersField, ReplicaStateSerde.WriteV01);
                    index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.ObserversField, ReplicaStateSerde.WriteV01);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}