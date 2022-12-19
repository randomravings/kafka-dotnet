using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClusterIdField">The clusterId if known, this is used to validate metadata fetches prior to broker registration</param>
    /// <param name="ReplicaIdField">The broker ID of the follower</param>
    /// <param name="MaxBytesField">The maximum bytes to fetch from all of the snapshots</param>
    /// <param name="TopicsField">The topics to fetch</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchSnapshotRequest (
        string? ClusterIdField,
        int ReplicaIdField,
        int MaxBytesField,
        ImmutableArray<TopicSnapshot> TopicsField
    ) : Request(59)
    {
        public static FetchSnapshotRequest Empty { get; } = new(
            default(string?),
            default(int),
            default(int),
            ImmutableArray<TopicSnapshot>.Empty
        );
        public static short FlexibleVersion { get; } = 0;
        /// <summary>
        /// <param name="NameField">The name of the topic to fetch</param>
        /// <param name="PartitionsField">The partitions to fetch</param>
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
            /// <param name="PartitionField">The partition index</param>
            /// <param name="CurrentLeaderEpochField">The current leader epoch of the partition, -1 for unknown leader epoch</param>
            /// <param name="SnapshotIdField">The snapshot endOffset and epoch to fetch</param>
            /// <param name="PositionField">The byte position within the snapshot to start fetching from</param>
            /// </summary>
            public sealed record PartitionSnapshot (
                int PartitionField,
                int CurrentLeaderEpochField,
                SnapshotId SnapshotIdField,
                long PositionField
            )
            {
                public static PartitionSnapshot Empty { get; } = new(
                    default(int),
                    default(int),
                    SnapshotId.Empty,
                    default(long)
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
            };
        };
    };
}