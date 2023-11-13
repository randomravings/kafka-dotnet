using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list")]
    public sealed class TopicsListOpts
        : Opts
    {
        [Option("include-internal")]
        public bool IncludeInternal { get; set; } = false;
        [Option("show-allowed-operations")]
        public bool ShowAllowedOperations { get; set; } = true;
    }
}
