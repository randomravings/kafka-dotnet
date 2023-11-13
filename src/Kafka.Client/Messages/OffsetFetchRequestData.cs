using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestTopic;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="GroupIdField">The group to fetch offsets for.</param>
    /// <param name="TopicsField">Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</param>
    /// <param name="GroupsField">Each group we would like to fetch offsets for</param>
    /// <param name="RequireStableField">Whether broker should hold on returning unstable offsets but set a retriable error code for the partitions.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetFetchRequestData (
        string GroupIdField,
        ImmutableArray<OffsetFetchRequestTopic>? TopicsField,
        ImmutableArray<OffsetFetchRequestGroup> GroupsField,
        bool RequireStableField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        public static OffsetFetchRequestData Empty { get; } = new(
            "",
            default(ImmutableArray<OffsetFetchRequestTopic>?),
            ImmutableArray<OffsetFetchRequestGroup>.Empty,
            default(bool),
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="GroupIdField">The group ID.</param>
        /// <param name="MemberIdField">The member ID assigned by the group coordinator if using the new consumer protocol (KIP-848).</param>
        /// <param name="MemberEpochField">The member epoch if using the new consumer protocol (KIP-848).</param>
        /// <param name="TopicsField">Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record OffsetFetchRequestGroup (
            string GroupIdField,
            string? MemberIdField,
            int MemberEpochField,
            ImmutableArray<OffsetFetchRequestTopics>? TopicsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static OffsetFetchRequestGroup Empty { get; } = new(
                "",
                default(string?),
                default(int),
                default(ImmutableArray<OffsetFetchRequestTopics>?),
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionIndexesField">The partition indexes we would like to fetch offsets for.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record OffsetFetchRequestTopics (
                string NameField,
                ImmutableArray<int> PartitionIndexesField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                public static OffsetFetchRequestTopics Empty { get; } = new(
                    "",
                    ImmutableArray<int>.Empty,
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionIndexesField">The partition indexes we would like to fetch offsets for.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record OffsetFetchRequestTopic (
            string NameField,
            ImmutableArray<int> PartitionIndexesField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static OffsetFetchRequestTopic Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
