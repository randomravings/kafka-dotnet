using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SyncGroupRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string GroupInstanceIdField,
        string ProtocolTypeField,
        string ProtocolNameField,
        SyncGroupRequest.SyncGroupRequestAssignment[] AssignmentsField
    )
    {
        public sealed record SyncGroupRequestAssignment (
            string MemberIdField,
            byte[] AssignmentField
        );
    };
}
