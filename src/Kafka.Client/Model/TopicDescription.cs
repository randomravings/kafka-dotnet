using Kafka.Common.Model;
using System.Collections.Immutable;
namespace Kafka.Client.Model
{
    public sealed record TopicDescription(
        Guid TopicId,
        TopicName TopicName,
        bool Internal,
        ImmutableArray<PartitionDescription> Partitions,
        int TopicAuthorizedOperations,
        Error Error
    );
}
