namespace Kafka.Common.Types.Extensions
{
    public static class VersionExtensions
    {
        public static IEnumerable<short> Enumerate(
            this Version version
        )
        {
            for (var v = version.Min; v <= version.Max; v++)
                yield return v;
        }

        public static bool Includes(
            this Version version,
            short value
        ) =>
            value >= version.Min &&
            value <= version.Max
        ;

        public static bool Some(this Version version) =>
            version.Min <= version.Max
        ;

        public static bool None(this Version version) =>
            version.Min > version.Max
        ;

        public static Version Intersect(
            this Version version,
            Version other
        ) =>
            new(
                Math.Max(version.Min, other.Min),
                Math.Min(version.Max, other.Max)
            )
        ;
    }
}
