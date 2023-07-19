using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record NodeAssignment(
        ClusterNodeId NodeId,
        string Host,
        int Port,
        ImmutableSortedDictionary<TopicPartition, Offset> TopicPartitionOffsets
    );
}
