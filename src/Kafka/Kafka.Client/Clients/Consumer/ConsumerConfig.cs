using System.Text.Json.Serialization;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class ConsumerConfig
        : ClientConfig
    {
        [JsonPropertyName("key.serializer")]
        public string KeyDeserializer { get; set; } = "";
        [JsonPropertyName("value.serializer")]
        public string ValueDeserializer { get; set; } = "";
        [JsonPropertyName("group.id")]
        public string? GroupId { get; set; } = null;
        [JsonPropertyName("group.instance.id")]
        public string? GroupInstanceId { get; set; } = null;
        [JsonPropertyName("enable.auto.commit")]
        public bool EnableAutoCommit { get; set; } = true;
        [JsonPropertyName("auto.commit.interval.ms")]
        public int AutoCommitIntervalMs { get; set; } = 5000;
        [JsonPropertyName("heartbeat.interval.ms")]
        public int HeartbeatIntervalMs { get; set; } = 3000;
        
    }
}
