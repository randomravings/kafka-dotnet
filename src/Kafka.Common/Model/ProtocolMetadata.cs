using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public sealed record ProtocolMetadata(
        short Version,
        IReadOnlySet<TopicName> Assignments,
        ImmutableArray<byte> UserData
    );
}
