using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupsNamesField">The group names to delete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteGroupsRequest (
        ImmutableArray<string> GroupsNamesField
    )
    {
        public static DeleteGroupsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty
        );
    };
}