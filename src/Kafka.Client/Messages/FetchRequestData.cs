using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using FetchPartition = Kafka.Client.Messages.FetchRequestData.FetchTopic.FetchPartition;
using FetchTopic = Kafka.Client.Messages.FetchRequestData.FetchTopic;
using ForgottenTopic = Kafka.Client.Messages.FetchRequestData.ForgottenTopic;
using ReplicaState = Kafka.Client.Messages.FetchRequestData.ReplicaState;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ClusterIdField">The clusterId if known. This is used to validate metadata fetches prior to broker registration.</param>
    /// <param name="ReplicaIdField">The broker ID of the follower, of -1 if this request is from a consumer.</param>
    /// <param name="ReplicaStateField"></param>
    /// <param name="MaxWaitMsField">The maximum time in milliseconds to wait for the response.</param>
    /// <param name="MinBytesField">The minimum bytes to accumulate in the response.</param>
    /// <param name="MaxBytesField">The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.</param>
    /// <param name="IsolationLevelField">This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</param>
    /// <param name="SessionIdField">The fetch session ID.</param>
    /// <param name="SessionEpochField">The fetch session epoch, which is used for ordering requests in a session.</param>
    /// <param name="TopicsField">The topics to fetch.</param>
    /// <param name="ForgottenTopicsDataField">In an incremental fetch request, the partitions to remove.</param>
    /// <param name="RackIdField">Rack ID of the consumer making this request</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record FetchRequestData (
        string? ClusterIdField,
        int ReplicaIdField,
        ReplicaState ReplicaStateField,
        int MaxWaitMsField,
        int MinBytesField,
        int MaxBytesField,
        sbyte IsolationLevelField,
        int SessionIdField,
        int SessionEpochField,
        ImmutableArray<FetchTopic> TopicsField,
        ImmutableArray<ForgottenTopic> ForgottenTopicsDataField,
        string RackIdField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static FetchRequestData Empty { get; } = new(
            default(string?),
            default(int),
            ReplicaState.Empty,
            default(int),
            default(int),
            default(int),
            default(sbyte),
            default(int),
            default(int),
            ImmutableArray<FetchTopic>.Empty,
            ImmutableArray<ForgottenTopic>.Empty,
            "",
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The name of the topic to fetch.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The partitions to fetch.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record FetchTopic (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<FetchPartition> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static FetchTopic Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<FetchPartition>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionField">The partition index.</param>
            /// <param name="CurrentLeaderEpochField">The current leader epoch of the partition.</param>
            /// <param name="FetchOffsetField">The message offset.</param>
            /// <param name="LastFetchedEpochField">The epoch of the last fetched record or -1 if there is none</param>
            /// <param name="LogStartOffsetField">The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.</param>
            /// <param name="PartitionMaxBytesField">The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record FetchPartition (
                int PartitionField,
                int CurrentLeaderEpochField,
                long FetchOffsetField,
                int LastFetchedEpochField,
                long LogStartOffsetField,
                int PartitionMaxBytesField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static FetchPartition Empty { get; } = new(
                    default(int),
                    default(int),
                    default(long),
                    default(int),
                    default(long),
                    default(int),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The partitions indexes to forget.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record ForgottenTopic (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<int> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static ForgottenTopic Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<int>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="ReplicaIdField">The replica ID of the follower, or -1 if this request is from a consumer.</param>
        /// <param name="ReplicaEpochField">The epoch of this follower, or -1 if not available.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record ReplicaState (
            int ReplicaIdField,
            long ReplicaEpochField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static ReplicaState Empty { get; } = new(
                default(int),
                default(long),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
