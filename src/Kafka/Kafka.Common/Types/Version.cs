namespace Kafka.Common.Types
{
    public readonly record struct Version(
        short Min,
        short Max
    )
    {
        public static readonly Version Empty =
            new(short.MaxValue, short.MinValue)
        ;
        public static readonly Version All =
            new(short.MinValue, short.MaxValue)
        ;
        public bool Some() =>
            Min <= Max
        ;
        public bool None() =>
            Min > Max
        ;
        public Version Intersect(
            Version other
        ) =>
            new(
                Math.Max(Min, other.Min),
                Math.Min(Max, other.Max)
            )
        ;
        public static Version Between(
            short min,
            short max
        ) => new(min, max);
        public static Version Exactly(
            short version
        ) => new(version, version);
        public static Version From(
            short version
        ) => new(version, short.MaxValue);
    }
}
