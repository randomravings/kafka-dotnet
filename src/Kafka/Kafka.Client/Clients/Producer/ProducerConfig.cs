using System.Text.Json.Serialization;

namespace Kafka.Client.Clients.Producer
{
    public sealed class ProducerConfig
        : ClientConfig
    {
        [JsonPropertyName("partitioner.class")]
        public string PartitionerClass { get; } = "";
        [JsonPropertyName("key.serializer")]
        public string KeySerializer { get; } = "";
        [JsonPropertyName("value.serializer")]
        public string ValueSerializer { get; } = "";
        [JsonPropertyName("max.in.flight.requests.per.connection")]
        public int MaxInFlightRequestsPerConnection { get; } = 5;
        [JsonPropertyName("max.request.size")]
        public int MaxRequestSize { get; } = 1048576;
        [JsonPropertyName("linger.ms")]
        public long LingerMs { get; } = 0;
    }
}
