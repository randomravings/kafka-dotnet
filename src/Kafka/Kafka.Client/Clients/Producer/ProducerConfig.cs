using System.Collections.Concurrent;
using System.Text.Json.Serialization;

namespace Kafka.Client.Clients.Producer
{
    public sealed class ProducerConfig
        : Config
    {
        [JsonPropertyName("partitioner.class")]
        public string PartitionerClass { get; } = "";
        [JsonPropertyName("key.serializer")]
        public string KeySerializer { get; } = "";
        [JsonPropertyName("value.serializer")]
        public string ValueSerializer { get; } = "";
    }
}
