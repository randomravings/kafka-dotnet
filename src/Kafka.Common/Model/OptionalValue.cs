namespace Kafka.Common.Model
{
    public readonly record struct OptionalValue<T>(
        bool IsNull,
        T Value
    )
    {
#pragma warning disable CS8604 // Possible null reference argument.
        public static OptionalValue<T> Null { get; } = new(true, default);
        public static implicit operator OptionalValue<T>(T? value) => new(value == null, value);
#pragma warning restore CS8604 // Possible null reference argument.
    }
}
