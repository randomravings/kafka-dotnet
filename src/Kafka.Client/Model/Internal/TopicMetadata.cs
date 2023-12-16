using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    internal sealed record TopicMetadata(
        TopicName TopicName,
        ImmutableArray<PartitionMetadata> PartitionMetadata,
        DateTimeOffset ExpireTime
    )
    {
        public static TopicMetadata Empty { get; } = new(
            TopicName.Empty,
            [],
            DateTimeOffset.MinValue
        );
    }
}
