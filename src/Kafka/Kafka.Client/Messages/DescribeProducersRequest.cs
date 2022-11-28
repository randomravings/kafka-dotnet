using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicRequest = Kafka.Client.Messages.DescribeProducersRequest.TopicRequest;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeProducersRequest (
        ImmutableArray<TopicRequest> TopicsField
    ) : Request(61)
    {
        public static DescribeProducersRequest Empty { get; } = new(
            ImmutableArray<TopicRequest>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionIndexesField">The indexes of the partitions to list producers for.</param>
        /// </summary>
        public sealed record TopicRequest (
            string NameField,
            ImmutableArray<int> PartitionIndexesField
        )
        {
            public static TopicRequest Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
    };
}