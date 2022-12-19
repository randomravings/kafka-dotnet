using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("delete")]
    public sealed class VerbTopicDelete
        : OptionsBaseTopic
    { }
}
