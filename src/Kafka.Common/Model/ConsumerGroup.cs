namespace Kafka.Common.Model
{
    public readonly record struct ConsumerGroup(
        string Value
    )
    {
        public static readonly ConsumerGroup Empty = new("");
        public static implicit operator ConsumerGroup(string value) => new(value);
        public static implicit operator string(ConsumerGroup value) => value.Value;
        public static bool operator <=(ConsumerGroup a, ConsumerGroup b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => true,
            }
        ;
        public static bool operator >=(ConsumerGroup a, ConsumerGroup b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => true,
            }
        ;
        public static bool operator <(ConsumerGroup a, ConsumerGroup b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => false,
            }
        ;
        public static bool operator >(ConsumerGroup a, ConsumerGroup b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => false,
            }
        ;
        public static ConsumerGroup FromString(string value) => new(value);
        public int CompareTo(ConsumerGroup other) => string.CompareOrdinal(this.Value, other.Value);
    }
}
