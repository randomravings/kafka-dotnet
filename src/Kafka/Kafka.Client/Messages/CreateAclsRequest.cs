using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AclCreation = Kafka.Client.Messages.CreateAclsRequest.AclCreation;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="CreationsField">The ACLs that we want to create.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateAclsRequest (
        ImmutableArray<AclCreation> CreationsField
    ) : Request(30)
    {
        public static CreateAclsRequest Empty { get; } = new(
            ImmutableArray<AclCreation>.Empty
        );
        public static short FlexibleVersion { get; } = 2;
        /// <summary>
        /// <param name="ResourceTypeField">The type of the resource.</param>
        /// <param name="ResourceNameField">The resource name for the ACL.</param>
        /// <param name="ResourcePatternTypeField">The pattern type for the ACL.</param>
        /// <param name="PrincipalField">The principal for the ACL.</param>
        /// <param name="HostField">The host for the ACL.</param>
        /// <param name="OperationField">The operation type for the ACL (read, write, etc.).</param>
        /// <param name="PermissionTypeField">The permission type for the ACL (allow, deny, etc.).</param>
        /// </summary>
        public sealed record AclCreation (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte ResourcePatternTypeField,
            string PrincipalField,
            string HostField,
            sbyte OperationField,
            sbyte PermissionTypeField
        )
        {
            public static AclCreation Empty { get; } = new(
                default(sbyte),
                "",
                default(sbyte),
                "",
                "",
                default(sbyte),
                default(sbyte)
            );
        };
    };
}