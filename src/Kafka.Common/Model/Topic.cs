namespace Kafka.Common.Model
{
    public readonly record struct Topic(
        TopicId TopicId,
        TopicName TopicName
    )
    {
        public static readonly Topic Empty = new(TopicId.Empty, TopicName.Empty);
        public static implicit operator Topic(Guid value) => new(value, TopicName.Empty);
        public static implicit operator Topic(TopicId value) => new(value, TopicName.Empty);
        public static implicit operator Topic(string? value) => new(TopicId.Empty, value);
        public static implicit operator Topic(TopicName value) => new(TopicId.Empty, value);
        public static implicit operator Topic((Guid Id, string? TopicName) value) => new(value.Id, value.TopicName);

        public static Topic FromTopicId(
            TopicId value
        ) => new(
            value,
            TopicName.Empty
        );

        public static Topic FromGuid(
            Guid value
        ) => new(
            value,
            TopicName.Empty
        );

        public static Topic FromTopicName(
            TopicName value
        ) => new(
            TopicId.Empty,
            value
        );

        public static Topic FromString(
            string? value
        ) => new(
            TopicId.Empty,
            value
        );

        public static Topic FromValueTuple((
            Guid Id,
            TopicName Name
        ) value) => new(
            value.Id,
            value.Name
        );
    }
}
