using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateAclsRequest (
        CreateAclsRequest.AclCreation[] CreationsField
    )
    {
        public sealed record AclCreation (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte ResourcePatternTypeField,
            string PrincipalField,
            string HostField,
            sbyte OperationField,
            sbyte PermissionTypeField
        );
    };
}
