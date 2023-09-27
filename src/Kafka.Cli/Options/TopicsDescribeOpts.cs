using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe")]
    public sealed class TopicsDescribeOpts
        : KafkaCliOpts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
    }
}
