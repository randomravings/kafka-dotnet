using Kafka.CodeGen.Serialization;
using Kafka.Common.Model;
using Newtonsoft.Json;
using System.Collections.Immutable;
using VersionRange = Kafka.Common.Model.VersionRange;

namespace Kafka.CodeGen.Models
{
    [JsonConverter(typeof(MessageJsonConverter))]
    public abstract record MessageDefinition(
        string Name,
        ApiKey ApiKey,
        VersionRange ValidVersions,
        VersionRange FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    );
}
