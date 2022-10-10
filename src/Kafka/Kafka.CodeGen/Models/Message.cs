using Kafka.CodeGen.Serialization;
using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Kafka.CodeGen.Models
{
    [JsonConverter(typeof(MessageJsonConverter))]
    public record Message(
        string Name,
        Version ValidVersions,
        Version FlexibleVersions,
        ImmutableArray<Field> Fields,
        IImmutableDictionary<string, Struct> Structs
    );
}
