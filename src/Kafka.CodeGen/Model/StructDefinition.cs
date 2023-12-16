using System.Collections.Immutable;

namespace Kafka.CodeGen.Model
{
    public sealed record StructDefinition(
        string Name,
        ImmutableArray<Field> Fields,
        ImmutableSortedDictionary<string, StructDefinition> Structs
    );
}
