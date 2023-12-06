namespace Kafka.Common.Model
{
    public readonly record struct Offset(
        long Value
    )
    {
        public static readonly Offset Beginning = new(-2L);
        public static readonly Offset End = new(-1L);
        public static readonly Offset Stored = new(-1000L);
        public static readonly Offset Unset = new(-1001L);
        public static readonly Offset Zero = new(0L);
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
        public static Offset operator %(Offset a, Offset b) => new(a.Value % b.Value);
        public static Offset operator +(Offset a, long b) => new(a.Value + b);
        public static Offset operator -(Offset a, long b) => new(a.Value - b);
        public static Offset operator +(Offset a, int b) => new(a.Value + b);
        public static Offset operator -(Offset a, int b) => new(a.Value - b);
        public static Offset operator *(Offset a, long b) => new(a.Value * b);
        public static Offset operator /(Offset a, long b) => new(a.Value / b);
        public static Offset operator %(Offset a, long b) => new(a.Value % b);
        public static Offset operator ++(Offset a) => new(a.Value + 1);
        public static Offset operator --(Offset a) => new(a.Value - 1);

        public int CompareTo(Offset other) =>
            Value.CompareTo(other.Value)
        ;

        public int CompareTo(long value) =>
            Value.CompareTo(value)
        ;

        public long ToInt64() =>
            Value
        ;

        public static Offset ToOffset(long value) =>
            new(value)
        ;

        public static Offset Add(Offset left, Offset right) =>
            new(left.Value + right.Value)
        ;

        public static Offset Add(Offset left, long value) =>
            new(left.Value + value)
        ;

        public static Offset Subtract(Offset left, Offset right) =>
            new(left.Value - right.Value)
        ;

        public static Offset Subtract(Offset left, long value) =>
            new(left.Value - value)
        ;

        public static Offset Multiply(Offset left, Offset right) =>
            new(left.Value * right.Value)
        ;

        public static Offset Multiply(Offset left, long value) =>
            new(left.Value * value)
        ;

        public static Offset Divide(Offset left, Offset right) =>
            new(left.Value / right.Value)
        ;

        public static Offset Divide(Offset left, long value) =>
            new(left.Value / value)
        ;

        public static Offset Mod(Offset left, Offset right) =>
            new(left.Value % right.Value)
        ;

        public static Offset Mod(Offset left, long value) =>
            new(left.Value % value)
        ;

        public static Offset Increment(Offset offset) =>
            new(offset.Value + 1)
        ;

        public static Offset Decrement(Offset offset) =>
            new(offset.Value - 1)
        ;
    }
}
