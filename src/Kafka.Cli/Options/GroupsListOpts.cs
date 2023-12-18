using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list", HelpText = "List consumer groups")]
    public sealed class GroupsListOpts
        : Opts
    {
        [Option("states", HelpText = "List of consumer group states to show. All states if omitted")]
        public IEnumerable<string> States { get; set; } = [];
    }
}
