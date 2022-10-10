using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeGroupsResponse (
        int ThrottleTimeMsField,
        DescribeGroupsResponse.DescribedGroup[] GroupsField
    )
    {
        public sealed record DescribedGroup (
            short ErrorCodeField,
            string GroupIdField,
            string GroupStateField,
            string ProtocolTypeField,
            string ProtocolDataField,
            DescribeGroupsResponse.DescribedGroup.DescribedGroupMember[] MembersField,
            int AuthorizedOperationsField
        )
        {
            public sealed record DescribedGroupMember (
                string MemberIdField,
                string GroupInstanceIdField,
                string ClientIdField,
                string ClientHostField,
                byte[] MemberMetadataField,
                byte[] MemberAssignmentField
            );
        };
    };
}
