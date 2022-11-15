using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotResponseSerde
    {
        private static readonly Func<Stream, FetchSnapshotResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, FetchSnapshotResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static FetchSnapshotResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FetchSnapshotResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FetchSnapshotResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(buffer, b => TopicSnapshotSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, FetchSnapshotResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<TopicSnapshot>(buffer, message.TopicsField, (b, i) => TopicSnapshotSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(buffer, b => PartitionSnapshotSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicSnapshot message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<PartitionSnapshot>(buffer, message.PartitionsField, (b, i) => PartitionSnapshotSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var snapshotIdField = SnapshotIdSerde.ReadV00(buffer);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var sizeField = Decoder.ReadInt64(buffer);
                    var positionField = Decoder.ReadInt64(buffer);
                    var unalignedRecordsField = Decoder.ReadRecords(buffer) ?? RecordBatch.Empty;
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        indexField,
                        errorCodeField,
                        snapshotIdField,
                        currentLeaderField,
                        sizeField,
                        positionField,
                        unalignedRecordsField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionSnapshot message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    SnapshotIdSerde.WriteV00(buffer, message.SnapshotIdField);
                    LeaderIdAndEpochSerde.WriteV00(buffer, message.CurrentLeaderField);
                    Encoder.WriteInt64(buffer, message.SizeField);
                    Encoder.WriteInt64(buffer, message.PositionField);
                    Encoder.WriteCompactRecords(buffer, message.UnalignedRecordsField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV00(Stream buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(buffer);
                        var leaderEpochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static void WriteV00(Stream buffer, LeaderIdAndEpoch message)
                    {
                        Encoder.WriteInt32(buffer, message.LeaderIdField);
                        Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(Stream buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        var epochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static void WriteV00(Stream buffer, SnapshotId message)
                    {
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}