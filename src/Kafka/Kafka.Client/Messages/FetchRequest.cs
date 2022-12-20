using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClusterIdField">The clusterId if known. This is used to validate metadata fetches prior to broker registration.</param>
    /// <param name="ReplicaIdField">The broker ID of the follower, of -1 if this request is from a consumer.</param>
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
    public sealed record FetchRequest (
        string? ClusterIdField,
        int ReplicaIdField,
        int MaxWaitMsField,
        int MinBytesField,
        int MaxBytesField,
        sbyte IsolationLevelField,
        int SessionIdField,
        int SessionEpochField,
        ImmutableArray<FetchTopic> TopicsField,
        ImmutableArray<ForgottenTopic> ForgottenTopicsDataField,
        string RackIdField
    ) : Request(1,0,13,12)
    {
        public static FetchRequest Empty { get; } = new(
            default(string?),
            default(int),
            default(int),
            default(int),
            default(int),
            default(sbyte),
            default(int),
            default(int),
            ImmutableArray<FetchTopic>.Empty,
            ImmutableArray<ForgottenTopic>.Empty,
            ""
        );
        /// <summary>
        /// <param name="TopicField">The name of the topic to fetch.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The partitions to fetch.</param>
        /// </summary>
        public sealed record FetchTopic (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<FetchPartition> PartitionsField
        )
        {
            public static FetchTopic Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<FetchPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionField">The partition index.</param>
            /// <param name="CurrentLeaderEpochField">The current leader epoch of the partition.</param>
            /// <param name="FetchOffsetField">The message offset.</param>
            /// <param name="LastFetchedEpochField">The epoch of the last fetched record or -1 if there is none</param>
            /// <param name="LogStartOffsetField">The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.</param>
            /// <param name="PartitionMaxBytesField">The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.</param>
            /// </summary>
            public sealed record FetchPartition (
                int PartitionField,
                int CurrentLeaderEpochField,
                long FetchOffsetField,
                int LastFetchedEpochField,
                long LogStartOffsetField,
                int PartitionMaxBytesField
            )
            {
                public static FetchPartition Empty { get; } = new(
                    default(int),
                    default(int),
                    default(long),
                    default(int),
                    default(long),
                    default(int)
                );
            };
        };
        /// <summary>
        /// <param name="TopicField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionsField">The partitions indexes to forget.</param>
        /// </summary>
        public sealed record ForgottenTopic (
            string TopicField,
            Guid TopicIdField,
            ImmutableArray<int> PartitionsField
        )
        {
            public static ForgottenTopic Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<int>.Empty
            );
        };
    };
}