using System.Collections.Immutable;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.Models
{
    public sealed record RequestHeaderMessage(
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields
    ) :
        MessageDefinition(
            Name,
            ValidVersions,
            FlexibleVersions,
            Fields,
            ImmutableDictionary<string, StructDefinition>.Empty
        )
    ;
}
