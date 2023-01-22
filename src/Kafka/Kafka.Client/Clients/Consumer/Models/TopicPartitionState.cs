using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public class TopicPartitionState
    {
        public ClusterNodeId NodeId { get; init; }
        public TopicName TopicName { get; init; }
        public Partition Partition { get; init; }
        public Offset Offset { get; set; }
    }
}
