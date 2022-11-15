using Kafka.CodeGen.Serialization;
using Newtonsoft.Json;
using System.Collections.Immutable;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.Models
{
    [JsonConverter(typeof(MessageJsonConverter))]
    public abstract record MessageDefinition(
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, StructDefinition> Structs
    );
}
