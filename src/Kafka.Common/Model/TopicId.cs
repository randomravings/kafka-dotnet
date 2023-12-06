namespace Kafka.Common.Model
{
    public readonly record struct TopicId(
        Guid Value
    )
    {
        public bool IsEmpty => Value == Guid.Empty;
        public static readonly TopicId Empty = Guid.Empty;
        public static implicit operator TopicId(Guid value) => new(value);
        public static implicit operator Guid(TopicId value) => value.Value;
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
        public static TopicId FromGuid(Guid? value) => value.HasValue ? new(value.Value) : Empty;
        public Guid ToGuid() => Value;
        public int CompareTo(TopicId other) => Value.CompareTo(other.Value);
    }
}
