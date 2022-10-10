using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteAclsRequest (
        DeleteAclsRequest.DeleteAclsFilter[] FiltersField
    )
    {
        public sealed record DeleteAclsFilter (
            sbyte ResourceTypeFilterField,
            string ResourceNameFilterField,
            sbyte PatternTypeFilterField,
            string PrincipalFilterField,
            string HostFilterField,
            sbyte OperationField,
            sbyte PermissionTypeField
        );
    };
}
