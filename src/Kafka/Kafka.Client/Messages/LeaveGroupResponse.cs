using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaveGroupResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        LeaveGroupResponse.MemberResponse[] MembersField
    )
    {
        public sealed record MemberResponse (
            string MemberIdField,
            string GroupInstanceIdField,
            short ErrorCodeField
        );
    };
}
