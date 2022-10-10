using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SyncGroupResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ProtocolTypeField,
        string ProtocolNameField,
        byte[] AssignmentField
    );
}
