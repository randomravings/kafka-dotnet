using Kafka.Common.Model;
using Kafka.Common.Protocol;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DescribeTopicResult(
        Guid TopicId,
        string? Name,
        bool IsInternal,
        int TopicAuthorizedOperations,
        Error Error,
        ImmutableArray<TopicPartitionDescription> Partitions
    )
    {
        public static DescribeTopicResult Empty { get; } = new(
            Guid.Empty,
            "",
            false,
            0,
            Errors.Known.NONE,
            ImmutableArray<TopicPartitionDescription>.Empty
        );
    }
}
