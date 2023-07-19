namespace Kafka.Common.Model
{
    public readonly record struct VersionRange(
        Version Min,
        Version Max
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
