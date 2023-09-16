using System.Runtime.Serialization;

namespace Kafka.Client.Model
{
    public enum ClientDnsLookup
    {
        [EnumMember(Value = "use_all_dns_ips")]
        UseAllDnsIps,

        [EnumMember(Value = "use_all_dns_ips")]
        ResolveCanonicalBootstrapServersOnly
    }
}
