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
        [Option("batch-size", HelpText = "Number of messages collected before sent to underlying producer. The effectiveness depends on the producer configs.")]
        public int BatchSize { get; set; } = 1;
    }
}
