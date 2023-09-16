namespace Kafka.Common.Model
{
    public readonly record struct TopicId(
        Guid Value
    )
    {
        public static readonly TopicId Empty = Guid.Empty;
        public static implicit operator TopicId(Guid? uuid) => uuid.HasValue ? new(uuid.Value) : Empty;
        public static implicit operator TopicId(string? topicId) => Guid.TryParse(topicId, out var uuid) ? uuid : Guid.Empty;
        public static implicit operator Guid(TopicId topicId) => topicId.Value;
        public static bool operator ==(TopicId a, Guid b) =>
            a.Value == b
        ;
        public static bool operator !=(TopicId a, Guid b) =>
            a.Value != b
        ;
        public static bool operator <=(TopicId a, TopicId b) =>
            a.Value.CompareTo(b.Value) <= 0
        ;
        public static bool operator >=(TopicId a, TopicId b) =>
            a.Value.CompareTo(b.Value) >= 0
        ;
        public static bool operator <(TopicId a, TopicId b) =>
            a.Value.CompareTo(b.Value) < 0
        ;
        public static bool operator >(TopicId a, TopicId b) =>
            a.Value.CompareTo(b.Value) > 0
        ;
    }
}
