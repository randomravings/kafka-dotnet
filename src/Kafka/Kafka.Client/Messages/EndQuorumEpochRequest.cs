using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.EndQuorumEpochRequest.TopicData;
using PartitionData = Kafka.Client.Messages.EndQuorumEpochRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClusterIdField"></param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EndQuorumEpochRequest (
        string? ClusterIdField,
        ImmutableArray<TopicData> TopicsField
    )
    {
        public static EndQuorumEpochRequest Empty { get; } = new(
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
            /// <param name="LeaderIdField">The current leader ID that is resigning</param>
            /// <param name="LeaderEpochField">The current epoch</param>
            /// <param name="PreferredSuccessorsField">A sorted list of preferred successors to start the election</param>
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField,
                int LeaderIdField,
                int LeaderEpochField,
                ImmutableArray<int> PreferredSuccessorsField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(int),
                    default(int),
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}