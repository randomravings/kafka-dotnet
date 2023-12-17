using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponseData.AclCreationResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each ACL creation.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record CreateAclsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<AclCreationResult> ResultsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static CreateAclsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<AclCreationResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The result error, or zero if there was no error.</param>
        /// <param name="ErrorMessageField">The result message, or null if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record AclCreationResult (
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static AclCreationResult Empty { get; } = new(
                default(short),
                default(string?),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
