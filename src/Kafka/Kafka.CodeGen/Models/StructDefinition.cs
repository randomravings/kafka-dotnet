using System.Collections.Immutable;
using Kafka.Common.Model;

namespace Kafka.CodeGen.Models
{
    public sealed record StructDefinition(
        string Name,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) :
        MessageDefinition(
            Name,
            ApiKey.None,
            VersionRange.All,
            VersionRange.All,
            Fields,
            Structs
        )
    ;
}
