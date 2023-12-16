using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    public enum ConsumerGroupState
    {
        Unknown,
        Stable,
        PreparingRebalance,
        CompletingRebalance,
        Empty,
        Dead,
    }
}
