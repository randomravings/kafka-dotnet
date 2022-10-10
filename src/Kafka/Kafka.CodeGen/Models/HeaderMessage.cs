using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record HeaderMessage(
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, Struct> Structs
    ) :
        Message(
            Name,
            ValidVersions,
            FlexibleVersions,
            Fields,
            Structs
        )
    ;
}
