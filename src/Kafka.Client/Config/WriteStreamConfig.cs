using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kafka.Client.Config
{
    public sealed class WriteStreamConfig
    {
        [JsonPropertyName("buffer.memory")]
        public long BufferMemory { get; set; } = 33554432;
        [JsonPropertyName("partitioner.class")]
        public string PartitionerClass { get; set; } = "";
        [JsonPropertyName("max.in.flight.requests.per.connection")]
        public int MaxInFlightRequestsPerConnection { get; set; } = 5;
        [JsonPropertyName("max.request.size")]
        public int MaxRequestSize { get; set; } = 1048576;
        [JsonPropertyName("linger.ms")]
        public long LingerMs { get; set; } = 50;
        [JsonPropertyName("batch.size")]
        public int BatchSize { get; set; } = 16384;
        [JsonPropertyName("acks")]
        public string Acks { get; set; } = "all";
        [JsonPropertyName("enable.idempotence")]
        public bool EnableIdempotence { get; set; } = false;
        [JsonPropertyName("transactional.id")]
        public string? TransactionalId { get; set; } = null;
        [JsonPropertyName("transaction.timeout.ms")]
        public int TransactionTimeoutMs { get; set; } = 60000;
        [JsonPropertyName("delivery.timeout.ms")]
        public int DeliveryTimeoutMs { get; set; } = 120000;
        public override string ToString() =>
            JsonSerializer.Serialize(
                this,
                KafkaClientConfig.JsonSerializerOptions
            )
        ;

    }
}
