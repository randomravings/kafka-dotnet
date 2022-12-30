using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("produce")]
    public sealed class Produce
        : OptionsBaseTopic
    {
        [Option("property", Separator = ',')]
        public IEnumerable<string> Property { get; set; } = Array.Empty<string>();


        [Option("batch-size", HelpText = "Number of messages collected before sent to underlying producer. The effectiveness depends on the producer configs.")]
        public int BatchSize { get; set; } = 1;
    }
}
