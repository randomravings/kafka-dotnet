using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("delete")]
    public sealed class TopicsDeleteOpts
        : KafkaCliOpts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
    }
}
