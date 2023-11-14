using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicResult(
        TopicId TopicId,
        TopicName TopicName,
        int NumPartitions,
        int ReplicationFactor,
        IReadOnlyDictionary<string, string?> Config,
        Error Error
    );
}
