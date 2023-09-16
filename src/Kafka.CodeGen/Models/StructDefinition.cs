using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record StructDefinition(
        string Name,
        ImmutableArray<Field> Fields,
        ImmutableSortedDictionary<string, StructDefinition> Structs
    );
}
