using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponseData.DeletableGroupResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The deletion results</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteGroupsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<DeletableGroupResult> ResultsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static DeleteGroupsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<DeletableGroupResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="GroupIdField">The group id</param>
        /// <param name="ErrorCodeField">The deletion error, or 0 if the deletion succeeded.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeletableGroupResult (
            string GroupIdField,
            short ErrorCodeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeletableGroupResult Empty { get; } = new(
                "",
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
