using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FindCoordinatorResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        int NodeIdField,
        string HostField,
        int PortField,
        FindCoordinatorResponse.Coordinator[] CoordinatorsField
    )
    {
        public sealed record Coordinator (
            string KeyField,
            int NodeIdField,
            string HostField,
            int PortField,
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
