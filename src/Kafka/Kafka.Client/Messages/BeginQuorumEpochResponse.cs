using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicData = Kafka.Client.Messages.BeginQuorumEpochResponse.TopicData;
using PartitionData = Kafka.Client.Messages.BeginQuorumEpochResponse.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top level error code.</param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BeginQuorumEpochResponse (
        short ErrorCodeField,
        ImmutableArray<TopicData> TopicsField
    )
    {
        public static BeginQuorumEpochResponse Empty { get; } = new(
            default(short),
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
            /// <param name="ErrorCodeField"></param>
            /// <param name="LeaderIdField">The ID of the current leader or -1 if the leader is unknown.</param>
            /// <param name="LeaderEpochField">The latest known leader epoch</param>
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(short),
                    default(int),
                    default(int)
                );
            };
        };
    };
}