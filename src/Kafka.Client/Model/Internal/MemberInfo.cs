namespace Kafka.Client.Model.Internal
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
