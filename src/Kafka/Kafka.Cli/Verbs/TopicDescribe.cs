using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("describe")]
    public sealed class TopicDescribe
        : OptionsBaseTopic
    { }
}
