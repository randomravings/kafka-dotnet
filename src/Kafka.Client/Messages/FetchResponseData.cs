using Kafka.Common.Model;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using SnapshotId = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.SnapshotId;
using NodeEndpoint = Kafka.Client.Messages.FetchResponseData.NodeEndpoint;
using PartitionData = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse;
using AbortedTransaction = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.AbortedTransaction;
using EpochEndOffset = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.EpochEndOffset;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code.</param>
    /// <param name="SessionIdField">The fetch session ID, or 0 if this is not part of a fetch session.</param>
    /// <param name="ResponsesField">The response topics.</param>
    /// <param name="NodeEndpointsField">Endpoints for all current-leaders enumerated in PartitionData, with errors NOT_LEADER_OR_FOLLOWER & FENCED_LEADER_EPOCH.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        int SessionIdField,
        ImmutableArray<FetchableTopicResponse> ResponsesField,
        ImmutableArray<NodeEndpoint> NodeEndpointsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static FetchResponseData Empty { get; } = new(
            default(int),
            default(short),
            default(int),
            ImmutableArray<FetchableTopicResponse>.Empty,
            ImmutableArray<NodeEndpoint>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The topic partitions.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record FetchableTopicResponse (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<PartitionData> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static FetchableTopicResponse Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<PartitionData>.Empty,
                ImmutableArray<TaggedField>.Empty
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
            [GeneratedCode("kgen", "1.0.0.0")]
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
                ImmutableArray<IRecords>? RecordsField,
                ImmutableArray<TaggedField> TaggedFields
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
                    default(ImmutableArray<IRecords>?),
                    ImmutableArray<TaggedField>.Empty
                );
                /// <summary>
                /// <param name="ProducerIdField">The producer id associated with the aborted transaction.</param>
                /// <param name="FirstOffsetField">The first offset in the aborted transaction.</param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                public sealed record AbortedTransaction (
                    long ProducerIdField,
                    long FirstOffsetField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    public static AbortedTransaction Empty { get; } = new(
                        default(long),
                        default(long),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
                /// <summary>
                /// <param name="EpochField"></param>
                /// <param name="EndOffsetField"></param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                public sealed record EpochEndOffset (
                    int EpochField,
                    long EndOffsetField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    public static EpochEndOffset Empty { get; } = new(
                        default(int),
                        default(long),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
                /// <summary>
                /// <param name="LeaderIdField">The ID of the current leader or -1 if the leader is unknown.</param>
                /// <param name="LeaderEpochField">The latest known leader epoch</param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                public sealed record LeaderIdAndEpoch (
                    int LeaderIdField,
                    int LeaderEpochField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    public static LeaderIdAndEpoch Empty { get; } = new(
                        default(int),
                        default(int),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
                /// <summary>
                /// <param name="EndOffsetField"></param>
                /// <param name="EpochField"></param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                public sealed record SnapshotId (
                    long EndOffsetField,
                    int EpochField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    public static SnapshotId Empty { get; } = new(
                        default(long),
                        default(int),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
            };
        };
        /// <summary>
        /// <param name="NodeIdField">The ID of the associated node.</param>
        /// <param name="HostField">The node's hostname.</param>
        /// <param name="PortField">The node's port.</param>
        /// <param name="RackField">The rack of the node, or null if it has not been assigned to a rack.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record NodeEndpoint (
            int NodeIdField,
            string HostField,
            int PortField,
            string? RackField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static NodeEndpoint Empty { get; } = new(
                default(int),
                "",
                default(int),
                default(string?),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
