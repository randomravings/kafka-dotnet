using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponse.DeletableGroupResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The deletion results</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteGroupsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<DeletableGroupResult> ResultsField
    ) : Response(42)
    {
        public static DeleteGroupsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<DeletableGroupResult>.Empty
        );
        /// <summary>
        /// <param name="GroupIdField">The group id</param>
        /// <param name="ErrorCodeField">The deletion error, or 0 if the deletion succeeded.</param>
        /// </summary>
        public sealed record DeletableGroupResult (
            string GroupIdField,
            short ErrorCodeField
        )
        {
            public static DeletableGroupResult Empty { get; } = new(
                "",
                default(short)
            );
        };
    };
}