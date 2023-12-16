namespace Kafka.Client.Model
{
    public sealed record DescribeGroupOptions(
        bool IncludeAuthorizedOperations
    )
    {
        public static DescribeGroupOptions Empty { get; } = new(
            false
        );
    }
}
