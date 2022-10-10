using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record JoinGroupResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        int GenerationIdField,
        string ProtocolTypeField,
        string ProtocolNameField,
        string LeaderField,
        bool SkipAssignmentField,
        string MemberIdField,
        JoinGroupResponse.JoinGroupResponseMember[] MembersField
    )
    {
        public sealed record JoinGroupResponseMember (
            string MemberIdField,
            string GroupInstanceIdField,
            byte[] MetadataField
        );
    };
}
