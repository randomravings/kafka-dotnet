using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetDeleteRequestPartition = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic.OffsetDeleteRequestPartition;
using OffsetDeleteRequestTopic = Kafka.Client.Messages.OffsetDeleteRequest.OffsetDeleteRequestTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The unique group identifier.</param>
    /// <param name="TopicsField">The topics to delete offsets for</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetDeleteRequest (
        string GroupIdField,
        ImmutableArray<OffsetDeleteRequestTopic> TopicsField
    )
    {
        public static OffsetDeleteRequest Empty { get; } = new(
            "",
            ImmutableArray<OffsetDeleteRequestTopic>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition to delete offsets for.</param>
        /// </summary>
        public sealed record OffsetDeleteRequestTopic (
            string NameField,
            ImmutableArray<OffsetDeleteRequestPartition> PartitionsField
        )
        {
            public static OffsetDeleteRequestTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetDeleteRequestPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// </summary>
            public sealed record OffsetDeleteRequestPartition (
                int PartitionIndexField
            )
            {
                public static OffsetDeleteRequestPartition Empty { get; } = new(
                    default(int)
                );
            };
        };
    };
}