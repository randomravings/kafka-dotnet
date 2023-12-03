using Kafka.Common.Model;

namespace Kafka.Client.Model.Internal
{
    internal sealed record NodeAssignment(
        NodeId NodeId,
        string Host,
        int Port,
        IReadOnlyDictionary<TopicPartition, Offset> TopicPartitionOffsets
    );
}
