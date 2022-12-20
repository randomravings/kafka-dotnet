using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">The responses per topic.</param>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error.</param>
    /// <param name="GroupsField">The responses per group id.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetFetchResponse (
        int ThrottleTimeMsField,
        ImmutableArray<OffsetFetchResponseTopic> TopicsField,
        short ErrorCodeField,
        ImmutableArray<OffsetFetchResponseGroup> GroupsField
    ) : Response(9)
    {
        public static OffsetFetchResponse Empty { get; } = new(
            default(int),
            ImmutableArray<OffsetFetchResponseTopic>.Empty,
            default(short),
            ImmutableArray<OffsetFetchResponseGroup>.Empty
        );
        /// <summary>
        /// <param name="groupIdField">The group ID.</param>
        /// <param name="TopicsField">The responses per topic.</param>
        /// <param name="ErrorCodeField">The group-level error code, or 0 if there was no error.</param>
        /// </summary>
        public sealed record OffsetFetchResponseGroup (
            string groupIdField,
            ImmutableArray<OffsetFetchResponseTopics> TopicsField,
            short ErrorCodeField
        )
        {
            public static OffsetFetchResponseGroup Empty { get; } = new(
                "",
                ImmutableArray<OffsetFetchResponseTopics>.Empty,
                default(short)
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionsField">The responses per partition</param>
            /// </summary>
            public sealed record OffsetFetchResponseTopics (
                string NameField,
                ImmutableArray<OffsetFetchResponsePartitions> PartitionsField
            )
            {
                public static OffsetFetchResponseTopics Empty { get; } = new(
                    "",
                    ImmutableArray<OffsetFetchResponsePartitions>.Empty
                );
                /// <summary>
                /// <param name="PartitionIndexField">The partition index.</param>
                /// <param name="CommittedOffsetField">The committed message offset.</param>
                /// <param name="CommittedLeaderEpochField">The leader epoch.</param>
                /// <param name="MetadataField">The partition metadata.</param>
                /// <param name="ErrorCodeField">The partition-level error code, or 0 if there was no error.</param>
                /// </summary>
                public sealed record OffsetFetchResponsePartitions (
                    int PartitionIndexField,
                    long CommittedOffsetField,
                    int CommittedLeaderEpochField,
                    string? MetadataField,
                    short ErrorCodeField
                )
                {
                    public static OffsetFetchResponsePartitions Empty { get; } = new(
                        default(int),
                        default(long),
                        default(int),
                        default(string?),
                        default(short)
                    );
                };
            };
        };
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The responses per partition</param>
        /// </summary>
        public sealed record OffsetFetchResponseTopic (
            string NameField,
            ImmutableArray<OffsetFetchResponsePartition> PartitionsField
        )
        {
            public static OffsetFetchResponseTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetFetchResponsePartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="CommittedOffsetField">The committed message offset.</param>
            /// <param name="CommittedLeaderEpochField">The leader epoch.</param>
            /// <param name="MetadataField">The partition metadata.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            public sealed record OffsetFetchResponsePartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                string? MetadataField,
                short ErrorCodeField
            )
            {
                public static OffsetFetchResponsePartition Empty { get; } = new(
                    default(int),
                    default(long),
                    default(int),
                    default(string?),
                    default(short)
                );
            };
        };
    };
}