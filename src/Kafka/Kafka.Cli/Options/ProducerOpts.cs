using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("producer")]
    public sealed class ProducerOpts
        : KafkaCliOpts
    {
        [Option("topic", SetName = "topic-by-name", Required = true)]
        public string TopicName { get; set; } = "";

        [Option("topic-id", SetName = "topic-by-id", Required = true)]
        public Guid TopicId { get; set; } = Guid.Empty;

        [Option("property", Separator = ',')]
        public IEnumerable<string> Property { get; set; } = Array.Empty<string>();

        [Option("batch-size", HelpText = "Maximum number of messages in flight per connection.", Default = 5)]
        public int MaxInFlightRequestsPerConnection { get; set; } = 1;

        [Option("batch-size-bytes", HelpText = "Maximum size in bytes in flight per connection.", Default = 1048576)]
        public int MaxRequestSize { get; set; } = 0;

        [Option("linger-ms", HelpText = "Maximum time before sending records.", Default = 50)]
        public int LingerMs { get; set; } = 0;

        [Option("transactional-id", Required = false)]
        public string? TransactionalId { get; set; } = null;
    }
}
