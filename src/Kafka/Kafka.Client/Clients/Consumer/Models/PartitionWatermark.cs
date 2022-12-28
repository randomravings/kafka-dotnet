using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public readonly record struct PartitionWatermark(
        Partition Partition,
        Offset High,
        Offset Low,
        Offset Committed
    );
}
