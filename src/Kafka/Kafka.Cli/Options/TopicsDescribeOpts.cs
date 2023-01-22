using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe")]
    public sealed class TopicsDescribeOpts
        : KafkaCliOpts
    {
        [Option("topic", SetName = "topic-by-name", Required = true)]
        public string Topic { get; set; } = "";
        [Option("topic-id", SetName = "topic-by-id", Required = true)]
        public Guid TopicId { get; set; } = Guid.Empty;
    }
}
