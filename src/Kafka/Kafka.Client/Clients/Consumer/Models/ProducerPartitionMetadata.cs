using Kafka.Client.Clients.Producer;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record ProducerPartitionMetadata(
        Partition Partition,
        IBrokerChannel BrokerChannel
    );
}
