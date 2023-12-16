using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    [DefaultValue(Plaintext)]
    public enum SecurityProtocol
    {

        [EnumMember(Value = "NONE")]
        None = -1,
        [EnumMember(Value = "PLAINTEXT")]
        Plaintext = 0,
        [EnumMember(Value = "SASL_SSL")]
        SaslSsl = 1,
        [EnumMember(Value = "SSL")]
        Ssl = 2,
        [EnumMember(Value = "SASL_PLAINTEXT")]
        SaslPlaintext = 3,
    }
}
