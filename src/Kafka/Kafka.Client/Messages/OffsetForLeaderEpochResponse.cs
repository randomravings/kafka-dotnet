using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using EpochEndOffset = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult.EpochEndOffset;
using OffsetForLeaderTopicResult = Kafka.Client.Messages.OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Each topic we fetched offsets for.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetForLeaderEpochResponse (
        int ThrottleTimeMsField,
        ImmutableArray<OffsetForLeaderTopicResult> TopicsField
    ) : Response(23)
    {
        public static OffsetForLeaderEpochResponse Empty { get; } = new(
            default(int),
            ImmutableArray<OffsetForLeaderTopicResult>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="PartitionsField">Each partition in the topic we fetched offsets for.</param>
        /// </summary>
        public sealed record OffsetForLeaderTopicResult (
            string TopicField,
            ImmutableArray<EpochEndOffset> PartitionsField
        )
        {
            public static OffsetForLeaderTopicResult Empty { get; } = new(
                "",
                ImmutableArray<EpochEndOffset>.Empty
            );
            /// <summary>
            /// <param name="ErrorCodeField">The error code 0, or if there was no error.</param>
            /// <param name="PartitionField">The partition index.</param>
            /// <param name="LeaderEpochField">The leader epoch of the partition.</param>
            /// <param name="EndOffsetField">The end offset of the epoch.</param>
            /// </summary>
            public sealed record EpochEndOffset (
                short ErrorCodeField,
                int PartitionField,
                int LeaderEpochField,
                long EndOffsetField
            )
            {
                public static EpochEndOffset Empty { get; } = new(
                    default(short),
                    default(int),
                    default(int),
                    default(long)
                );
            };
        };
    };
}