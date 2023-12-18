using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public sealed record ProtocolMetadata(
        short Version,
        IReadOnlySet<Topic> Assignments,
        ImmutableArray<byte> UserData
    )
    {
        public static ProtocolMetadata Empty { get; } = new(
            0,
            ImmutableSortedSet<Topic>.Empty,
            []
        );
    }
}
