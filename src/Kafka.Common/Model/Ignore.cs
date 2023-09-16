namespace Kafka.Common.Model
{
    /// <summary>
    /// Singleton value for ignoring value.
    /// </summary>
    public readonly record struct Ignore()
    {
        public static Ignore Value { get; } = new();
    }
}