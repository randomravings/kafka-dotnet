using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list")]
    public sealed class TopicsListOpts
        : KafkaCliOpts
    {
        [Option("exclude-internal")]
        public bool ExcludeInternal { get; set; } = false;
    }
}
