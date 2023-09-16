using System.Runtime.Serialization;

namespace Kafka.Client.Model
{
    public enum IsolationLevel : int
    {
        [EnumMember(Value = "read_uncommitted")]
        ReadUncommitted = 0,
        [EnumMember(Value = "read_committed")]
        ReadCommitted = 1,
    }
}
