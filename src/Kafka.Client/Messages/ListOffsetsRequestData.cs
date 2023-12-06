using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ReplicaIdField">The broker ID of the requester, or -1 if this request is being made by a normal consumer.</param>
    /// <param name="IsolationLevelField">This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</param>
    /// <param name="TopicsField">Each topic in the request.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ListOffsetsRequestData (
        int ReplicaIdField,
        sbyte IsolationLevelField,
        ImmutableArray<ListOffsetsTopic> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static ListOffsetsRequestData Empty { get; } = new(
            default(int),
            default(sbyte),
            ImmutableArray<ListOffsetsTopic>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition in the request.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record ListOffsetsTopic (
            string NameField,
            ImmutableArray<ListOffsetsPartition> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static ListOffsetsTopic Empty { get; } = new(
                "",
                ImmutableArray<ListOffsetsPartition>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="CurrentLeaderEpochField">The current leader epoch.</param>
            /// <param name="TimestampField">The current timestamp.</param>
            /// <param name="MaxNumOffsetsField">The maximum number of offsets to report.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record ListOffsetsPartition (
                int PartitionIndexField,
                int CurrentLeaderEpochField,
                long TimestampField,
                int MaxNumOffsetsField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static ListOffsetsPartition Empty { get; } = new(
                    default(int),
                    default(int),
                    default(long),
                    default(int),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
