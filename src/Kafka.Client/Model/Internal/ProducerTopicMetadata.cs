using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    internal sealed record ProducerTopicMetadata(
        TopicName TopicName,
        ImmutableArray<ProducerPartitionMetadata> PartitionMetadata,
        DateTimeOffset ExpireTime
    )
    {
        public static ProducerTopicMetadata Empty { get; } = new(
            TopicName.Empty,
            [],
            DateTimeOffset.MinValue
        );
    }
}
