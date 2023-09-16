namespace Kafka.Common.Model
{
    /// <summary>
    /// Null value as a type.
    /// </summary>
    public readonly record struct Null()
    {
        public static Null Value { get; } = new();
    }
}