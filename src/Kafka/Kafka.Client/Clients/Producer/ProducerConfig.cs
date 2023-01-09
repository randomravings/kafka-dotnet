using System.Text.Json.Serialization;

namespace Kafka.Client.Clients.Producer
{
    public sealed class ProducerConfig
        : ClientConfig
    {
        [JsonPropertyName("partitioner.class")]
        public string PartitionerClass { get; set; } = "";
        [JsonPropertyName("key.serializer")]
        public string KeySerializer { get; set; } = "";
        [JsonPropertyName("value.serializer")]
        public string ValueSerializer { get; set; } = "";
        [JsonPropertyName("max.in.flight.requests.per.connection")]
        public int MaxInFlightRequestsPerConnection { get; set; } = 5;
        [JsonPropertyName("max.request.size")]
        public int MaxRequestSize { get; set; } = 1048576;
        [JsonPropertyName("linger.ms")]
        public long LingerMs { get; set; } = 50;
        [JsonPropertyName("acks")]
        public string Acks { get; set; } = "all";
        [JsonPropertyName("enable.idempotence")]
        public bool EnableIdempotence { get; set; } = true;
        [JsonPropertyName("transactional.id")]
        public string? TransactionalId { get; set; } = null;
        [JsonPropertyName("transaction.timeout.ms")]
        public int TransactionTimeoutMs { get; set; } = 60000;

    }
}
