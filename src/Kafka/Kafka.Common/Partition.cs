namespace Kafka.Common
{
    public readonly struct Partition :
        IEquatable<Partition>,
        IEquatable<int>
    {
        public static readonly Partition Any = new(-1);
        private readonly int _value;
        public Partition(int value) => _value = value;
        public static implicit operator Partition(int value) => new(value);
        public static implicit operator int(Partition value) => value._value;
        public static bool operator ==(Partition a, Partition b) => a._value == b._value;
        public static bool operator !=(Partition a, Partition b) => a._value != b._value;
        public static bool operator <=(Partition a, Partition b) => a._value <= b._value;
        public static bool operator >=(Partition a, Partition b) => a._value >= b._value;
        public static bool operator <(Partition a, Partition b) => a._value < b._value;
        public static bool operator >(Partition a, Partition b) => a._value > b._value;
        public bool Equals(Partition other) => _value == other._value;
        public bool Equals(int other) => _value == other;
        public override bool Equals(object? obj) =>
            obj switch
            {
                Partition o => o._value == _value,
                int l => _value == l,
                _ => false
            }
        ;
        public override int GetHashCode() =>
            HashCode.Combine(_value)
        ;
    }
}
