namespace Kafka.Common.Model
{
    public readonly record struct Filter(
        string? Value
    )
    {
        public bool IsEmpty => string.IsNullOrEmpty(Value);
        public static readonly Filter Empty = new(null);
        public static implicit operator Filter(string? value) => new(value);
        public static implicit operator string?(Filter filter) => filter.Value;
        public static Filter FromString(string? value) => new(value);
    }
}
