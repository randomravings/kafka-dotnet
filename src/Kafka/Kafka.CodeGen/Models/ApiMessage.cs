using Kafka.Common.Types;
using System.Collections.Immutable;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.Models
{
    public abstract record ApiMessage(
        Api ApiKey,
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) : MessageDefinition(
        Name,
        ValidVersions,
        FlexibleVersions,
        Fields,
        Structs
    );
}
