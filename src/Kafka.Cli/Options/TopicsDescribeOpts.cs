using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe")]
    public sealed class TopicsDescribeOpts
        : Opts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
    }
}
