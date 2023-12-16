using Kafka.CodeGen.Serialization;
using Kafka.Common.Model;
using Newtonsoft.Json;
using System.Collections.Immutable;
using VersionRange = Kafka.Common.Model.VersionRange;

namespace Kafka.CodeGen.Model
{
    [JsonConverter(typeof(MessageJsonConverter))]
    public sealed record MessageDefinition(
        string Name,
        ApiKey ApiKey,
        MessageType MessageType,
        bool LatestVersionUnstable,
        VersionRange ValidVersions,
        VersionRange FlexibleVersions,
        ImmutableSortedSet<Listener> Listeners,
        ImmutableArray<Field> Fields,
        ImmutableSortedDictionary<string, StructDefinition> Structs
    );
}
