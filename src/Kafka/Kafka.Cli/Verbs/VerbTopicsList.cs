using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("list")]
    public sealed class VerbTopicsList
        : OptionsBase
    {
        [Option("exclude-internal")]
        public bool ExcludeInternal { get; set; } = false;
    }
}
