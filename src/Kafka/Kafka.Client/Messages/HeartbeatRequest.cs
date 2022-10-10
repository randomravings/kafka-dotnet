using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record HeartbeatRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string GroupInstanceIdField
    );
}
