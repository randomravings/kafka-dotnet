﻿namespace Kafka.Common.Model
{
    [Flags]
    public enum Attributes : int
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None = 0,
        /// <summary>
        /// Value for GZip compression.
        /// </summary>
        Gzip = 1,
        /// <summary>
        /// Value for Snappy compression.
        /// </summary>
        Snappy = 2,
        /// <summary>
        /// Value for LZ4 compression.
        /// </summary>
        LZ4 = 3,
        /// <summary>
        /// Value for ZSTD compression.
        /// </summary>
        ZSTD = 4,
        /// <summary>
        /// Mask to be used for bitwise compare to determine timestamp type.
        /// </summary>
        TimestampType = 8,
        /// <summary>
        /// IsTransactional Flag.
        /// </summary>
        IsTransactional = 16,
        /// <summary>
        /// IsControlBatch Flag.
        /// </summary>
        IsControlBatch = 32,
        /// <summary>
        /// HasDeleteHorizonMs Flag.
        /// </summary>
        HasDeleteHorizonMs = 64,
        /// <summary>
        /// Mask to be used for bitwise compare to determine compression used.
        /// </summary>
        CompressionType = Gzip | Snappy | LZ4 | ZSTD,
        /// <summary>
        /// Value for Log Append Time.
        /// </summary>
        LogAppendTime = TimestampType
    }
}
