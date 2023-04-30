using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record ProducerTopicMetadata(
        TopicName TopicName,
        ImmutableArray<ProducerPartitionMetadata> PartitionMetadata
    );
}
