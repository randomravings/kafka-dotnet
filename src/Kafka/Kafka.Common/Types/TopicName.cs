namespace Kafka.Common.Types
{
    public readonly record struct TopicName(
        string? Value
    )
    {
        public static readonly TopicName Empty = new(null);
        public static implicit operator TopicName(string? id) => new(id);
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
    }
}
