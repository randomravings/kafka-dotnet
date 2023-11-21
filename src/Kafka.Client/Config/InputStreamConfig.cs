using Kafka.Client.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kafka.Client.Config
{
    public sealed class InputStreamConfig
    {
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
        [JsonPropertyName("fetch.min.bytes")]
        public int FetchMinBytes { get; set; } = 1;
        [JsonPropertyName("fetch.max.bytes")]
        public int FetchMaxBytes { get; set; } = 52428800;
        [JsonPropertyName("isolation.level")]
        public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadUncommitted;
        [JsonPropertyName("fetch.max.wait.ms")]
        public int FetchMaxWaitMs { get; set; } = 500;
        [JsonPropertyName("client.rack")]
        public string ClientRack { get; set; } = "";
        [JsonPropertyName("max.partition.fetch.bytes")]
        public int MaxPartitionFetchBytes { get; set; } = 1048576;
        [JsonPropertyName("session.timeout.ms")]
        public int SessionTimeoutMs { get; set; } = 45000;
        [JsonPropertyName("max.poll.interval.ms")]
        public int MaxPollIntervalMs { get; set; } = 300000;
        [JsonPropertyName("auto.offset.reset")]
        public AutoOffsetReset AutoOffsetReset { get; set; } = AutoOffsetReset.Latest;
        public override string ToString() =>
            JsonSerializer.Serialize(
                this,
                KafkaClientConfig.JsonSerializerOptions
            )
        ;
    }
}
