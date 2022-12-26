using Kafka.Common;
using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.DescribeTopicsResult;
using static Kafka.Client.Clients.Admin.Model.DescribeTopicsResult.DescribeTopicResult;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DescribeTopicsResult(
        ImmutableSortedDictionary<TopicName, DescribeTopicResult> Topics
    )
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

            public sealed record TopicPartitionDescription(
                int PartitionIndex,
                int LeaderId,
                int LeaderEpoch,
                Error Errors,
                ImmutableArray<int> ReplicaNodes,
                ImmutableArray<int> IsrNodes,
                ImmutableArray<int> OfflineReplicas
            );
        }
    };
}
