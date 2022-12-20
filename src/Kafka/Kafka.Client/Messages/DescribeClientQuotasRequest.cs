using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using ComponentData = Kafka.Client.Messages.DescribeClientQuotasRequest.ComponentData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ComponentsField">Filter components to apply to quota entities.</param>
    /// <param name="StrictField">Whether the match is strict, i.e. should exclude entities with unspecified entity types.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClientQuotasRequest (
        ImmutableArray<ComponentData> ComponentsField,
        bool StrictField
    ) : Request(48,0,1,1)
    {
        public static DescribeClientQuotasRequest Empty { get; } = new(
            ImmutableArray<ComponentData>.Empty,
            default(bool)
        );
        /// <summary>
        /// <param name="EntityTypeField">The entity type that the filter component applies to.</param>
        /// <param name="MatchTypeField">How to match the entity {0 = exact name, 1 = default name, 2 = any specified name}.</param>
        /// <param name="MatchField">The string to match against, or null if unused for the match type.</param>
        /// </summary>
        public sealed record ComponentData (
            string EntityTypeField,
            sbyte MatchTypeField,
            string? MatchField
        )
        {
            public static ComponentData Empty { get; } = new(
                "",
                default(sbyte),
                default(string?)
            );
        };
    };
}