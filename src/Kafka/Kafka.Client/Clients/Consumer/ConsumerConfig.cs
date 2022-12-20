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
        public string GroupId { get; set; } = "";        
    }
}
