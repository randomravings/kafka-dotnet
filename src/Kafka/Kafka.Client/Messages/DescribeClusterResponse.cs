using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClusterResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        string ClusterIdField,
        int ControllerIdField,
        DescribeClusterResponse.DescribeClusterBroker[] BrokersField,
        int ClusterAuthorizedOperationsField
    )
    {
        public sealed record DescribeClusterBroker (
            int BrokerIdField,
            string HostField,
            int PortField,
            string RackField
        );
    };
}
