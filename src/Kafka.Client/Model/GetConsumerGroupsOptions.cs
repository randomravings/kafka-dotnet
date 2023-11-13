namespace Kafka.Client.Model
{
    public sealed record GetConsumerGroupsOptions(
        bool IncludeInternal,
        bool IncludeTopicAuthorizedOperations
    )
    {
        public static GetConsumerGroupsOptions Empty { get; } = new(
            false,
            false
        );
    };
}
