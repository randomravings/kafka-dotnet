using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    public enum ResourceType
    {
        [EnumMember(Value = "UNKNOWN")]
        None = 0,

        [EnumMember(Value = "ANY")]
        Any = 1,

        [EnumMember(Value = "TOPIC")]
        Topic = 2,

        [EnumMember(Value = "GROUP")]
        Group = 3,

        [EnumMember(Value = "CLUSTER")]
        Cluster = 4,

        [EnumMember(Value = "TRANSACTIONAL_ID")]
        TransactionalId = 5,

        [EnumMember(Value = "DELEGATION_TOKEN")]
        DelegationToken = 6,

        [EnumMember(Value = "USER")]
        User = 7
    }
}