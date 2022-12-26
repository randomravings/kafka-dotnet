using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Records;
using Kafka.Common.Protocol;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code.</param>
    /// <param name="SessionIdField">The fetch session ID, or 0 if this is not part of a fetch session.</param>
    /// <param name="ResponsesField">The response topics.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        int SessionIdField,
        ImmutableArray<FetchableTopicResponse> ResponsesField
    ) : Response(1)
    {
        public static FetchResponse Empty { get; } = new(
            default(int),
            default(short),
            default(int),
            ImmutableArray<FetchableTopicResponse>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The topic partitions.</param>
        /// </summary>
        public sealed record FetchableTopicResponse (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<PartitionData> PartitionsField
        )
        {
            public static FetchableTopicResponse Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<PartitionData>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no fetch error.</param>
            /// <param name="HighWatermarkField">The current high water mark.</param>
            /// <param name="LastStableOffsetField">The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)</param>
            /// <param name="LogStartOffsetField">The current log start offset.</param>
            /// <param name="DivergingEpochField">In case divergence is detected based on the `LastFetchedEpoch` and `FetchOffset` in the request, this field indicates the largest epoch and its end offset such that subsequent records are known to diverge</param>
            /// <param name="CurrentLeaderField"></param>
            /// <param name="SnapshotIdField">In the case of fetching an offset less than the LogStartOffset, this is the end offset and epoch that should be used in the FetchSnapshot request.</param>
            /// <param name="AbortedTransactionsField">The aborted transactions.</param>
            /// <param name="PreferredReadReplicaField">The preferred read replica for the consumer to use on its next fetch request</param>
            /// <param name="RecordsField">The record data.</param>
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                long HighWatermarkField,
                long LastStableOffsetField,
                long LogStartOffsetField,
                EpochEndOffset DivergingEpochField,
                LeaderIdAndEpoch CurrentLeaderField,
                SnapshotId SnapshotIdField,
                ImmutableArray<AbortedTransaction>? AbortedTransactionsField,
                int PreferredReadReplicaField,
                IRecords? RecordsField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(short),
                    default(long),
                    default(long),
                    default(long),
                    EpochEndOffset.Empty,
                    LeaderIdAndEpoch.Empty,
                    SnapshotId.Empty,
                    default(ImmutableArray<AbortedTransaction>?),
                    default(int),
                    default(IRecords)
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
                /// <param name="ProducerIdField">The producer id associated with the aborted transaction.</param>
                /// <param name="FirstOffsetField">The first offset in the aborted transaction.</param>
                /// </summary>
                public sealed record AbortedTransaction (
                    long ProducerIdField,
                    long FirstOffsetField
                )
                {
                    public static AbortedTransaction Empty { get; } = new(
                        default(long),
                        default(long)
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
                /// <summary>
                /// <param name="EpochField"></param>
                /// <param name="EndOffsetField"></param>
                /// </summary>
                public sealed record EpochEndOffset (
                    int EpochField,
                    long EndOffsetField
                )
                {
                    public static EpochEndOffset Empty { get; } = new(
                        default(int),
                        default(long)
                    );
                };
            };
        };
    };
}