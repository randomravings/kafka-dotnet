using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list", HelpText = "List topics")]
    public sealed class TopicsListOpts
        : Opts
    {
        [Option("include-internal", Default = false, HelpText = "Includes interal topics in the list")]
        public bool IncludeInternal { get; set; } = false;
        [Option("show-allowed-operations", Default = false, HelpText = "Shows the allowed operations on the topic")]
        public bool ShowAllowedOperations { get; set; } = true;
    }
}
