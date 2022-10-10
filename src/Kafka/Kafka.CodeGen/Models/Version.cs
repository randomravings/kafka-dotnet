namespace Kafka.CodeGen.Models
{
    public readonly struct Version
    {
        private Version(
             short min,
             short max
         )
        {
            Min = min;
            Max = max;
        }
        public readonly short Min { get; }
        public readonly short Max { get; }
        public static Version Empty { get; } =
            new(short.MaxValue, short.MinValue)
        ;
        public static Version Any { get; } =
            new(short.MinValue, short.MaxValue)
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
