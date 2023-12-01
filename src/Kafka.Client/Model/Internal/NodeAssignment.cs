using Kafka.Common.Model;

namespace Kafka.Client.Model.Internal
{
    internal sealed record NodeAssignment(
        ClusterNodeId NodeId,
        string Host,
        int Port,
        IReadOnlyDictionary<TopicPartition, Offset> TopicPartitionOffsets
    );
}
