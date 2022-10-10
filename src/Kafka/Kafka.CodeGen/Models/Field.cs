using System.Collections.Immutable;

namespace Kafka.CodeGen.Models
{
    public sealed record Field(
        string Name,
        FieldType Type,
        Version Versions,
        Version NullableVersions,
        Version TaggedVersions,
        Version FlexibleVersions,
        string EntityType,
        string About,
        bool Ignorable,
        bool MapKey,
        bool ZeroCopy,
        int Tag,
        object DefaultValue
    );
}
