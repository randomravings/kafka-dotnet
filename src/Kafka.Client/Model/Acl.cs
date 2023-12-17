using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record Acl(
        string Principal,
        string Host,
        AclOperation Operation,
        AclPermissionType PermissionType
    )
    {
        public static Acl Empty { get; } = new(
            "",
            "",
            AclOperation.None,
            AclPermissionType.None
        );
    }
}
