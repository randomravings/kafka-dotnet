using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("offset")]
    public sealed class GroupsOffsetOpts
        : Opts
    {
        [Option("group")]
        public string Group { get; set; } = "";

        [Option("topics")]
        public IEnumerable<string> Topics { get; set; } = [];
    }
}
