using Kafka.Common.Records;

namespace Kafka.Common
{
    public readonly struct Timestamp
    {
        /// <summary>
        /// Creates a new timestamp.
        /// </summary>
        /// <param name="timestampType"></param>
        /// <param name="timestampMs"></param>
        public Timestamp(
            TimestampType timestampType,
            long timestampMs
        )
        {
            Type = timestampType;
            TimestampMs = timestampMs;
        }
        /// <summary>
        /// The type of timestamp.
        /// </summary>
        public readonly TimestampType Type { get; }
        /// <summary>
        /// Milliseconds from Unix Epoch.
        /// </summary>
        public readonly long TimestampMs { get; }
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
    }
}
