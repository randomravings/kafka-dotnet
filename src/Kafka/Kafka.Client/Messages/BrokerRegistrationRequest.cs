using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerRegistrationRequest (
        int BrokerIdField,
        string ClusterIdField,
        Guid IncarnationIdField,
        BrokerRegistrationRequest.Listener[] ListenersField,
        BrokerRegistrationRequest.Feature[] FeaturesField,
        string RackField
    )
    {
        public sealed record Listener (
            string NameField,
            string HostField,
            ushort PortField,
            short SecurityProtocolField
        );
        public sealed record Feature (
            string NameField,
            short MinSupportedVersionField,
            short MaxSupportedVersionField
        );
    };
}
