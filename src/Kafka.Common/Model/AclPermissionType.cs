using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    public enum AclPermissionType
    {
        [EnumMember(Value = "UNKNOWN")]
        None = 0,

        [EnumMember(Value = "ANY")]
        Any = 1,

        [EnumMember(Value = "DENY")]
        Deny = 2,

        [EnumMember(Value = "ALLOW")]
        Allow =  3
    }
}
