using System.Collections.Immutable;
using Kafka.Common.Model;

namespace Kafka.CodeGen.Models
{
    public sealed record HeaderMessage(
        string Name,
        VersionRange ValidVersions,
        VersionRange FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) :
        MessageDefinition(
            Name,
            ApiKey.None,
            ValidVersions,
            FlexibleVersions,
            Fields,
            Structs
        )
    ;
}
