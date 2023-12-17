using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteAclsFilter = Kafka.Client.Messages.DeleteAclsRequestData.DeleteAclsFilter;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="FiltersField">The filters to use when deleting ACLs.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteAclsRequestData (
        ImmutableArray<DeleteAclsFilter> FiltersField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DeleteAclsRequestData Empty { get; } = new(
            ImmutableArray<DeleteAclsFilter>.Empty,
            ImmutableArray<TaggedField>.Empty
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
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeleteAclsFilter (
            sbyte ResourceTypeFilterField,
            string? ResourceNameFilterField,
            sbyte PatternTypeFilterField,
            string? PrincipalFilterField,
            string? HostFilterField,
            sbyte OperationField,
            sbyte PermissionTypeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeleteAclsFilter Empty { get; } = new(
                default(sbyte),
                default(string?),
                default(sbyte),
                default(string?),
                default(string?),
                default(sbyte),
                default(sbyte),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
