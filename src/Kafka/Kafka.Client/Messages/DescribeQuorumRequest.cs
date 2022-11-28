using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData;
using PartitionData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeQuorumRequest (
        ImmutableArray<TopicData> TopicsField
    ) : Request(55)
    {
        public static DescribeQuorumRequest Empty { get; } = new(
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
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int)
                );
            };
        };
    };
}