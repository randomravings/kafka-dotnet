using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">The responses per topic.</param>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error.</param>
    /// <param name="GroupsField">The responses per group id.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record OffsetFetchResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<OffsetFetchResponseTopic> TopicsField,
        short ErrorCodeField,
        ImmutableArray<OffsetFetchResponseGroup> GroupsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static OffsetFetchResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<OffsetFetchResponseTopic>.Empty,
            default(short),
            ImmutableArray<OffsetFetchResponseGroup>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="GroupIdField">The group ID.</param>
        /// <param name="TopicsField">The responses per topic.</param>
        /// <param name="ErrorCodeField">The group-level error code, or 0 if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record OffsetFetchResponseGroup (
            string GroupIdField,
            ImmutableArray<OffsetFetchResponseTopics> TopicsField,
            short ErrorCodeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static OffsetFetchResponseGroup Empty { get; } = new(
                "",
                ImmutableArray<OffsetFetchResponseTopics>.Empty,
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionsField">The responses per partition</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record OffsetFetchResponseTopics (
                string NameField,
                ImmutableArray<OffsetFetchResponsePartitions> PartitionsField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static OffsetFetchResponseTopics Empty { get; } = new(
                    "",
                    ImmutableArray<OffsetFetchResponsePartitions>.Empty,
                    ImmutableArray<TaggedField>.Empty
                );
                /// <summary>
                /// <param name="PartitionIndexField">The partition index.</param>
                /// <param name="CommittedOffsetField">The committed message offset.</param>
                /// <param name="CommittedLeaderEpochField">The leader epoch.</param>
                /// <param name="MetadataField">The partition metadata.</param>
                /// <param name="ErrorCodeField">The partition-level error code, or 0 if there was no error.</param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                internal sealed record OffsetFetchResponsePartitions (
                    int PartitionIndexField,
                    long CommittedOffsetField,
                    int CommittedLeaderEpochField,
                    string? MetadataField,
                    short ErrorCodeField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    internal static OffsetFetchResponsePartitions Empty { get; } = new(
                        default(int),
                        default(long),
                        default(int),
                        default(string?),
                        default(short),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
            };
        };
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The responses per partition</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record OffsetFetchResponseTopic (
            string NameField,
            ImmutableArray<OffsetFetchResponsePartition> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static OffsetFetchResponseTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetFetchResponsePartition>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="CommittedOffsetField">The committed message offset.</param>
            /// <param name="CommittedLeaderEpochField">The leader epoch.</param>
            /// <param name="MetadataField">The partition metadata.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record OffsetFetchResponsePartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                string? MetadataField,
                short ErrorCodeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static OffsetFetchResponsePartition Empty { get; } = new(
                    default(int),
                    default(long),
                    default(int),
                    default(string?),
                    default(short),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
