using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DeleteAclsFilter = Kafka.Client.Messages.DeleteAclsRequest.DeleteAclsFilter;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="FiltersField">The filters to use when deleting ACLs.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteAclsRequest (
        ImmutableArray<DeleteAclsFilter> FiltersField
    ) : Request(31)
    {
        public static DeleteAclsRequest Empty { get; } = new(
            ImmutableArray<DeleteAclsFilter>.Empty
        );
        /// <summary>
        /// <param name="ResourceTypeFilterField">The resource type.</param>
        /// <param name="ResourceNameFilterField">The resource name.</param>
        /// <param name="PatternTypeFilterField">The pattern type.</param>
        /// <param name="PrincipalFilterField">The principal filter, or null to accept all principals.</param>
        /// <param name="HostFilterField">The host filter, or null to accept all hosts.</param>
        /// <param name="OperationField">The ACL operation.</param>
        /// <param name="PermissionTypeField">The permission type.</param>
        /// </summary>
        public sealed record DeleteAclsFilter (
            sbyte ResourceTypeFilterField,
            string? ResourceNameFilterField,
            sbyte PatternTypeFilterField,
            string? PrincipalFilterField,
            string? HostFilterField,
            sbyte OperationField,
            sbyte PermissionTypeField
        )
        {
            public static DeleteAclsFilter Empty { get; } = new(
                default(sbyte),
                default(string?),
                default(sbyte),
                default(string?),
                default(string?),
                default(sbyte),
                default(sbyte)
            );
        };
    };
}