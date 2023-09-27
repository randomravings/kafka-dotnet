namespace Kafka.Common.Model
{
    /// <summary>
    /// Unix timestamp (milliseconds).
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
        /// Creates a Create timestamp.
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static Timestamp Created(DateTimeOffset dateTimeOffset) =>
            new(TimestampType.CreateTime, dateTimeOffset.ToUnixTimeMilliseconds())
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
        /// Creates a Log Append Timestamp.
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static Timestamp LogAppend(DateTimeOffset dateTimeOffset) =>
            new(TimestampType.LogAppendTime, dateTimeOffset.ToUnixTimeMilliseconds())
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
        public static implicit operator DateTimeOffset(Timestamp timestamp) => DateTimeOffset.UnixEpoch.AddMilliseconds(timestamp.TimestampMs);

        public static Timestamp operator +(Timestamp timestamp, long ms) => new(timestamp.TimestampType, timestamp.TimestampMs + ms);
        public static Timestamp operator -(Timestamp timestamp, long ms) => new(timestamp.TimestampType, timestamp.TimestampMs - ms);
        public static Timestamp operator *(Timestamp timestamp, long ms) => new(timestamp.TimestampType, timestamp.TimestampMs * ms);
        public static Timestamp operator /(Timestamp timestamp, long ms) => new(timestamp.TimestampType, timestamp.TimestampMs / ms);
        public static Timestamp operator %(Timestamp timestamp, long ms) => new(timestamp.TimestampType, timestamp.TimestampMs % ms);
    }
}
