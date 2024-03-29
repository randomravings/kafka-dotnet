using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AclCreation = Kafka.Client.Messages.CreateAclsRequestData.AclCreation;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="CreationsField">The ACLs that we want to create.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record CreateAclsRequestData (
        ImmutableArray<AclCreation> CreationsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static CreateAclsRequestData Empty { get; } = new(
            ImmutableArray<AclCreation>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ResourceTypeField">The type of the resource.</param>
        /// <param name="ResourceNameField">The resource name for the ACL.</param>
        /// <param name="ResourcePatternTypeField">The pattern type for the ACL.</param>
        /// <param name="PrincipalField">The principal for the ACL.</param>
        /// <param name="HostField">The host for the ACL.</param>
        /// <param name="OperationField">The operation type for the ACL (read, write, etc.).</param>
        /// <param name="PermissionTypeField">The permission type for the ACL (allow, deny, etc.).</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record AclCreation (
            sbyte ResourceTypeField,
            string ResourceNameField,
            sbyte ResourcePatternTypeField,
            string PrincipalField,
            string HostField,
            sbyte OperationField,
            sbyte PermissionTypeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static AclCreation Empty { get; } = new(
                default(sbyte),
                "",
                default(sbyte),
                "",
                "",
                default(sbyte),
                default(sbyte),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
