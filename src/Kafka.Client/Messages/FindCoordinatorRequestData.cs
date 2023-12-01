using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="KeyField">The coordinator key.</param>
    /// <param name="KeyTypeField">The coordinator key type. (Group, transaction, etc.)</param>
    /// <param name="CoordinatorKeysField">The coordinator keys.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record FindCoordinatorRequestData (
        string KeyField,
        sbyte KeyTypeField,
        ImmutableArray<string> CoordinatorKeysField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static FindCoordinatorRequestData Empty { get; } = new(
            "",
            default(sbyte),
            ImmutableArray<string>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
    };
}
