namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record MemberMetadata(
        string MemberId,
        string? GroupInstanceId,
        ReadOnlyMemory<byte> Metadata
    );
}
