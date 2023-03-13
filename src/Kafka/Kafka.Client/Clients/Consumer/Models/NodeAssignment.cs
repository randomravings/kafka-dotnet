using Kafka.Common.Model;
using Kafka.Common.Network;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record NodeAssignment(
        ClusterNodeId NodeId,
        IConnection Connection,
        ImmutableSortedSet<TopicPartition> TopicPartitions,
        ImmutableSortedDictionary<TopicName, ImmutableArray<TopicPartition>> TopicPartitionsLookup
    );
}
