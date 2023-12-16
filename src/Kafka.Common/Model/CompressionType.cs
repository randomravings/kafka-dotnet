using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum CompressionType : int
    {
        [EnumMember(Value = "NONE")]
        None = 0,
        [EnumMember(Value = "GZIP")]
        Gzip = 1,
        [EnumMember(Value = "SNAPPY")]
        Snappy = 2,
        [EnumMember(Value = "LZ4")]
        LZ4 = 3,
        [EnumMember(Value = "ZSTD")]
        ZSTD = 4
    }
}
