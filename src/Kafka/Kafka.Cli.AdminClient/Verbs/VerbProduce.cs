using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("produce")]
    public sealed class VerbProduce
        : OptionsBaseTopic
    { }
}
