using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource.AclDescription;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
    /// <param name="ResourcesField">Each Resource that is referenced in an ACL.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeAclsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<DescribeAclsResource> ResourcesField
    ) : Response(29)
    {
        public static DescribeAclsResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<DescribeAclsResource>.Empty
        );
        public static short FlexibleVersion { get; } = 2;
        /// <summary>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// <param name="PatternTypeField">The resource pattern type.</param>
        /// <param name="AclsField">The ACLs.</param>
        /// </summary>
        public sealed record DescribeAclsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte PatternTypeField,
            ImmutableArray<AclDescription> AclsField
        )
        {
            public static DescribeAclsResource Empty { get; } = new(
                default(sbyte),
                "",
                default(sbyte),
                ImmutableArray<AclDescription>.Empty
            );
            /// <summary>
            /// <param name="PrincipalField">The ACL principal.</param>
            /// <param name="HostField">The ACL host.</param>
            /// <param name="OperationField">The ACL operation.</param>
            /// <param name="PermissionTypeField">The ACL permission type.</param>
            /// </summary>
            public sealed record AclDescription (
                string PrincipalField,
                string HostField,
                sbyte OperationField,
                sbyte PermissionTypeField
            )
            {
                public static AclDescription Empty { get; } = new(
                    "",
                    "",
                    default(sbyte),
                    default(sbyte)
                );
            };
        };
    };
}