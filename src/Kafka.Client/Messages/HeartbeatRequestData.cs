using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="GroupIdField">The group id.</param>
    /// <param name="GenerationIdField">The generation of the group.</param>
    /// <param name="MemberIdField">The member ID.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record HeartbeatRequestData (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string? GroupInstanceIdField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        public static HeartbeatRequestData Empty { get; } = new(
            "",
            default(int),
            "",
            default(string?),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
