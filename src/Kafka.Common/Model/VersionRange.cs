namespace Kafka.Common.Model
{
    public readonly record struct VersionRange(
        ApiVersion Min,
        ApiVersion Max
    )
    {
        public static readonly VersionRange Empty =
            new(short.MaxValue, short.MinValue)
        ;
        public static readonly VersionRange All =
            new(short.MinValue, short.MaxValue)
        ;
    }
}
