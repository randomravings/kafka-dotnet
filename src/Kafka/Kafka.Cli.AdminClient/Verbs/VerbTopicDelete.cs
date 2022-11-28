using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("delete")]
    public sealed class VerbTopicDelete
        : OptionsBaseTopic
    { }
}
