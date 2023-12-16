using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum CoordinatorType : int
    {
        [EnumMember(Value = "NONE")]
        None = -1,
        [EnumMember(Value = "GROUP")]
        Group = 0,
        [EnumMember(Value = "TRANSACTION")]
        Transaction = 1
    }
}
