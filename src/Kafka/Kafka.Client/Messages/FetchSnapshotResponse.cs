using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Records;
using Kafka.Common.Protocol;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code.</param>
    /// <param name="TopicsField">The topics to fetch.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchSnapshotResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<TopicSnapshot> TopicsField
    ) : Response(59)
    {
        public static FetchSnapshotResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<TopicSnapshot>.Empty
        );
        /// <summary>
        /// <param name="NameField">The name of the topic to fetch.</param>
        /// <param name="PartitionsField">The partitions to fetch.</param>
        /// </summary>
        public sealed record TopicSnapshot (
            string NameField,
            ImmutableArray<PartitionSnapshot> PartitionsField
        )
        {
            public static TopicSnapshot Empty { get; } = new(
                "",
                ImmutableArray<PartitionSnapshot>.Empty
            );
            /// <summary>
            /// <param name="IndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no fetch error.</param>
            /// <param name="SnapshotIdField">The snapshot endOffset and epoch fetched</param>
            /// <param name="CurrentLeaderField"></param>
            /// <param name="SizeField">The total size of the snapshot.</param>
            /// <param name="PositionField">The starting byte position within the snapshot included in the Bytes field.</param>
            /// <param name="UnalignedRecordsField">Snapshot data in records format which may not be aligned on an offset boundary</param>
            /// </summary>
            public sealed record PartitionSnapshot (
                int IndexField,
                short ErrorCodeField,
                SnapshotId SnapshotIdField,
                LeaderIdAndEpoch CurrentLeaderField,
                long SizeField,
                long PositionField,
                ImmutableArray<IRecords> UnalignedRecordsField
            )
            {
                public static PartitionSnapshot Empty { get; } = new(
                    default(int),
                    default(short),
                    SnapshotId.Empty,
                    LeaderIdAndEpoch.Empty,
                    default(long),
                    default(long),
                    ImmutableArray<IRecords>.Empty
                );
                /// <summary>
                /// <param name="EndOffsetField"></param>
                /// <param name="EpochField"></param>
                /// </summary>
                public sealed record SnapshotId (
                    long EndOffsetField,
                    int EpochField
                )
                {
                    public static SnapshotId Empty { get; } = new(
                        default(long),
                        default(int)
                    );
                };
                /// <summary>
                /// <param name="LeaderIdField">The ID of the current leader or -1 if the leader is unknown.</param>
                /// <param name="LeaderEpochField">The latest known leader epoch</param>
                /// </summary>
                public sealed record LeaderIdAndEpoch (
                    int LeaderIdField,
                    int LeaderEpochField
                )
                {
                    public static LeaderIdAndEpoch Empty { get; } = new(
                        default(int),
                        default(int)
                    );
                };
            };
        };
    };
}