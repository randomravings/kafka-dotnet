using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ResourceTypeFilterField">The resource type.</param>
    /// <param name="ResourceNameFilterField">The resource name, or null to match any resource name.</param>
    /// <param name="PatternTypeFilterField">The resource pattern to match.</param>
    /// <param name="PrincipalFilterField">The principal to match, or null to match any principal.</param>
    /// <param name="HostFilterField">The host to match, or null to match any host.</param>
    /// <param name="OperationField">The operation to match.</param>
    /// <param name="PermissionTypeField">The permission type to match.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DescribeAclsRequestData (
        sbyte ResourceTypeFilterField,
        string? ResourceNameFilterField,
        sbyte PatternTypeFilterField,
        string? PrincipalFilterField,
        string? HostFilterField,
        sbyte OperationField,
        sbyte PermissionTypeField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DescribeAclsRequestData Empty { get; } = new(
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
}
