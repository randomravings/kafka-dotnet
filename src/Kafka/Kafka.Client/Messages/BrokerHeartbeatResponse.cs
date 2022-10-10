using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerHeartbeatResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        bool IsCaughtUpField,
        bool IsFencedField,
        bool ShouldShutDownField
    );
}
