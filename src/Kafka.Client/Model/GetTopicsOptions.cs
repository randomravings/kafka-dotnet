namespace Kafka.Client.Model
{
    public sealed record GetTopicsOptions(
        bool IncludeInternal,
        bool IncludeTopicAuthorizedOperations
    )
    {
        public static GetTopicsOptions Empty { get; } = new(
            false,
            false
        );
    };
}
