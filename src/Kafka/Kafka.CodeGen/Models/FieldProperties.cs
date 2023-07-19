using VersionRange = Kafka.Common.Model.VersionRange;

namespace Kafka.CodeGen.Models
{
    public sealed record FieldProperties(
        VersionRange Versions,
        VersionRange NullableVersions,
        VersionRange TaggedVersions,
        VersionRange FlexibleVersions,
        string EntityType,
        string About,
        bool Ignorable,
        bool MapKey,
        bool ZeroCopy,
        int Tag
    );
}
