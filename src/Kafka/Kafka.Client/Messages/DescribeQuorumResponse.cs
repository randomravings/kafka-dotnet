using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using PartitionData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData.PartitionData;
using ReplicaState = Kafka.Client.Messages.DescribeQuorumResponse.ReplicaState;
using TopicData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top level error code.</param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeQuorumResponse (
        short ErrorCodeField,
        ImmutableArray<TopicData> TopicsField
    ) : Response(55)
    {
        public static DescribeQuorumResponse Empty { get; } = new(
            default(short),
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="ReplicaIdField"></param>
        /// <param name="LogEndOffsetField">The last known log end offset of the follower or -1 if it is unknown</param>
        /// <param name="LastFetchTimestampField">The last known leader wall clock time time when a follower fetched from the leader. This is reported as -1 both for the current leader or if it is unknown for a voter</param>
        /// <param name="LastCaughtUpTimestampField">The leader wall clock append time of the offset for which the follower made the most recent fetch request. This is reported as the current time for the leader and -1 if unknown for a voter</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ReplicaState (
            int ReplicaIdField,
            long LogEndOffsetField,
            long LastFetchTimestampField,
            long LastCaughtUpTimestampField
        )
        {
            public static ReplicaState Empty { get; } = new(
                default(int),
                default(long),
                default(long),
                default(long)
            );
        };
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record TopicData (
            string TopicNameField,
            ImmutableArray<PartitionData> PartitionsField
        )
        {
            public static TopicData Empty { get; } = new(
                "",
                ImmutableArray<PartitionData>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField"></param>
            /// <param name="LeaderIdField">The ID of the current leader or -1 if the leader is unknown.</param>
            /// <param name="LeaderEpochField">The latest known leader epoch</param>
            /// <param name="HighWatermarkField"></param>
            /// <param name="CurrentVotersField"></param>
            /// <param name="ObserversField"></param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField,
                long HighWatermarkField,
                ImmutableArray<ReplicaState> CurrentVotersField,
                ImmutableArray<ReplicaState> ObserversField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(short),
                    default(int),
                    default(int),
                    default(long),
                    ImmutableArray<ReplicaState>.Empty,
                    ImmutableArray<ReplicaState>.Empty
                );
            };
        };
    };
}