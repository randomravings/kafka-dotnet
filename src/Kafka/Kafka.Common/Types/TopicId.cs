namespace Kafka.Common.Types
{
    public readonly record struct TopicId(
        Guid Value
    )
    {
        public static readonly TopicId Empty = new(Guid.Empty);
        public static implicit operator TopicId(Guid id) => new(id);
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
