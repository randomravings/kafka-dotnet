using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("offset")]
    public sealed class GroupsOffsetOpts
        : Opts
    {
        [Option("groups")]
        public IEnumerable<string> Groups { get; set; } = [];

        [Option("topics")]
        public IEnumerable<string> Topics { get; set; } = [];
    }
}
