using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("offset", HelpText = "List offsets for consumer group")]
    public sealed class GroupsOffsetOpts
        : Opts
    {
        [Option("groups", HelpText = "List of consumer group to show. All consumer groups if omitted")]
        public IEnumerable<string> Groups { get; set; } = [];

        [Option("topics", HelpText = "List of topics to show per consumer group. All topics if omitted")]
        public IEnumerable<string> Topics { get; set; } = [];
    }
}
