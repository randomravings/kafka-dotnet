using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record Struct(
        string Name,
        Version Versions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, Struct> Structs
    );
}
