using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="GroupsField">The names of the groups to describe</param>
    /// <param name="IncludeAuthorizedOperationsField">Whether to include authorized operations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DescribeGroupsRequestData (
        ImmutableArray<string> GroupsField,
        bool IncludeAuthorizedOperationsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DescribeGroupsRequestData Empty { get; } = new(
            ImmutableArray<string>.Empty,
            default(bool),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
