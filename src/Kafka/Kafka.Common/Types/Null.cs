namespace Kafka.Common.Types
{
    /// <summary>
    /// Null value as a type.
    /// </summary>
    public readonly record struct Null()
    {
        public static Null Value { get; } = new();
    }
}