using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    internal sealed record ProducerTopicMetadata(
        TopicName TopicName,
        ImmutableArray<ProducerPartitionMetadata> PartitionMetadata
    );
}
