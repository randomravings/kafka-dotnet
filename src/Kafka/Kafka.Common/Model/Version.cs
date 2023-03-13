namespace Kafka.Common.Model
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
    }
}
