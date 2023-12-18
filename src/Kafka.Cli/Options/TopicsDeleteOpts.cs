using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("delete", HelpText = "Delete a topic")]
    public sealed class TopicsDeleteOpts
        : Opts
    {
        [Option("topic", Required = true, HelpText = "Name of topic to describe")]
        public string Topic { get; set; } = "";
    }
}
