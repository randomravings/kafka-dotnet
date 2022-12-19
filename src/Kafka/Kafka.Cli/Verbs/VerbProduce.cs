using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("produce")]
    public sealed class VerbProduce
        : OptionsBaseTopic
    { }
}
