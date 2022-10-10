using Kafka.Common.Protocol;
using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record ResponseMessage(
        ApiKey ApiKey,
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, Struct> Structs
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
