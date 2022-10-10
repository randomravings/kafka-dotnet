using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeAclsRequest (
        sbyte ResourceTypeFilterField,
        string ResourceNameFilterField,
        sbyte PatternTypeFilterField,
        string PrincipalFilterField,
        string HostFilterField,
        sbyte OperationField,
        sbyte PermissionTypeField
    );
}
