using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="StatesFilterField">The states of the groups we want to list. If empty, all groups are returned with their state.</param>
    /// <param name="TypesFilterField">The types of the groups we want to list. If empty, all groups are returned with their type.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ListGroupsRequestData (
        ImmutableArray<string> StatesFilterField,
        ImmutableArray<string> TypesFilterField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static ListGroupsRequestData Empty { get; } = new(
            ImmutableArray<string>.Empty,
            ImmutableArray<string>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
    };
}
