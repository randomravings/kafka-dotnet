namespace Kafka.Common.Types
{
    public readonly record struct ClusterId(
        string Value
    )
    {
        public static readonly ClusterId Empty = new("");
        public static implicit operator ClusterId(string value) => new(value);
        public static implicit operator string(ClusterId value) => value.Value;
        public static bool operator <=(ClusterId a, ClusterId b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => true,
            }
        ;
        public static bool operator >=(ClusterId a, ClusterId b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => true,
            }
        ;
        public static bool operator <(ClusterId a, ClusterId b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => true,
                1 => false,
                _ => false,
            }
        ;
        public static bool operator >(ClusterId a, ClusterId b) =>
            string.CompareOrdinal(a.Value, b.Value) switch
            {
                -1 => false,
                1 => true,
                _ => false,
            }
        ;
    }
}
