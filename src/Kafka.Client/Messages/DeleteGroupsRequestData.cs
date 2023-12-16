using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="GroupsNamesField">The group names to delete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteGroupsRequestData (
        ImmutableArray<string> GroupsNamesField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DeleteGroupsRequestData Empty { get; } = new(
            ImmutableArray<string>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
    };
}
