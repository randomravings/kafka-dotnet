using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    public enum PatternType
    {
        [EnumMember(Value = "UNKNOWN")]
        None = 0,

        [EnumMember(Value = "ANY")]
        Any = 1,

        [EnumMember(Value = "MATCH")]
        Match = 2,

        [EnumMember(Value = "LITERAL")]
        Literal = 3,

        [EnumMember(Value = "PREFIXED")]
        Prefixed = 4
    }
}
