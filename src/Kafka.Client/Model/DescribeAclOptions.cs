using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DescribeAclOptions(
        ResourceType ResourceType,
        Filter? ResourceNameFilter,
        PatternType PatternType,
        Filter? PrincipalFilter,
        Filter? HostFilter,
        AclOperation Operation,
        AclPermissionType PermissionType
    )
    {
        public static DescribeAclOptions Empty { get; } = new(
            ResourceType.Any,
            Filter.Empty,
            PatternType.Any,
            Filter.Empty,
            Filter.Empty,
            AclOperation.Any,
            AclPermissionType.Any
        );
    }
}
