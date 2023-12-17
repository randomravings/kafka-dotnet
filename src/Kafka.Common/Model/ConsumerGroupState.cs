using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum ConsumerGroupState
    {
        [EnumMember(Value = "UNKNOWN")]
        None,
        [EnumMember(Value = "EMPTY")]
        Empty,
        [EnumMember(Value = "STABLE")]
        Stable,
        [EnumMember(Value = "PREPARINGRE_BALANCE")]
        PreparingRebalance,
        [EnumMember(Value = "COMPLETING_REBALANCE")]
        CompletingRebalance,
        [EnumMember(Value = "DEAD")]
        Dead
    }
}
