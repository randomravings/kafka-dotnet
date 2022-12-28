using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    public readonly record struct TopicPartitionWatermark(
        TopicName TopicName,
        ImmutableArray<PartitionWatermark> PartitionWatermarks
    );
}
