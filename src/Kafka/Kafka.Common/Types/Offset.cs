namespace Kafka.Common.Types
{
    public readonly record struct Offset(
        long Value
    )
    {
        public static readonly Offset Beginning = new(-1L);
        public static readonly Offset End = new(-2L);
        public static readonly Offset Stored = new(-1000L);
        public static readonly Offset Unset = new(-1001L);
        public static implicit operator Offset(long value) => new(value);
        public static implicit operator long(Offset value) => value.Value;
        public static bool operator >=(Offset a, Offset b) => a.Value >= b.Value;
        public static bool operator <=(Offset a, Offset b) => a.Value <= b.Value;
        public static bool operator >(Offset a, Offset b) => a.Value > b.Value;
        public static bool operator <(Offset a, Offset b) => a.Value < b.Value;
        public static Offset operator +(Offset a, Offset b) => new(a.Value + b.Value);
        public static Offset operator -(Offset a, Offset b) => new(a.Value - b.Value);
        public static Offset operator *(Offset a, Offset b) => new(a.Value * b.Value);
        public static Offset operator /(Offset a, Offset b) => new(a.Value / b.Value);
        public static Offset operator +(Offset a, long b) => new(a.Value + b);
        public static Offset operator -(Offset a, long b) => new(a.Value - b);
        public static Offset operator *(Offset a, long b) => new(a.Value * b);
        public static Offset operator /(Offset a, long b) => new(a.Value / b);
    }
}
