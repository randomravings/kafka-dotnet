using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record SubscriptionMetadata(
        string GroupId,
        string? GroupInstanceId,
        int GenerationId,
        string? ProtocolType,
        string? ProtocolName,
        string Leader,
        bool SkipAssignment,
        string MemberId,
        ImmutableArray<MemberMetadata> Members
    )
    {
        public static SubscriptionMetadata Empty { get; } = new(
            "",
            null,
            -1,
            null,
            null,
            "",
            false,
            "",
            ImmutableArray<MemberMetadata>.Empty
        );
    }
}
