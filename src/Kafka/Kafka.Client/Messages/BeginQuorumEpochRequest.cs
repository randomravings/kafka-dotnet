using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData;
using PartitionData = Kafka.Client.Messages.BeginQuorumEpochRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClusterIdField"></param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BeginQuorumEpochRequest (
        string? ClusterIdField,
        ImmutableArray<TopicData> TopicsField
    )
    {
        public static BeginQuorumEpochRequest Empty { get; } = new(
            default(string?),
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        public sealed record TopicData (
            string TopicNameField,
            ImmutableArray<PartitionData> PartitionsField
        )
        {
            public static TopicData Empty { get; } = new(
                "",
                ImmutableArray<PartitionData>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="LeaderIdField">The ID of the newly elected leader</param>
            /// <param name="LeaderEpochField">The epoch of the newly elected leader</param>
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField,
                int LeaderIdField,
                int LeaderEpochField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(int),
                    default(int)
                );
            };
        };
    };
}