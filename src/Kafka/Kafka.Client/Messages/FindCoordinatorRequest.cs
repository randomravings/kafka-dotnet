using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="KeyField">The coordinator key.</param>
    /// <param name="KeyTypeField">The coordinator key type. (Group, transaction, etc.)</param>
    /// <param name="CoordinatorKeysField">The coordinator keys.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FindCoordinatorRequest (
        string KeyField,
        sbyte KeyTypeField,
        ImmutableArray<string> CoordinatorKeysField
    ) : Request(10)
    {
        public static FindCoordinatorRequest Empty { get; } = new(
            "",
            default(sbyte),
            ImmutableArray<string>.Empty
        );
    };
}