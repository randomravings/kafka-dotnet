namespace Kafka.Common.Model
{
    public readonly record struct Version(
        short Value
    )
    {
        public static implicit operator Version(short value) => new(value);
        public static implicit operator short(Version value) => value.Value;
        public static bool operator >=(Version a, Version b) => a.Value >= b.Value;
        public static bool operator <=(Version a, Version b) => a.Value <= b.Value;
        public static bool operator >(Version a, Version b) => a.Value > b.Value;
        public static bool operator <(Version a, Version b) => a.Value < b.Value;
    }
}
