namespace Kafka.Common.Model.Extensions
{
    public static class VersionRangeExtensions
    {
        public static IEnumerable<short> Enumerate(
            this VersionRange version
        )
        {
            for (var v = version.Min; v <= version.Max; v++)
                yield return v;
        }

        public static bool Includes(
            this VersionRange version,
            short value
        ) =>
            value >= version.Min &&
            value <= version.Max
        ;

        public static bool Some(this VersionRange version) =>
            version.Min <= version.Max
        ;

        public static bool None(this VersionRange version) =>
            version.Min > version.Max
        ;

        public static VersionRange Intersect(
            this VersionRange version,
            VersionRange other
        ) =>
            new(
                Math.Max(version.Min, other.Min),
                Math.Min(version.Max, other.Max)
            )
        ;
    }
}
