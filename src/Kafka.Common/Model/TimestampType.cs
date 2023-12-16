using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(CreateTime)]
    public enum TimestampType : int
    {
        [EnumMember(Value = "NOT_SPECIFIED")]
        None = -1,
        [EnumMember(Value = "CREATE_TIME")]
        CreateTime = 0,
        [EnumMember(Value = "LOG_APPEND_TIME")]
        LogAppendTime = 16,
    }
}
