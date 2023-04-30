using Kafka.Common.Records;

namespace Kafka.Common.Model
{
    /// <summary>
    /// Creates a new timestamp.
    /// </summary>
    /// <param name="timestampType">The type of timestamp.</param>
    /// <param name="timestampMs">Milliseconds from Unix Epoch.</param>
    public readonly record struct Timestamp(
        TimestampType TimestampType,
        long TimestampMs
    )
    {
        public static Timestamp None { get; } =
            new(TimestampType.None, 0)
        ;

        /// <summary>
        /// Creates a Create timestamp.
        /// </summary>
        /// <param name="timestampMs"></param>
        /// <returns></returns>
        public static Timestamp Created(long timestampMs) =>
            new(TimestampType.CreateTime, timestampMs)
        ;
        /// <summary>
        /// Creates a Log Append Timestamp.
        /// </summary>
        /// <param name="timestampMs"></param>
        /// <returns></returns>
        public static Timestamp LogAppend(long timestampMs) =>
            new(TimestampType.LogAppendTime, timestampMs)
        ;

        /// <summary>
        /// Creates a current Create timestamp based on system UTC clock.
        /// </summary>
        /// <returns></returns>
        public static Timestamp Now() =>
            new(TimestampType.CreateTime, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        ;

        public static bool operator >=(Timestamp a, Timestamp b) => a.TimestampMs >= b.TimestampMs;
        public static bool operator <=(Timestamp a, Timestamp b) => a.TimestampMs <= b.TimestampMs;
        public static bool operator >(Timestamp a, Timestamp b) => a.TimestampMs > b.TimestampMs;
        public static bool operator <(Timestamp a, Timestamp b) => a.TimestampMs < b.TimestampMs;

        public static implicit operator long(Timestamp timestamp) => timestamp.TimestampMs;
    }
}
