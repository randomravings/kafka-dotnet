using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record DataMessage(
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
