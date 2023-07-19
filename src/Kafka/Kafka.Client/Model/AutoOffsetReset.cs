using System.Runtime.Serialization;

namespace Kafka.Client.Model
{
    public enum AutoOffsetReset : int
    {
        [EnumMember(Value = "none")]
        None = 0,
        [EnumMember(Value = "earliest")]
        Earliest = 1,
        [EnumMember(Value = "latest")]
        Latest = 2
    }
}
