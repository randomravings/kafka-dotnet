namespace Kafka.Common.Types
{
    public sealed record Topic(
        TopicId Id,
        TopicName Name,
        bool IsInternal
    )
    {
        public static readonly Topic Empty = new(
            TopicId.Empty,
            TopicName.Empty,
            false
        );
    }
}
