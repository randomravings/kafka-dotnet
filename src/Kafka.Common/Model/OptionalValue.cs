namespace Kafka.Common.Model
{
    public readonly record struct OptionalValue<T>(
        T Value
    )
    {
        public bool IsNull { get => Value == null; }
    }
}
