using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotResponseSerde
    {
        private static readonly DecodeDelegate<FetchSnapshotResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<FetchSnapshotResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static FetchSnapshotResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FetchSnapshotResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FetchSnapshotResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicSnapshotSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, FetchSnapshotResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<TopicSnapshot>(buffer, message.TopicsField, (b, i) => TopicSnapshotSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionSnapshotSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicSnapshot message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<PartitionSnapshot>(buffer, message.PartitionsField, (b, i) => PartitionSnapshotSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var snapshotIdField = SnapshotIdSerde.ReadV00(ref buffer);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var sizeField = Decoder.ReadInt64(ref buffer);
                    var positionField = Decoder.ReadInt64(ref buffer);
                    var unalignedRecordsField = Decoder.ReadRecords(ref buffer) ?? RecordBatch.Empty;
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionSnapshot message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = SnapshotIdSerde.WriteV00(buffer, message.SnapshotIdField);
                    buffer = LeaderIdAndEpochSerde.WriteV00(buffer, message.CurrentLeaderField);
                    buffer = Encoder.WriteInt64(buffer, message.SizeField);
                    buffer = Encoder.WriteInt64(buffer, message.PositionField);
                    buffer = Encoder.WriteCompactRecords(buffer, message.UnalignedRecordsField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        var epochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, SnapshotId message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(ref buffer);
                        var leaderEpochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, LeaderIdAndEpoch message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                        buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}