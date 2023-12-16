using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [Flags]
    public enum AclOperation
    {
        [EnumMember(Value = "UNKNOWN")]
        None = 0x0,

        [EnumMember(Value = "ANY")]
        Any = 0x1,

        [EnumMember(Value = "ALL")]
        All = 0x2,

        [EnumMember(Value = "READ")]
        Read = 0x4,

        [EnumMember(Value = "WRITE")]
        Write = 0x8,

        [EnumMember(Value = "CREATE")]
        Create = 0x10,

        [EnumMember(Value = "DELETE")]
        Delete = 0x20,

        [EnumMember(Value = "ALTER")]
        Alter = 0x40,

        [EnumMember(Value = "DESCRIBE")]
        Describe = 0x80,

        [EnumMember(Value = "CLUSTER_ACTION")]
        ClusterAction = 0x100,

        [EnumMember(Value = "DESCRIBE_CONFIGS")]
        DescribeConfigs = 0x200,

        [EnumMember(Value = "ALTER_CONFIGS")]
        AlterConfigs = 0x400,

        [EnumMember(Value = "IDEMPOTENT_WRITE")]
        IdempotentWrite = 0x800,

        [EnumMember(Value = "CREATE_TOKENS")]
        CreateTokens = 0x1000,

        [EnumMember(Value = "DESCRIBE_TOKENS")]
        DescribeTokens = 0x2000
    }
}
