using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetForLeaderTopic = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic;
using OffsetForLeaderPartition = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic.OffsetForLeaderPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ReplicaIdField">The broker ID of the follower, of -1 if this request is from a consumer.</param>
    /// <param name="TopicsField">Each topic to get offsets for.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetForLeaderEpochRequest (
        int ReplicaIdField,
        ImmutableArray<OffsetForLeaderTopic> TopicsField
    )
    {
        public static OffsetForLeaderEpochRequest Empty { get; } = new(
            default(int),
            ImmutableArray<OffsetForLeaderTopic>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="PartitionsField">Each partition to get offsets for.</param>
        /// </summary>
        public sealed record OffsetForLeaderTopic (
            string TopicField,
            ImmutableArray<OffsetForLeaderPartition> PartitionsField
        )
        {
            public static OffsetForLeaderTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetForLeaderPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionField">The partition index.</param>
            /// <param name="CurrentLeaderEpochField">An epoch used to fence consumers/replicas with old metadata. If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.</param>
            /// <param name="LeaderEpochField">The epoch to look up an offset for.</param>
            /// </summary>
            public sealed record OffsetForLeaderPartition (
                int PartitionField,
                int CurrentLeaderEpochField,
                int LeaderEpochField
            )
            {
                public static OffsetForLeaderPartition Empty { get; } = new(
                    default(int),
                    default(int),
                    default(int)
                );
            };
        };
    };
}