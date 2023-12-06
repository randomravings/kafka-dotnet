namespace Kafka.Common.Model
{
    public readonly record struct Epoch(
        int Value
    )
    {
        public static readonly Epoch None = new(-1);
        public static implicit operator Epoch(int value) => new(value);
        public static implicit operator int(Epoch value) => value.Value;
        public static bool operator <=(Epoch a, Epoch b) => a.Value <= b.Value;
        public static bool operator >=(Epoch a, Epoch b) => a.Value >= b.Value;
        public static bool operator <(Epoch a, Epoch b) => a.Value < b.Value;
        public static bool operator >(Epoch a, Epoch b) => a.Value > b.Value;
        public static Epoch FromInt32(int value) => new(value);
        public int ToInt32() => Value;
        public int CompareTo(Epoch other) => Value.CompareTo(other.Value);
    }
}
