using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("delete", HelpText = "Delete consumer groups")]
    public sealed class GroupsDeleteOpts
        : Opts
    {
        [Option("groups", Required = true, HelpText = "List of consumer groups to delete")]
        public IEnumerable<string> Groups { get; set; } = [];
    }
}
