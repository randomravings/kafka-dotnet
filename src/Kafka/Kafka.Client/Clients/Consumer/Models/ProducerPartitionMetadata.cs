using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record ProducerPartitionMetadata(
        Partition Partition,
        ClusterNodeId LeaderId,
        string Host,
        int Port
    );
}
