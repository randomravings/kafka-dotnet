namespace Kafka.Client.Model
{
    public sealed record DescribeTopicOptions(
        bool IncludeTopicAuthorizedOperations
    )
    {
        public static DescribeTopicOptions Empty { get; } = new(
            false
        );
    };
}
