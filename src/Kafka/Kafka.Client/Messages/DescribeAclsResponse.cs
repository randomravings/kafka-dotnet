using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeAclsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        DescribeAclsResponse.DescribeAclsResource[] ResourcesField
    )
    {
        public sealed record DescribeAclsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte PatternTypeField,
            DescribeAclsResponse.DescribeAclsResource.AclDescription[] AclsField
        )
        {
            public sealed record AclDescription (
                string PrincipalField,
                string HostField,
                sbyte OperationField,
                sbyte PermissionTypeField
            );
        };
    };
}
