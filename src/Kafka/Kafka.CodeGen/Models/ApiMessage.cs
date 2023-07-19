using Kafka.Common.Model;
using System.Collections.Immutable;
using VersionRange = Kafka.Common.Model.VersionRange;

namespace Kafka.CodeGen.Models
{
    public abstract record ApiMessage(
        string Name,
        ApiKey ApiKey,
        VersionRange ValidVersions,
        VersionRange FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    ) : MessageDefinition(
        Name,
        ApiKey,
        ValidVersions,
        FlexibleVersions,
        Fields,
        Structs
    );
}
