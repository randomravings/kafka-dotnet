using Kafka.Common.Types;
using System.Collections.Immutable;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.Models
{
    public sealed record ApiResponseMessage(
        ApiKey ApiKey,
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) :
        ApiMessage(
            ApiKey,
            Name,
            ValidVersions,
            FlexibleVersions,
            Fields,
            Structs
        )
    ;
}
