using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(GssApi)]
    public enum SaslMechanism
    {
        [EnumMember(Value = "NONE")]
        None = -1,
        [EnumMember(Value = "GSSAPI")]
        GssApi = 0,
        [EnumMember(Value = "PLAIN")]
        Plain = 1,
        [EnumMember(Value = "SCRAM-SHA-256")]
        ScramSha256,
        [EnumMember(Value = "SCRAM-SHA-512")]
        ScramSha512,
        [EnumMember(Value = "OAUTHBEARER")]
        OAuthBearer
    }
}
