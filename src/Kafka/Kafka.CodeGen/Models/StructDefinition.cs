using System.Collections.Immutable;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.Models
{
    public sealed record StructDefinition(
        string Name,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) :
        MessageDefinition(
            Name,
            Version.All,
            Version.All,
            Fields,
            Structs
        )
    ;
}
