using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using PartitionData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.DescribeQuorumRequest.TopicData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeQuorumRequest (
        ImmutableArray<TopicData> TopicsField
    ) : Request(55,0,1,0)
    {
        public static DescribeQuorumRequest Empty { get; } = new(
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
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
            [GeneratedCode("kgen", "1.0.0.0")]
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