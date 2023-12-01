using Kafka.Common.Model;

namespace Kafka.Client.Model.Internal
{
    internal sealed record ProducerPartitionMetadata(
        Partition Partition,
        ClusterNodeId LeaderId,
        string Host,
        int Port
    );
}
