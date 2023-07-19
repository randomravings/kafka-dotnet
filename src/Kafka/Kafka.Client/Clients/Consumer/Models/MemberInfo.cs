namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record MemberInfo(
        string MemberId,
        int GenerationId
    )
    {
        public static MemberInfo Empty { get; } = new(
            "",
            0
        );
    }
}
