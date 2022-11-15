namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Null value as a type.
    /// </summary>
    public sealed record Null()
    {
        public static Null Value { get; } = new();
    }
}