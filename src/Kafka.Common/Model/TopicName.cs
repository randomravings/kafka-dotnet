namespace Kafka.Common.Model
{
    public readonly record struct TopicName(
        string? Value
    )
    {
        public bool IsEmpty => string.IsNullOrEmpty(Value);
        public static readonly TopicName Empty = new(null);
        public static implicit operator TopicName(string? value) => new(value);
        public static implicit operator string(TopicName topicName) => topicName.Value ?? "";
        public static bool operator <=(TopicName a, TopicName b) =>
            string.CompareOrdinal(a.Value, b.Value) <= 0
        ;
        public static bool operator >=(TopicName a, TopicName b) =>
            string.CompareOrdinal(a.Value, b.Value) >= 0
        ;
        public static bool operator <(TopicName a, TopicName b) =>
            string.CompareOrdinal(a.Value, b.Value) < 0
        ;
        public static bool operator >(TopicName a, TopicName b) =>
            string.CompareOrdinal(a.Value, b.Value) > 0
        ;
        public static TopicName FromString(string? value) => new(value);
        public int CompareTo(TopicName other) => string.CompareOrdinal(Value, other.Value);
    }
}
