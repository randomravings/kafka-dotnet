namespace Kafka.Common.Model
{
    public readonly record struct ApiVersion(
        short Value
    )
    {
        public static implicit operator ApiVersion(short value) => new(value);
        public static implicit operator short(ApiVersion value) => value.Value;
        public static bool operator >=(ApiVersion a, ApiVersion b) => a.Value >= b.Value;
        public static bool operator <=(ApiVersion a, ApiVersion b) => a.Value <= b.Value;
        public static bool operator >(ApiVersion a, ApiVersion b) => a.Value > b.Value;
        public static bool operator <(ApiVersion a, ApiVersion b) => a.Value < b.Value;
        public static ApiVersion FromInt16(short value) => new(value);
        public int ToInt16() => Value;
        public int CompareTo(ApiVersion other) => Value.CompareTo(other.Value);
    }
}
