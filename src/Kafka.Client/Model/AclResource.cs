using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record AclResource(
        ResourceType ResourceType,
        string ResourceName,
        PatternType PatternType,
        ImmutableArray<Acl> Acls
    )
    {
        public static AclResource Empty { get; } = new(
            ResourceType.Any,
            "",
            PatternType.Any,
            ImmutableArray<Acl>.Empty
        );
    }
}
