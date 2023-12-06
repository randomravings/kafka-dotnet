namespace Kafka.Common.Model
{
    /// <summary>
    /// Unix timestamp (milliseconds).
    /// </summary>
    /// <param name="Type">The type of timestamp.</param>
    /// <param name="Millisconds">Millisconds from Unix Epoch.</param>
    public readonly record struct Timestamp(
        TimestampType Type,
        long Millisconds
    )
    {
        public static Timestamp None { get; } =
            new(TimestampType.None, 0)
        ;

        /// <summary>
        /// Creates a Create timestamp.
        /// </summary>
        /// <param name="Millisconds"></param>
        /// <returns></returns>
        public static Timestamp Created(long Millisconds) =>
            new(TimestampType.CreateTime, Millisconds)
        ;

        /// <summary>
        /// Creates a Create timestamp.
        /// </summary>
        /// <param name="dateTimeTimestamp"></param>
        /// <returns></returns>
        public static Timestamp Created(DateTimeOffset dateTimeTimestamp) =>
            new(TimestampType.CreateTime, dateTimeTimestamp.ToUnixTimeMilliseconds())
        ;

        /// <summary>
        /// Creates a Log Append Timestamp.
        /// </summary>
        /// <param name="Millisconds"></param>
        /// <returns></returns>
        public static Timestamp LogAppend(long Millisconds) =>
            new(TimestampType.LogAppendTime, Millisconds)
        ;

        /// <summary>
        /// Creates a Log Append Timestamp.
        /// </summary>
        /// <param name="dateTimeTimestamp"></param>
        /// <returns></returns>
        public static Timestamp LogAppend(DateTimeOffset dateTimeTimestamp) =>
            new(TimestampType.LogAppendTime, dateTimeTimestamp.ToUnixTimeMilliseconds())
        ;

        /// <summary>
        /// Creates a current Create timestamp based on system UTC clock.
        /// </summary>
        /// <returns></returns>
        public static Timestamp Now() =>
            new(TimestampType.CreateTime, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        ;

        public static implicit operator long(Timestamp timestamp) => timestamp.Millisconds;
        public static implicit operator DateTimeOffset(Timestamp timestamp) => DateTimeOffset.UnixEpoch.AddMilliseconds(timestamp.Millisconds);
        public static bool operator >=(Timestamp a, Timestamp b) => a.Millisconds >= b.Millisconds;
        public static bool operator <=(Timestamp a, Timestamp b) => a.Millisconds <= b.Millisconds;
        public static bool operator >(Timestamp a, Timestamp b) => a.Millisconds > b.Millisconds;
        public static bool operator <(Timestamp a, Timestamp b) => a.Millisconds < b.Millisconds;
        public static Timestamp operator +(Timestamp left, Timestamp right) => new(left.Type, left.Millisconds + right);
        public static Timestamp operator -(Timestamp left, Timestamp right) => new(left.Type, left.Millisconds - right);
        public static Timestamp operator *(Timestamp left, Timestamp right) => new(left.Type, left.Millisconds * right);
        public static Timestamp operator /(Timestamp left, Timestamp right) => new(left.Type, left.Millisconds / right);
        public static Timestamp operator %(Timestamp left, Timestamp right) => new(left.Type, left.Millisconds % right);
        public static Timestamp operator +(Timestamp timestamp, long ms) => new(timestamp.Type, timestamp.Millisconds + ms);
        public static Timestamp operator -(Timestamp timestamp, long ms) => new(timestamp.Type, timestamp.Millisconds - ms);
        public static Timestamp operator *(Timestamp timestamp, long ms) => new(timestamp.Type, timestamp.Millisconds * ms);
        public static Timestamp operator /(Timestamp timestamp, long ms) => new(timestamp.Type, timestamp.Millisconds / ms);
        public static Timestamp operator %(Timestamp timestamp, long ms) => new(timestamp.Type, timestamp.Millisconds % ms);

        public int CompareTo(Timestamp other) =>
            Millisconds.CompareTo(other.Millisconds)
        ;

        public int CompareTo(long value) =>
            Millisconds.CompareTo(value)
        ;

        public long ToInt64() =>
            Millisconds
        ;

        public DateTimeOffset ToDateTimeOffset() =>
            DateTimeOffset.UnixEpoch.AddMilliseconds(Millisconds)
        ;

        public static Timestamp ToTimestamp(long value) =>
            new(TimestampType.CreateTime, value)
        ;

        public static Timestamp Add(Timestamp left, Timestamp right) =>
            new(left.Type, left.Millisconds + right.Millisconds)
        ;

        public static Timestamp Add(Timestamp left, long value) =>
            new(left.Type, left.Millisconds + value)
        ;

        public static Timestamp Subtract(Timestamp left, Timestamp right) =>
            new(left.Type, left.Millisconds - right.Millisconds)
        ;

        public static Timestamp Subtract(Timestamp left, long value) =>
            new(left.Type, left.Millisconds - value)
        ;

        public static Timestamp Multiply(Timestamp left, Timestamp right) =>
            new(left.Type, left.Millisconds * right.Millisconds)
        ;

        public static Timestamp Multiply(Timestamp left, long value) =>
            new(left.Type, left.Millisconds * value)
        ;

        public static Timestamp Divide(Timestamp left, Timestamp right) =>
            new(left.Type, left.Millisconds / right.Millisconds)
        ;

        public static Timestamp Divide(Timestamp left, long value) =>
            new(left.Type, left.Millisconds / value)
        ;

        public static Timestamp Mod(Timestamp left, Timestamp right) =>
            new(left.Type, left.Millisconds % right.Millisconds)
        ;

        public static Timestamp Mod(Timestamp left, long value) =>
            new(left.Type, left.Millisconds % value)
        ;

        public static Timestamp Increment(Timestamp timestamp) =>
            new(timestamp.Type, timestamp.Millisconds + 1)
        ;

        public static Timestamp Decrement(Timestamp timestamp) =>
            new(timestamp.Type, timestamp.Millisconds - 1)
        ;
    }
}
