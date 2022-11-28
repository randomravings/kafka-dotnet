using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("describe")]
    public sealed class VerbTopicDescribe
        : OptionsBaseTopic
    { }
}
