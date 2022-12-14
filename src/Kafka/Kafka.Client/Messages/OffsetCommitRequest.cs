using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The unique group identifier.</param>
    /// <param name="GenerationIdField">The generation of the group.</param>
    /// <param name="MemberIdField">The member ID assigned by the group coordinator.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// <param name="RetentionTimeMsField">The time period in ms to retain the offset.</param>
    /// <param name="TopicsField">The topics to commit offsets for.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetCommitRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string? GroupInstanceIdField,
        long RetentionTimeMsField,
        ImmutableArray<OffsetCommitRequestTopic> TopicsField
    ) : Request(8,0,8,8)
    {
        public static OffsetCommitRequest Empty { get; } = new(
            "",
            default(int),
            "",
            default(string?),
            default(long),
            ImmutableArray<OffsetCommitRequestTopic>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition to commit offsets for.</param>
        /// </summary>
        public sealed record OffsetCommitRequestTopic (
            string NameField,
            ImmutableArray<OffsetCommitRequestPartition> PartitionsField
        )
        {
            public static OffsetCommitRequestTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetCommitRequestPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="CommittedOffsetField">The message offset to be committed.</param>
            /// <param name="CommittedLeaderEpochField">The leader epoch of this partition.</param>
            /// <param name="CommitTimestampField">The timestamp of the commit.</param>
            /// <param name="CommittedMetadataField">Any associated metadata the client wants to keep.</param>
            /// </summary>
            public sealed record OffsetCommitRequestPartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                long CommitTimestampField,
                string? CommittedMetadataField
            )
            {
                public static OffsetCommitRequestPartition Empty { get; } = new(
                    default(int),
                    default(long),
                    default(int),
                    default(long),
                    default(string?)
                );
            };
        };
    };
}