using System.Runtime.Serialization;

namespace Kafka.Common.Model
{
    public enum SecurityProtocol
    {
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
