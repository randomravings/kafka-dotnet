namespace Kafka.Common.Types
{
    public readonly record struct Partition(
        int Value
    )
    {
        public static readonly Partition Any = new(-1);
        public static implicit operator Partition(int value) => new(value);
        public static implicit operator int(Partition value) => value.Value;
        public static bool operator <=(Partition a, Partition b) => a.Value <= b.Value;
        public static bool operator >=(Partition a, Partition b) => a.Value >= b.Value;
        public static bool operator <(Partition a, Partition b) => a.Value < b.Value;
        public static bool operator >(Partition a, Partition b) => a.Value > b.Value;
    }
}
