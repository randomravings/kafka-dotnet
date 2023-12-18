using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe", HelpText = "Describe a topic")]
    public sealed class TopicsDescribeOpts
        : Opts
    {
        [Option("topic", Required = true, HelpText = "Name of topic to describe")]
        public string Topic { get; set; } = "";
        [Option("show-allowed-operations", Default = false, HelpText = "Shows the allowed operations on the topic")]
        public bool ShowAllowedOperations { get; set; } = false;
    }
}
