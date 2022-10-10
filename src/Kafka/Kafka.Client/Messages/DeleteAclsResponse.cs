using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteAclsResponse (
        int ThrottleTimeMsField,
        DeleteAclsResponse.DeleteAclsFilterResult[] FilterResultsField
    )
    {
        public sealed record DeleteAclsFilterResult (
            short ErrorCodeField,
            string ErrorMessageField,
            DeleteAclsResponse.DeleteAclsFilterResult.DeleteAclsMatchingAcl[] MatchingAclsField
        )
        {
            public sealed record DeleteAclsMatchingAcl (
                short ErrorCodeField,
                string ErrorMessageField,
                sbyte ResourceTypeField,
                string ResourceNameField,
                sbyte PatternTypeField,
                string PrincipalField,
                string HostField,
                sbyte OperationField,
                sbyte PermissionTypeField
            );
        };
    };
}
