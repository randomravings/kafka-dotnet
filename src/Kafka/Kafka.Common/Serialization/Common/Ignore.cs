namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Singleton value for ignoring value.
    /// </summary>
    public sealed record Ignore()
    {
        public static Ignore Value { get; } = new();
    }
}