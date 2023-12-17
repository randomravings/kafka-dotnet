using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponseData.DescribeAclsResource.AclDescription;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponseData.DescribeAclsResource;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
    /// <param name="ResourcesField">Each Resource that is referenced in an ACL.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DescribeAclsResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<DescribeAclsResource> ResourcesField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static DescribeAclsResponseData Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<DescribeAclsResource>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// <param name="PatternTypeField">The resource pattern type.</param>
        /// <param name="AclsField">The ACLs.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DescribeAclsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte PatternTypeField,
            ImmutableArray<AclDescription> AclsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DescribeAclsResource Empty { get; } = new(
                default(sbyte),
                "",
                default(sbyte),
                ImmutableArray<AclDescription>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PrincipalField">The ACL principal.</param>
            /// <param name="HostField">The ACL host.</param>
            /// <param name="OperationField">The ACL operation.</param>
            /// <param name="PermissionTypeField">The ACL permission type.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record AclDescription (
                string PrincipalField,
                string HostField,
                sbyte OperationField,
                sbyte PermissionTypeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static AclDescription Empty { get; } = new(
                    "",
                    "",
                    default(sbyte),
                    default(sbyte),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
