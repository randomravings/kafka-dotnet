using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("produce")]
    public sealed class VerbProduce
        : OptionsBaseTopic
    {
        [Option("property")]
        public IEnumerable<string> Property { get; set; } = Array.Empty<string>();
    }
}
