namespace Kafka.Common.Types.Extensions
{
    public static class VersionExtensions
    {
        public static Version Constrain(
            this Version version,
            Version constrainingVersion
        ) =>
            Version.Between(
                Math.Max(version.Min, constrainingVersion.Min),
                Math.Min(version.Max, constrainingVersion.Max)
            )
        ;

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
    }
}
