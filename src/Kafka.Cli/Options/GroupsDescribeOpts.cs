using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe", HelpText = "Describe consumer groups")]
    public sealed class GroupsDescribeOpts
        : Opts
    {
        [Option("groups", Required = true, HelpText = "List of consumer groups to describe")]
        public IEnumerable<string> Groups { get; set; } = [];
        [Option("show-allowed-operations", Default = false, HelpText = "Shows the allowed operations on the consumer group")]
        public bool ShowAllowedOperations { get; set; } = false;
    }
}
