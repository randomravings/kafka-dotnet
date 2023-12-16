using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("delete")]
    public sealed class GroupsDeleteOpts
        : Opts
    {
        [Option("groups", Required = true)]
        public IEnumerable<string> Groups { get; set; } = [];
    }
}
