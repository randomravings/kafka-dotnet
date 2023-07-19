using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DescribeTopicsResult(

        ImmutableArray<DescribeTopicResult> Topics
    )
    {
        public static DescribeTopicsResult Empty { get; } = new(
            ImmutableArray<DescribeTopicResult>.Empty
        );
    }
}
