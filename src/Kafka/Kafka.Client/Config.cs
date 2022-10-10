using System.Text.Json.Serialization;

namespace Kafka.Client
{
    public abstract class Config
    {
        [JsonPropertyName("bootstrap.servers")]
        public string BootstrapServers { get; set; } = "";

    }
}
