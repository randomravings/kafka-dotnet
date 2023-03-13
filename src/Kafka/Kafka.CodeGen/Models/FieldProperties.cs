using Version = Kafka.Common.Model.Version;

namespace Kafka.CodeGen.Models
{
    public sealed record FieldProperties(
        Version Versions,
        Version NullableVersions,
        Version TaggedVersions,
        Version FlexibleVersions,
        string EntityType,
        string About,
        bool Ignorable,
        bool MapKey,
        bool ZeroCopy,
        int Tag
    );
}
