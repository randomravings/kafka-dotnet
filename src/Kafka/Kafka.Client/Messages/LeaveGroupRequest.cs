using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaveGroupRequest (
        string GroupIdField,
        string MemberIdField,
        LeaveGroupRequest.MemberIdentity[] MembersField
    )
    {
        public sealed record MemberIdentity (
            string MemberIdField,
            string GroupInstanceIdField,
            string ReasonField
        );
    };
}
