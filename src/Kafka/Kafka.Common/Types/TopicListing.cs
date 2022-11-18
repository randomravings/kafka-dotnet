namespace Kafka.Common.Types
{
    public sealed record TopicListing(
        Topic Topic,
        bool IsInternal
    )
    {
        public static readonly TopicListing Empty = new(
            Topic.Empty,
            false
        );
    }
}
