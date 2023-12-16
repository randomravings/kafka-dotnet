using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [Flags]
    [DefaultValue(None)]
    public enum Attributes : int
    {
        /// <summary>
        /// Default value.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,
        /// <summary>
        /// Value for GZip compression.
        /// </summary>
        [EnumMember(Value = "GZIP")]
        Gzip = 1,
        /// <summary>
        /// Value for Snappy compression.
        /// </summary>
        [EnumMember(Value = "SNAPPY")] 
        Snappy = 2,
        /// <summary>
        /// Value for LZ4 compression.
        /// </summary>
        [EnumMember(Value = "LZ4")] 
        LZ4 = 3,
        /// <summary>
        /// Value for ZSTD compression.
        /// </summary>
        [EnumMember(Value = "ZSTD")] 
        ZSTD = 4,
        /// <summary>
        /// Mask to be used for bitwise compare to determine timestamp type.
        /// </summary>
        [EnumMember(Value = "LOG_APPEND_TIME")]
        LogAppendTime = 8,
        /// <summary>
        /// IsTransactional Flag.
        /// </summary>
        [EnumMember(Value = "IS_TRANSACTIONAL")] 
        IsTransactional = 16,
        /// <summary>
        /// IsControlBatch Flag.
        /// </summary>
        [EnumMember(Value = "IS_CONTROL_BATCH")] 
        IsControlBatch = 32,
        /// <summary>
        /// HasDeleteHorizonMs Flag.
        /// </summary>
        [EnumMember(Value = "HAS_DELETE_HORIZON_MS")] 
        HasDeleteHorizonMs = 64
    }
}
