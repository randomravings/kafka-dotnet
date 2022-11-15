namespace Kafka.Common.Types
{
    public readonly record struct Topic(
        string Value
    )
    {
        public static readonly Topic Empty = new("");
        public static implicit operator Topic(string value) => new(value);
        public static implicit operator string(Topic value) => value.Value;
        public static bool operator <=(Topic a, Topic b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => true,
            }
        ;
        public static bool operator >=(Topic a, Topic b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => true,
            }
        ;
        public static bool operator <(Topic a, Topic b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => false,
            }
        ;
        public static bool operator >(Topic a, Topic b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => false,
            }
        ;
    }
}
