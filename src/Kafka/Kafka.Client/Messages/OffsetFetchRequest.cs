using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The group to fetch offsets for.</param>
    /// <param name="TopicsField">Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</param>
    /// <param name="GroupsField">Each group we would like to fetch offsets for</param>
    /// <param name="RequireStableField">Whether broker should hold on returning unstable offsets but set a retriable error code for the partitions.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetFetchRequest (
        string GroupIdField,
        ImmutableArray<OffsetFetchRequestTopic>? TopicsField,
        ImmutableArray<OffsetFetchRequestGroup> GroupsField,
        bool RequireStableField
    ) : Request(9)
    {
        public static OffsetFetchRequest Empty { get; } = new(
            "",
            default(ImmutableArray<OffsetFetchRequestTopic>?),
            ImmutableArray<OffsetFetchRequestGroup>.Empty,
            default(bool)
        );
        public static short FlexibleVersion { get; } = 6;
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionIndexesField">The partition indexes we would like to fetch offsets for.</param>
        /// </summary>
        public sealed record OffsetFetchRequestTopic (
            string NameField,
            ImmutableArray<int> PartitionIndexesField
        )
        {
            public static OffsetFetchRequestTopic Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
        /// <summary>
        /// <param name="groupIdField">The group ID.</param>
        /// <param name="TopicsField">Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</param>
        /// </summary>
        public sealed record OffsetFetchRequestGroup (
            string groupIdField,
            ImmutableArray<OffsetFetchRequestTopics>? TopicsField
        )
        {
            public static OffsetFetchRequestGroup Empty { get; } = new(
                "",
                default(ImmutableArray<OffsetFetchRequestTopics>?)
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionIndexesField">The partition indexes we would like to fetch offsets for.</param>
            /// </summary>
            public sealed record OffsetFetchRequestTopics (
                string NameField,
                ImmutableArray<int> PartitionIndexesField
            )
            {
                public static OffsetFetchRequestTopics Empty { get; } = new(
                    "",
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}