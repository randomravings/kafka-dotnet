using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.CodeGen.Models
{
    public sealed record DataMessage(
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) :
        MessageDefinition(
            Name,
            ValidVersions,
            FlexibleVersions,
            Fields,
            Structs
        )
    ;
}
