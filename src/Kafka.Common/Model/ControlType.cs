using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum ControlType : int
    {
        [EnumMember(Value = "NONE")]
        None = -1,
        [EnumMember(Value = "ABORT")]
        Abort = 0,
        [EnumMember(Value = "COMMIT")]
        Commit = 1
    }
}
