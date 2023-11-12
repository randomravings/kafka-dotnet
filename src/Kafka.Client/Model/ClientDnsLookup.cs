using System.Runtime.Serialization;

namespace Kafka.Client.Model
{
    public enum ClientDnsLookup
    {
        [EnumMember(Value = "use_all_dns_ips")]
        UseAllDnsIps,

        [EnumMember(Value = "resolve_canonical_bootstrap_servers_only")]
        ResolveCanonicalBootstrapServersOnly
    }
}
