namespace Kafka.Client.Model
{
    public sealed record ListTopicsOptions(
        bool IncludeInternal,
        bool IncludeTopicAuthorizedOperations
    )
    {
        public static ListTopicsOptions Empty { get; } = new(
            false,
            false
        );
    };
}
