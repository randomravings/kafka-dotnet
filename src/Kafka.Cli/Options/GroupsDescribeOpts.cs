using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("describe")]
    public sealed class GroupsDescribeOpts
        : Opts
    {
        [Option("groups", Required = true)]
        public IEnumerable<string> Groups { get; set; } = [];
        [Option("show-allowed-operations")]
        public bool ShowAllowedOperations { get; set; } = true;
    }
}
