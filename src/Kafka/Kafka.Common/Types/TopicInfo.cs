using System.Collections.Immutable;

using PartitionInfo = Kafka.Common.Types.TopicInfo.PartitionInfo;

namespace Kafka.Common.Types
{
    public sealed record TopicInfo(
        TopicId Id,
        TopicName Name,
        bool IsInternal,
        ImmutableArray<PartitionInfo> Partitions
    )
    {
        public static readonly TopicInfo Empty = new(
            TopicId.Empty,
            TopicName.Empty,
            false,
            ImmutableArray<PartitionInfo>.Empty
        );

        public sealed record PartitionInfo(
            Partition Index,
            ClusterNodeId PartitionLeader,
            ImmutableArray<ClusterNodeId> IsrNodes
        );
    }
}
