using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponse.AclCreationResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each ACL creation.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateAclsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AclCreationResult> ResultsField
    ) : Response(30)
    {
        public static CreateAclsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AclCreationResult>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The result error, or zero if there was no error.</param>
        /// <param name="ErrorMessageField">The result message, or null if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record AclCreationResult (
            short ErrorCodeField,
            string? ErrorMessageField
        )
        {
            public static AclCreationResult Empty { get; } = new(
                default(short),
                default(string?)
            );
        };
    };
}