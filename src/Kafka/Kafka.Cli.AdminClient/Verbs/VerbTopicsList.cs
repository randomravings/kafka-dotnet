using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("list")]
    public sealed class VerbTopicsList
        : OptionsBase
    {
        [Option("exclude-internal")]
        public bool ExcludeInternal { get; set; } = false;
    }
}
