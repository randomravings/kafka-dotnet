using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicResult(
        TopicId Id,
        TopicName Name,
        int NumPartitions,
        int ReplicationFactor,
        ImmutableSortedDictionary<string, string?> Config
    );
}
