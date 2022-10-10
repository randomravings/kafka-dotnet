namespace Kafka.Common
{
    public readonly struct Offset :
        IEquatable<Offset>,
        IEquatable<long>
    {
        public static readonly Offset Beginning = new(-1L);
        public static readonly Offset End = new(-2L);
        public static readonly Offset Stored = new(-1000L);
        public static readonly Offset Unset = new(-1001L);
        private readonly long _value;
        public Offset(long value) => _value = value;
        public static implicit operator Offset(long value) => new(value);
        public static implicit operator long(Offset value) => value._value;
        public static bool operator ==(Offset a, Offset b) => a._value == b._value;
        public static bool operator !=(Offset a, Offset b) => a._value != b._value;
        public static bool operator >=(Offset a, Offset b) => a._value >= b._value;
        public static bool operator <=(Offset a, Offset b) => a._value <= b._value;
        public static bool operator >(Offset a, Offset b) => a._value > b._value;
        public static bool operator <(Offset a, Offset b) => a._value < b._value;
        public static Offset operator +(Offset a, Offset b) => new(a._value + b._value);
        public static Offset operator -(Offset a, Offset b) => new(a._value - b._value);
        public static Offset operator *(Offset a, Offset b) => new(a._value * b._value);
        public static Offset operator /(Offset a, Offset b) => new(a._value / b._value);
        public static Offset operator +(Offset a, long b) => new(a._value + b);
        public static Offset operator -(Offset a, long b) => new(a._value - b);
        public static Offset operator *(Offset a, long b) => new(a._value * b);
        public static Offset operator /(Offset a, long b) => new(a._value / b);
        public bool Equals(Offset other) => _value == other._value;
        public bool Equals(long other) => _value == other;
        public override bool Equals(object? obj) =>
            obj switch
            {
                Offset o => o._value == _value,
                long l => _value == l,
                _ => false
            }
        ;
        public override int GetHashCode() =>
            HashCode.Combine(_value)
        ;
    }
}
