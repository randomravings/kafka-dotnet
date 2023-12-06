namespace Kafka.Common.Model
{
    public readonly record struct Partition(
        int Value
    )
    {
        public static readonly Partition Unassigned = new(-1);
        public static implicit operator Partition(int value) => new(value);
        public static implicit operator int(Partition value) => value.Value;
        public static bool operator <=(Partition a, Partition b) => a.Value <= b.Value;
        public static bool operator >=(Partition a, Partition b) => a.Value >= b.Value;
        public static bool operator <(Partition a, Partition b) => a.Value < b.Value;
        public static bool operator >(Partition a, Partition b) => a.Value > b.Value;
        public static Partition FromInt32(int value) => new(value);
        public int ToInt32() => Value;
        public int CompareTo(Partition other) => Value.CompareTo(other.Value);
    }
}
