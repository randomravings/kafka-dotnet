using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("delete")]
    public sealed class TopicsDeleteOpts
        : Opts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
    }
}
