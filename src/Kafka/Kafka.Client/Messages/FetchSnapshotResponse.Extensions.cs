using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotResponseSerde
    {
        private static readonly DecodeDelegate<FetchSnapshotResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<FetchSnapshotResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static FetchSnapshotResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, FetchSnapshotResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static FetchSnapshotResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(buffer, ref index, TopicSnapshotSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, FetchSnapshotResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<TopicSnapshot>(buffer, index, message.TopicsField, TopicSnapshotSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(buffer, ref index, PartitionSnapshotSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicSnapshot message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<PartitionSnapshot>(buffer, index, message.PartitionsField, PartitionSnapshotSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(byte[] buffer, ref int index)
                {
                    var IndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var SnapshotIdField = SnapshotIdSerde.ReadV00(buffer, ref index);
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SizeField = Decoder.ReadInt64(buffer, ref index);
                    var PositionField = Decoder.ReadInt64(buffer, ref index);
                    var UnalignedRecordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'UnalignedRecords'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        IndexField,
                        ErrorCodeField,
                        SnapshotIdField,
                        CurrentLeaderField,
                        SizeField,
                        PositionField,
                        UnalignedRecordsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionSnapshot message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = SnapshotIdSerde.WriteV00(buffer, index, message.SnapshotIdField);
                    index = LeaderIdAndEpochSerde.WriteV00(buffer, index, message.CurrentLeaderField);
                    index = Encoder.WriteInt64(buffer, index, message.SizeField);
                    index = Encoder.WriteInt64(buffer, index, message.PositionField);
                    index = Encoder.WriteCompactRecords(buffer, index, message.UnalignedRecordsField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(byte[] buffer, ref int index)
                    {
                        var EndOffsetField = Decoder.ReadInt64(buffer, ref index);
                        var EpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            EndOffsetField,
                            EpochField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, SnapshotId message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV00(byte[] buffer, ref int index)
                    {
                        var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                        var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            LeaderIdField,
                            LeaderEpochField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                        index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}