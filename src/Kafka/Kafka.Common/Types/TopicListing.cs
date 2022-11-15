namespace Kafka.Common.Types
{
    public sealed record TopicListing(
        Topic Topic,
        bool IsInternal,
        Guid TopicId
    )
    {
        public static readonly Topic Empty = new("");
    }
}
