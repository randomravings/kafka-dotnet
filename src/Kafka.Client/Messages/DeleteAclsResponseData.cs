using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteAclsFilterResult = Kafka.Client.Messages.DeleteAclsResponseData.DeleteAclsFilterResult;
using DeleteAclsMatchingAcl = Kafka.Client.Messages.DeleteAclsResponseData.DeleteAclsFilterResult.DeleteAclsMatchingAcl;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="FilterResultsField">The results for each filter.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteAclsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<DeleteAclsFilterResult> FilterResultsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static DeleteAclsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<DeleteAclsFilterResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The error code, or 0 if the filter succeeded.</param>
        /// <param name="ErrorMessageField">The error message, or null if the filter succeeded.</param>
        /// <param name="MatchingAclsField">The ACLs which matched this filter.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeleteAclsFilterResult (
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<DeleteAclsMatchingAcl> MatchingAclsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeleteAclsFilterResult Empty { get; } = new(
                default(short),
                default(string?),
                ImmutableArray<DeleteAclsMatchingAcl>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="ErrorCodeField">The deletion error code, or 0 if the deletion succeeded.</param>
            /// <param name="ErrorMessageField">The deletion error message, or null if the deletion succeeded.</param>
            /// <param name="ResourceTypeField">The ACL resource type.</param>
            /// <param name="ResourceNameField">The ACL resource name.</param>
            /// <param name="PatternTypeField">The ACL resource pattern type.</param>
            /// <param name="PrincipalField">The ACL principal.</param>
            /// <param name="HostField">The ACL host.</param>
            /// <param name="OperationField">The ACL operation.</param>
            /// <param name="PermissionTypeField">The ACL permission type.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record DeleteAclsMatchingAcl (
                short ErrorCodeField,
                string? ErrorMessageField,
                sbyte ResourceTypeField,
                string ResourceNameField,
                sbyte PatternTypeField,
                string PrincipalField,
                string HostField,
                sbyte OperationField,
                sbyte PermissionTypeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static DeleteAclsMatchingAcl Empty { get; } = new(
                    default(short),
                    default(string?),
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
    };
}
