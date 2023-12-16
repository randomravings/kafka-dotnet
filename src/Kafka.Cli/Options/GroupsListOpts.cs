using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list")]
    public sealed class GroupsListOpts
        : Opts
    {
        [Option("states")]
        public IEnumerable<string> States { get; set; } = [];
    }
}
